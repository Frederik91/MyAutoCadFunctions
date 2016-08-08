using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.EditorInput;
using LayerConfigEditor.Workers;
using LayerFilterFromSelectedObjectWindow;
using System.IO;
using XrefManager.Workers;

namespace XrefManager.Functions
{
    public class GetLayerFromObject
    {
        private void ObjectLayerToConfigFile(string layer)
        {
            if (!string.IsNullOrEmpty(layer))
            {
                var window = new MainWindow();
                window.MainViewModel.MapLayerStringToLayerFilter(layer);
                window.ShowDialog();

                if (window.MainViewModel.addLayerFilter)
                {
                    var projectFileLocator = new LocateFileProject();
                    var configFilePath = projectFileLocator.returnConfigFilePath();

                    if (string.IsNullOrEmpty(configFilePath))
                    {
                        configFilePath = connectDrawingToConfigFile(configFilePath);
                        if (string.IsNullOrEmpty(configFilePath))
                        {
                            return;
                        }
                    }

                    var reader = new ConfigFileReader();
                    var writer = new ConfigFileWriter();

                    var layerFilterList = reader.readConfigFile(configFilePath);

                    foreach (var layerFilter in window.MainViewModel.NewLayerFilterList)
                    {
                        layerFilterList.Add(layerFilter);
                    }

                    writer.writeConfig(configFilePath, layerFilterList);
                }
            }
        }

        private string connectDrawingToConfigFile(string configPath)
        {
            var res = System.Windows.Forms.MessageBox.Show("Drawing is not connected to a project. Do you want to create a new project?", "Drawing not connected to project", System.Windows.Forms.MessageBoxButtons.YesNo);
            if (res == System.Windows.Forms.DialogResult.Yes)
            {
                using (var form = new XrefManager.Forms.UpdateLayerForm())
                {
                    form.ShowDialog();
                    if (string.IsNullOrEmpty(form.configPath))
                    {
                        return null;
                    }
                    configPath = form.configPath;
                }
            }
            return configPath;
        }

        public void SelectXrefObjectReturnLayer()
        {
            Editor ed = Application.DocumentManager.MdiActiveDocument.Editor;
            Database db = Application.DocumentManager.MdiActiveDocument.Database;

            // start the transaction
            using (Transaction trans = db.TransactionManager.StartTransaction())
            {
                // select an entity
                PromptNestedEntityOptions pr = new PromptNestedEntityOptions("Select object: \n");
                PromptEntityResult res = ed.GetNestedEntity(pr);
                if (res.Status != PromptStatus.OK)
                {
                    ed.WriteMessage("No object selected\n");
                    return;
                }
                var ent = trans.GetObject(res.ObjectId, OpenMode.ForRead) as Entity;
                ObjectLayerToConfigFile(ent.Layer);
            }
        }

        public void SelectObjectReturnLayer()
        {
            Editor ed = Application.DocumentManager.MdiActiveDocument.Editor;
            Database db = Application.DocumentManager.MdiActiveDocument.Database;

            // start the transaction
            using (Transaction trans = db.TransactionManager.StartTransaction())
            {
                // select an entity
                PromptEntityOptions pr = new PromptEntityOptions("Select object: \n");
                PromptEntityResult res = ed.GetEntity(pr);
                if (res.Status != PromptStatus.OK)
                {
                    ed.WriteMessage("No object selected\n");
                    return;
                }
                var ent = trans.GetObject(res.ObjectId, OpenMode.ForRead) as Entity;
                ObjectLayerToConfigFile(ent.Layer);
            }
        }


        private string getLayerFromObjectInXref(Database db, Transaction trans, BlockTableRecord blockDef, PromptEntityResult res)
        {
            var layerName = string.Empty;

            // open the xref database
            Database xRefDB = new Database(false, true);
            xRefDB.ReadDwgFile(blockDef.PathName, System.IO.FileShare.Read, false, string.Empty);

            using (Transaction xRefTrans = xRefDB.TransactionManager.StartTransaction())
            {
                // open the block definition and its model space
                BlockTable xRefBT = xRefTrans.GetObject(xRefDB.BlockTableId, OpenMode.ForRead) as BlockTable;
                BlockTableRecord xRefBTR = xRefTrans.GetObject(xRefBT[BlockTableRecord.ModelSpace], OpenMode.ForRead) as BlockTableRecord;

                // iterate through entities on the xref model space
                foreach (ObjectId xRefEntId in xRefBTR)
                {
                    Entity ent = xRefTrans.GetObject(xRefEntId, OpenMode.ForRead) as Entity;

                    // get the drawing name
                    string dwgName = Path.GetFileNameWithoutExtension(xRefDB.OriginalFileName);
                    // now get the layer name
                    layerName = dwgName + "|" + ent.Layer;

                }
            }

            return layerName;
        }
    }
}
