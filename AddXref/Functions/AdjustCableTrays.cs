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

namespace XrefManager.Functions
{
    class AdjustCableTrays
    {
        MagiCAD magiClass = new MagiCAD();

        public void AdjustCableTrays_bottom()
        {
            // Get the current document and database
            Document acDoc = Application.DocumentManager.MdiActiveDocument;
            Database acCurDb = acDoc.Database;

            // Start a transaction
            using (Transaction acTrans = acCurDb.TransactionManager.StartTransaction())
            {
                // Request for objects to be selected in the drawing area
                PromptSelectionResult acSSPrompt = acDoc.Editor.GetSelection();

                // If the prompt status is OK, objects were selected
                if (acSSPrompt.Status == PromptStatus.OK)
                {
                    SelectionSet acSSet = acSSPrompt.Value;

                    foreach (SelectedObject acSSObj in acSSet)
                    {
                        if (acSSObj != null)
                        {
                            Entity acEnt = acTrans.GetObject(acSSObj.ObjectId, OpenMode.ForRead) as Entity;

                            if (acEnt != null)
                            {                             
                                var handleID = acEnt.Handle.ToString();

                                acDoc.Editor.WriteMessage("handleID: " + handleID + "\n");

                                var height = GetCableTrayBottomHeight(handleID);
                                acDoc.Editor.WriteMessage("Bottom height: " + height + "\n");                                

                                if (height < 200)
                                {
                                    var vector = new Vector3d(0, 0, 1050-height);
                                    var point = GetCableTrayStartPoint(handleID);
                                    SetCableTrayBottomHeight(acEnt, vector, point);
                                }
                            }
                        }
                    }

                    // Save the new object to the database
                    acTrans.Dispose();
                }

                // Dispose of the transaction
            }
        }

        private double GetCableTrayBottomHeight(string partHandle)
        {
            double height;
            var x = magiClass.getPartAttDouble(partHandle, "/Part/Elevation/Bottom/FCS", out height);            

            return height;
        }

        private Point3d GetCableTrayStartPoint(string partHandle)
        {
            double x;
            double y;
            double z;
            magiClass.getPartAttPoint(partHandle, "/Part/Startpoint/WCS", out x, out y, out z);

            var point = new Point3d(x, y, z);

            return point;
        }

        private void SetCableTrayBottomHeight(Entity ent, Vector3d offset, Point3d gripPoint)
        {
            Document doc = Autodesk.AutoCAD.ApplicationServices.Application.DocumentManager.MdiActiveDocument;
            Database db = doc.Database;
            Transaction tr = db.TransactionManager.StartTransaction();
            using (tr)
            {
                var br = ent as BlockReference;
                if (br != null)
                {
                    GripDataCollection grips = new GripDataCollection();
                    GripDataCollection updateGrip = new GripDataCollection();
                    double curViewUnitSize = 0;
                    int gripSize = 0;
                    Vector3d curViewDir = doc.Editor.GetCurrentView().ViewDirection;
                    GetGripPointsFlags bitFlags = GetGripPointsFlags.GripPointsOnly;
                    br.GetGripPoints(grips, curViewUnitSize, gripSize, curViewDir, bitFlags);
                    foreach (GripData grip in grips)
                    {
                        if (grip.GripPoint == gripPoint)
                        {
                            updateGrip.Add(grip);
                        }
                    }
                    br.MoveGripPointsAt(updateGrip, offset, MoveGripPointsFlags.Polar);
                }
            }
        }
    }
}
