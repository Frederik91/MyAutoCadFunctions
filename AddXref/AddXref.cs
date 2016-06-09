using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.Colors;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.Geometry;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XrefManager
{
    class AddXref
    {
        public void addXref()
        {
            var UX = new UnloadXref();

            var xRefFile = UX.getFileToXref();
            if (string.IsNullOrEmpty(xRefFile))
            {
                return;
            }

            var DrawingList = UX.getDrawingList();
            if (DrawingList.Count == 0 || DrawingList == null)
            {
                return;
            }

            Document Doc = Application.DocumentManager.MdiActiveDocument;


            foreach (var drawing in DrawingList)
            {


                Database xrefDb = new Database(false, true);
                xrefDb.ReadDwgFile(drawing, FileShare.ReadWrite, false, "");

                using (Transaction trx = xrefDb.TransactionManager.StartTransaction())
                {

                    //db.ResolveXrefs(true, false);         

                    xrefDb = createLayer(trx, xrefDb);

                    BlockTable xrefBt = xrefDb.BlockTableId.GetObject(OpenMode.ForRead) as BlockTable;
                    BlockTableRecord btrMs = xrefBt[BlockTableRecord.ModelSpace].GetObject(OpenMode.ForWrite) as BlockTableRecord;


                    ObjectId xrefObjId = xrefDb.OverlayXref(xRefFile, Path.GetFileNameWithoutExtension(xRefFile));


                    BlockReference bref = new BlockReference(Point3d.Origin, xrefObjId);

                    btrMs.AppendEntity(bref);
                    trx.AddNewlyCreatedDBObject(bref, true);

                    xrefDb.CloseInput(true);
                    xrefDb.SaveAs(drawing, false, DwgVersion.Current, null);

                    trx.Commit();
                }
            }

            Doc.Editor.WriteMessage("Filene er xrefet");
        }

        public List<string> addXrefSpecialized()
        {
            Document Doc = Application.DocumentManager.MdiActiveDocument;
            int successfullDrawings = 0;

            var UX = new UnloadXref();

            var xRefFiles = getFilesToXrefList();
            if (xRefFiles.Count == 0 || xRefFiles == null)
            {
                return null;
            }

            var DrawingList = UX.getDrawingList();
            if (DrawingList.Count == 0 || DrawingList == null)
            {
                return null;
            }

            foreach (var drawing in DrawingList)
            {
                List<string> MatchingxRefFilesList = new List<string>();
                var drawingFloor = drawing.Split('-')[2].Trim();
                foreach (var file in xRefFiles)
                {
                    var fileName = Path.GetFileNameWithoutExtension(file);
                    var fileFloor = fileName.Split('-')[1].Trim();

                    if (fileFloor == drawingFloor)
                    {
                        MatchingxRefFilesList.Add(file);
                    }
                }

                if (MatchingxRefFilesList.Count == 0)
                {
                    continue;
                }

                try
                {
                    Database xrefDb = new Database(false, true);
                    xrefDb.ReadDwgFile(drawing, FileShare.ReadWrite, false, "");


                    using (Transaction trx = xrefDb.TransactionManager.StartTransaction())
                    {
                        Doc.Editor.WriteMessage("Jobber med fil: " + Path.GetFileNameWithoutExtension(drawing));

                        xrefDb = createLayer(trx, xrefDb);

                        BlockTable xrefBt = xrefDb.BlockTableId.GetObject(OpenMode.ForRead) as BlockTable;
                        BlockTableRecord btrMs = xrefBt[BlockTableRecord.ModelSpace].GetObject(OpenMode.ForWrite) as BlockTableRecord;

                        foreach (var xref in MatchingxRefFilesList)
                        {
                            ObjectId xrefObjId = xrefDb.OverlayXref(xref, Path.GetFileNameWithoutExtension(xref));

                            BlockReference bref = new BlockReference(Point3d.Origin, xrefObjId);

                            btrMs.AppendEntity(bref);
                            trx.AddNewlyCreatedDBObject(bref, true);

                        }

                        xrefDb.CloseInput(true);
                        xrefDb.SaveAs(drawing, false, DwgVersion.Current, null);

                        trx.Commit();
                        successfullDrawings++;
                    }

                }
                catch (System.Exception)
                {

                }
                Doc.Editor.WriteMessage("\nAdded xref on " + successfullDrawings + " of " + DrawingList.Count);
            }

            return DrawingList;
        }

        private List<string> getFilesToXrefList()
        {
            var FD = new OpenFileDialog();

            FD.Filter = "AutoCAD Files | *.dwg";
            FD.Multiselect = true;
            FD.ShowDialog();

            return FD.FileNames.ToList();
        }

        private Database createLayer(Transaction tr, Database db)
        {

            LayerTable lt = (LayerTable)tr.GetObject(db.LayerTableId, OpenMode.ForRead);


            // A variable for the layer name

            string layName = "XREF";

            // Check the layer name, to see whether it's
            // already in use


            // Validate the provided symbol table name

            SymbolUtilityServices.ValidateSymbolName(layName, false
            );

            // Only set the layer name if it isn't in use

            if (!lt.Has(layName))
            {
                // Create our new layer table record...

                LayerTableRecord ltr = new LayerTableRecord();

                // ... and set its properties

                ltr.Name = layName;
                ltr.Color = Color.FromColorIndex(ColorMethod.ByAci, 8);

                // Add the new layer to the layer table

                lt.UpgradeOpen();
                ObjectId ltId = lt.Add(ltr);
                tr.AddNewlyCreatedDBObject(ltr, true);


                // Set the layer to be current for this drawing

                db.Clayer = ltId;
            }
            else
            {
                db.Clayer = lt[layName];
            }

            return db;
        }
    }
}
