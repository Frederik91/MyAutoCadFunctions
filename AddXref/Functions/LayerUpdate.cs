using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.DatabaseServices;
using LayerConfigEditor.Models;
using LayerConfigEditor.Workers;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using XrefManager.Workers;

namespace XrefManager
{
    public class LayerUpdate
    {
        private List<LayerFilter> propertyList = new List<LayerFilter>();
        private int layersModified = 0;
        private int totalLayers = 0;
        private List<string> successfullDrawings = new List<string>();
        private List<string> failedDrawings = new List<string>();
        private List<string> drawingList = new List<string>();

        public void UpdateLayersThisDrawing()
        {
            string configPath = string.Empty;
            var projectLocator = new LocateFileProject();

            configPath = projectLocator.returnConfigFilePath();

            if (string.IsNullOrEmpty(configPath))
            {
                var res = System.Windows.Forms.MessageBox.Show("Drawing is not connected to a project. Do you want to create a new project?", "Drawing not connected to project", System.Windows.Forms.MessageBoxButtons.YesNo);
                if (res == System.Windows.Forms.DialogResult.Yes)
                {
                    UpdateLayers();
                }
                return;
            }

            var reader = new ConfigFileReader();

            propertyList = reader.readConfigFile(configPath);

            Document document = Application.DocumentManager.MdiActiveDocument;

            ModifyOpenDrawing(document);

            document.Editor.WriteMessage("\nModified " + layersModified + " out of " + totalLayers + " layers\n");
        }

        public void UpdateLayers()
        {
            using (var form = new Forms.UpdateLayerForm())
            {
                form.ShowDialog();
                if (string.IsNullOrEmpty(form.configPath))
                {
                    return;
                }

                var configFileReader = new ConfigFileReader();
                propertyList = configFileReader.readConfigFile(form.configPath);
                drawingList = form.DrawingList;
            }

            ChangeLayersOnDrawings(propertyList, drawingList);
        }

        public void ChangeLayersOnDrawings(List<LayerFilter> propList, List<string> drawingList)
        {
            Document Doc = Application.DocumentManager.MdiActiveDocument;
            var totalDrawings = drawingList.Count;

            propertyList = propList;

            foreach (Document document in Application.DocumentManager)
            {
                if (drawingList.Contains(document.Name))
                {
                    ModifyOpenDrawing(document);
                    drawingList.Remove(document.Name);
                }
            }

            foreach (var drawing in drawingList)
            {
                ModifyClosedDrawing(drawing);
            }

            Doc.Editor.WriteMessage("\nModified " + layersModified + " out of " + totalLayers + " layers on " + successfullDrawings.Count + " out of " + totalDrawings + " drawings");
        }

        private void ModifyOpenDrawing(Document document)
        {
            using (DocumentLock docloc = document.LockDocument())
            {
                using (Transaction trx = document.TransactionManager.StartTransaction())
                {
                    var layerTable = trx.GetObject(document.Database.LayerTableId, OpenMode.ForRead) as LayerTable;
                    var currentLayerObj = document.Database.Clayer;

                    foreach (ObjectId acObjId in layerTable)
                    {
                        // Get layer info from object
                        LayerTableRecord LayerRecord = acObjId.GetObject(OpenMode.ForWrite) as LayerTableRecord;

                        // If LayerRecord is current layer, change to another layer
                        if (document.Database.Clayer == acObjId)
                        {
                            // Search for layer that is not frozen, off, locked or xref-dependent.
                            foreach (var layObj in layerTable)
                            {
                                LayerTableRecord lay = layObj.GetObject(OpenMode.ForWrite) as LayerTableRecord;

                                if (lay.Name != LayerRecord.Name && !lay.IsFrozen && !lay.IsOff && !lay.IsLocked && !lay.IsDependent)
                                {
                                    document.Database.Clayer = layObj;
                                }
                            }
                        }
                        // Modify layer
                        modifyLayer(LayerRecord, propertyList);
                    }

                    try
                    {
                        document.Database.Clayer = currentLayerObj;
                    }
                    catch (Exception)
                    {

                    }


                    trx.Commit();
                    trx.Dispose();
                    successfullDrawings.Add(document.Name);
                    drawingList.Remove(document.Name);
                }
            }
        }

        private void ModifyClosedDrawing(string drawing)
        {
            Database xrefDb = new Database(false, true);

            var layerList = new List<string>();

            try
            {
                xrefDb.ReadDwgFile(drawing, FileShare.ReadWrite, false, "");

                using (Transaction trx = xrefDb.TransactionManager.StartTransaction())
                {
                    var layerTable = trx.GetObject(xrefDb.LayerTableId, OpenMode.ForWrite) as LayerTable;

                    foreach (ObjectId acObjId in layerTable)
                    {
                        // Modify layer
                        LayerTableRecord LayerRecord = trx.GetObject(acObjId, OpenMode.ForWrite) as LayerTableRecord;
                        modifyLayer(LayerRecord, propertyList);
                        layerList.Add(LayerRecord.Name);
                    }

                    trx.Commit();
                    trx.Dispose();
                }

                xrefDb.CloseInput(true);
                xrefDb.SaveAs(drawing, false, DwgVersion.Current, null);

                successfullDrawings.Add(drawing);
                File.WriteAllLines(@"C:\Temp\LayerList.txt", layerList.ToArray());
            }
            catch (Exception)
            {
                failedDrawings.Add(drawing);
            }
        }

        private List<string> getDrawingList()
        {
            var fileDiag = new OpenFileDialog();
            fileDiag.Multiselect = true;
            fileDiag.Filter = "*.dwg | *.dwg";
            fileDiag.ShowDialog();

            return fileDiag.FileNames.ToList();
        }

        private void modifyLayer(LayerTableRecord Layer, List<LayerFilter> propertyList)
        {
            totalLayers++;
            var layerModified = false;
            foreach (var property in propertyList)
            {
                if (LayerComparer.IsLike(property.LayerName, Layer.Name))
                {
                    if (!string.IsNullOrEmpty(property.Color))
                    {
                        var acColor = Autodesk.AutoCAD.Colors.Color.FromColorIndex(Autodesk.AutoCAD.Colors.ColorMethod.ByAci, Convert.ToInt16(property.Color));

                        if (Layer.Color != acColor)
                        {
                            Layer.Color = acColor;
                            layerModified = true;
                        }
                    }

                    if (property.Freeze && !Layer.IsFrozen)
                    {
                        Layer.IsFrozen = true;
                        layerModified = true;
                    }

                    if (property.Thaw && Layer.IsFrozen)
                    {
                        Layer.IsFrozen = false;
                        layerModified = true;
                    }

                    if (property.LayerOff && !Layer.IsOff)
                    {
                        Layer.IsOff = true;
                        layerModified = true;
                    }

                    if (property.LayerOn && Layer.IsOff)
                    {
                        Layer.IsOff = false;
                        layerModified = true;
                    }
                }
            }

            if (layerModified)
            {
                layersModified++;
            }
        }
    }
}
