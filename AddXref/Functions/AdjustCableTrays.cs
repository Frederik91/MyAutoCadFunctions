using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MAGICOMSRVLib;
using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.EditorInput;
using Autodesk.AutoCAD.Geometry;
using Autodesk.AutoCAD.Colors;

namespace XrefManager.Functions
{
    class AdjustCableTrays
    {
        MagiCAD magiClass = new MagiCAD();
        Document acDoc = Application.DocumentManager.MdiActiveDocument;
        Database acCurDb = Application.DocumentManager.MdiActiveDocument.Database;

        public void AdjustCableTrays_bottom()
        {
            acDoc.LockDocument();
            var garbageLayer = "MAGI_GARBAGE";
            GarbageLayer(garbageLayer);
                        
            // Start a transaction
            using (Transaction acTrans = acCurDb.TransactionManager.StartTransaction())
            {


                // Request for objects to be selected in the drawing area
                PromptSelectionResult acSSPrompt = acDoc.Editor.GetSelection();

                // If the prompt status is OK, objects were selected
                if (acSSPrompt.Status == PromptStatus.OK)
                {
                    SelectionSet acSSet = acSSPrompt.Value;

                    // Open the Block table for read
                    BlockTable acBlkTbl;
                    acBlkTbl = acTrans.GetObject(acCurDb.BlockTableId, OpenMode.ForRead) as BlockTable;

                    // Open the Block table record Model space for write
                    BlockTableRecord acBlkTblRec;
                    acBlkTblRec = acTrans.GetObject(acBlkTbl[BlockTableRecord.ModelSpace], OpenMode.ForWrite) as BlockTableRecord;


                    foreach (SelectedObject acSSObj in acSSet)
                    {
                        if (acSSObj != null)
                        {
                            Entity acEnt = acTrans.GetObject(acSSObj.ObjectId, OpenMode.ForRead) as Entity;

                            OpenLayerIfLocked(acEnt.Layer);

                            if (acEnt != null)
                            {
                                acEnt = acTrans.GetObject(acSSObj.ObjectId, OpenMode.ForWrite) as Entity;

                                var handleID = acEnt.Handle.ToString();
                                var Startpoint = GetCableTrayStartpoint(handleID);
                                var Endpoint = GetCableTrayEndpoint(handleID);

                                if ((Startpoint.Z != Endpoint.Z) && (Startpoint.Z < 1050 || Startpoint.Z < 1050))
                                {
                                    var point = new Point3d();

                                    if (Startpoint.Z < Endpoint.Z)
                                    {
                                        point = Startpoint;
                                    }
                                    else
                                    {
                                        point = Endpoint;
                                    }

                                    acDoc.Editor.WriteMessage("Bottom height: " + point.Z + "\n");
                                    var vector = new Vector3d(0, 0, 1050 - point.Z);
                                    SetCableTrayBottomHeight(acEnt, vector, point);

                                    // Create a circle that is at 2,3 with a radius of 4.25
                                    using (Circle acCirc = new Circle())
                                    {
                                        acCirc.Center = point;
                                        acCirc.Radius = 500;

                                        // Add the new object to the block table record and the transaction
                                        acBlkTblRec.AppendEntity(acCirc);
                                        acTrans.AddNewlyCreatedDBObject(acCirc, true);

                                        acCirc.Layer = garbageLayer;
                                    }
                                }
                            }
                        }
                    }

                    // Save the new object to the database
                    acTrans.Commit();                    
                }
                // Dispose of the transaction
                acTrans.Dispose();
            }
        }

        private Point3d GetCableTrayStartpoint(string partHandle)
        {
            magiClass.getPartAttPoint(partHandle, "/Part/Startpoint/WCS", out double x_start, out double y_start, out double z_start);
            var Startpoint = new Point3d(x_start, y_start, z_start);

            return Startpoint;
        }

        private Point3d GetCableTrayEndpoint(string partHandle)
        {
            magiClass.getPartAttPoint(partHandle, "/Part/Endpoint/WCS", out double x_end, out double y_end, out double z_end);
            var EndPoint = new Point3d(x_end, y_end, z_end);

            return EndPoint;
        }

        private void SetCableTrayBottomHeight(Entity ent, Vector3d offset, Point3d gripPoint)
        {
            GripDataCollection grips = new GripDataCollection();
            GripDataCollection updateGrip = new GripDataCollection();
            double curViewUnitSize = 0;
            int gripSize = 0;
            Vector3d curViewDir = acDoc.Editor.GetCurrentView().ViewDirection;
            GetGripPointsFlags bitFlags = GetGripPointsFlags.GripPointsOnly;
            ent.GetGripPoints(grips, curViewUnitSize, gripSize, curViewDir, bitFlags);
            foreach (GripData grip in grips)
            {
                if (grip.GripPoint == gripPoint)
                {
                    updateGrip.Add(grip);
                }
            }
            ent.MoveGripPointsAt(updateGrip, offset, MoveGripPointsFlags.Polar);              
        }

        private void GarbageLayer(string layName)
        {
            using (Transaction tr = acCurDb.TransactionManager.StartTransaction())
            {
                // Get the layer table from the drawing

                LayerTable lt = (LayerTable)tr.GetObject(acCurDb.LayerTableId, OpenMode.ForRead);

                // Check if layer exists

                if (lt.Has(layName)) return;

                // Create our new layer table record...

                LayerTableRecord ltr = new LayerTableRecord()
                {

                    // ... and set its properties

                    Name = layName,
                    Color = Color.FromColorIndex(ColorMethod.ByAci, 2)
                };

                // Add the new layer to the layer table

                lt.UpgradeOpen();
                ObjectId ltId = lt.Add(ltr);
                tr.AddNewlyCreatedDBObject(ltr, true);

                // Set the layer to be current for this drawing

                acCurDb.Clayer = ltId;

                // Commit the transaction

                tr.Commit();
            }      
        }

        public void OpenLayerIfLocked(string layName)
        {
            using (Transaction tr = acCurDb.TransactionManager.StartTransaction())
            {
                LayerTable lt = (LayerTable)tr.GetObject(acCurDb.LayerTableId, OpenMode.ForRead);               

                if (!lt.Has(layName)) return;

                // Create our new layer table record...

                LayerTableRecord ltr = tr.GetObject(lt[layName], OpenMode.ForWrite) as LayerTableRecord;

                ltr.IsLocked = false;               

                tr.Commit();
            }
        }
    }
}
