using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.DatabaseServices;
using Microsoft.VisualBasic.CompilerServices;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace XrefManager
{
    public class LayerUpdate
    {
        private List<LayerProperties> propertyList = new List<LayerProperties>();
        private int layersModified = 0;
        private int totalLayers = 0;
        private List<string> successfullDrawings = new List<string>();
        private List<string> failedDrawings = new List<string>();
        private List<string> drawingList = new List<string>();

        public void UpdateLayersThisDrawing(string configPath)
        {
            propertyList = ReadLayerPropertyFile(configPath);

            Document document = Application.DocumentManager.MdiActiveDocument;

            ModifyOpenDrawing(document);

            document.Editor.WriteMessage("\nModified " + layersModified + " out of " + totalLayers + " layers");
        }

        public void UpdateLayers()
        {
            var fileDiag = new OpenFileDialog();
            fileDiag.Filter = "*.txt | *.txt";
            fileDiag.ShowDialog();
            if (fileDiag.CheckFileExists)
            {
                propertyList = ReadLayerPropertyFile(fileDiag.FileName);
            }

            drawingList = getDrawingList();

            ChangeLayersOnDrawing(propertyList, drawingList);
        }

        public void ChangeLayersOnDrawing(List<LayerProperties> propList, List<string> drawingList)
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

        public List<LayerProperties> ReadLayerPropertyFile(string filePath)
        {
            var layerPropertyList = new List<LayerProperties>();


            var reader = new StreamReader(filePath, Encoding.GetEncoding("iso-8859-1"));

            while (!reader.EndOfStream)
            {
                var lineArray = reader.ReadLine().Split('\t').ToList();

                var freezeBool = false;
                var thawBool = false;
                var layerOnBool = false;
                var layerOffBool = false;

                for (int i = lineArray.Count() - 1; i < 5; i++)
                {
                    lineArray.Add("");
                }


                if (!string.IsNullOrEmpty(lineArray[1]))
                {
                    freezeBool = true;
                }

                if (!string.IsNullOrEmpty(lineArray[2]))
                {
                    thawBool = true;
                }

                if (!string.IsNullOrEmpty(lineArray[4]))
                {
                    layerOnBool = true;
                }

                if (!string.IsNullOrEmpty(lineArray[5]))
                {
                    layerOffBool = true;
                }

                //var correctedLayerName = lineArray[0].Replace(" ", "*");

                layerPropertyList.Add(new LayerProperties
                {
                    Name = lineArray[0],
                    freeze = freezeBool,
                    thaw = thawBool,
                    Color = lineArray[3],
                    layerOn = layerOnBool,
                    layerOff = layerOffBool
                });
            }


            layerPropertyList.RemoveAt(0);

            return layerPropertyList;
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

        private void modifyLayer(LayerTableRecord Layer, List<LayerProperties> propertyList)
        {
            totalLayers++;
            var layerModified = false;
            foreach (var property in propertyList)
            {
                if (LayerComparer.IsLike(property.Name, Layer.Name))
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

                    if (property.freeze && !Layer.IsFrozen)
                    {
                        Layer.IsFrozen = true;
                        layerModified = true;
                    }

                    if (property.thaw && Layer.IsFrozen)
                    {
                        Layer.IsFrozen = false;
                        layerModified = true;
                    }

                    if (property.layerOff && !Layer.IsOff)
                    {
                        Layer.IsOff = true;
                        layerModified = true;
                    }

                    if (property.layerOn && Layer.IsOff)
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
