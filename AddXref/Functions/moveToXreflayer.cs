using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.Colors;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.EditorInput;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XrefManager
{
    public class moveToXreflayer
    {
        private Document doc = Application.DocumentManager.MdiActiveDocument;
        private Database db = Application.DocumentManager.MdiActiveDocument.Database;
        private Editor ed = Application.DocumentManager.MdiActiveDocument.Editor;

        public void moveXref()
        {
            var xRefLayer = MakeSureXrefLayerExist();
            MoveXrefToXrefLayer(xRefLayer);
        }

        private LayerTableRecord MakeSureXrefLayerExist()
        {
            string xRefLayName = "Xref";
            LayerTableRecord xRefLayer;

            using (DocumentLock docloc = doc.LockDocument())
            {
                using (Transaction trx = doc.TransactionManager.StartTransaction())
                {
                    var layerTable = trx.GetObject(doc.Database.LayerTableId, OpenMode.ForRead) as LayerTable;
                    var currentLayerObj = doc.Database.Clayer;

                    foreach (ObjectId acObjId in layerTable)
                    {
                        LayerTableRecord LayerRecord = acObjId.GetObject(OpenMode.ForWrite) as LayerTableRecord;

                        foreach (var layObj in layerTable)
                        {
                            LayerTableRecord lay = layObj.GetObject(OpenMode.ForWrite) as LayerTableRecord;

                            if (lay.Name == xRefLayName)
                            {
                                return lay;
                            }
                        }

                    }

                    // Create our new layer table record...

                    xRefLayer = new LayerTableRecord();

                    // ... and set its properties

                    xRefLayer.Name = xRefLayName;
                    xRefLayer.Color = Color.FromColorIndex(ColorMethod.ByAci, 8);

                    // Add the new layer to the layer table

                    layerTable.UpgradeOpen();
                    ObjectId ltId = layerTable.Add(xRefLayer);
                    trx.AddNewlyCreatedDBObject(xRefLayer, true);

                    trx.Commit();
                    trx.Dispose();
                }
            }
            return xRefLayer;
        }

        private void MoveXrefToXrefLayer(LayerTableRecord xRefLayer)
        {
            using (DocumentLock docloc = doc.LockDocument())
            {
                Transaction tr = db.TransactionManager.StartTransaction();
                using (tr)
                {
                    XrefGraph xg = db.GetHostDwgXrefGraph(true);

                    for (int i = 0; i < xg.RootNode.NumOut; i++)
                    {
                        System.Windows.MessageBox.Show("Handling xref " + (i + 1) + " out of" + (xg.RootNode.NumOut + 1));

                        var child = xg.RootNode.Out(i) as XrefGraphNode;
                        if (child.XrefStatus == XrefStatus.Resolved)
                        {
                            System.Windows.MessageBox.Show("Changing layer: " + child.Name);                         

                            BlockTableRecord xrefBt = tr.GetObject(child.BlockTableRecordId, OpenMode.ForRead) as BlockTableRecord;

                            

                            ObjectId lid = xRefLayer.Id;
                            Entity ent = (Entity)tr.GetObject(xrefBt.Id, OpenMode.ForWrite);
                            ent.LayerId = lid;
                        }
                    }

                    tr.Commit();
                    tr.Dispose();
                }
            }
        }
    }

}
