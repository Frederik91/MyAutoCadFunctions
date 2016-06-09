using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.EditorInput;
using Autodesk.AutoCAD.Runtime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingManagerDll.Methods
{
    class AttributeManager
    {

        [CommandMethod("UPDATEATTRIBUTESINDATABASE")]
        public void UPDATEATTRIBUTESINDATABASE(
          string blockName,
          string attbName,
          string attbValue
        )
        {
            Document doc = Application.DocumentManager.MdiActiveDocument;
            Editor ed = doc.Editor;
            Database db = doc.Database;
            doc.LockDocument();

            // Get the IDs of the spaces we want to process
            // and simply call a function to process each

            ObjectId msId, psId;
            Transaction tr =
              db.TransactionManager.StartTransaction();
            using (tr)
            {
                BlockTable bt =
                  (BlockTable)tr.GetObject(
                    db.BlockTableId,
                    OpenMode.ForRead
                  );
                msId =
                  bt[BlockTableRecord.ModelSpace];
                psId =
                  bt[BlockTableRecord.PaperSpace];

                // Not needed, but quicker than aborting
                tr.Commit();
            }
            //int msCount =
            //  UPDATEATTRIBUTESINBLOCK(
            //    msId,
            //    blockName,
            //    attbName,
            //    attbValue
            //  );
            int psCount =
              UPDATEATTRIBUTESINBLOCK(
                psId,
                blockName,
                attbName,
                attbValue
              );
            ed.Regen();

            // Display the results

            ed.WriteMessage(
              "\nProcessing file: " + db.Filename
            );
            //ed.WriteMessage(
            //  "\nUpdated {0} instance{1} of " +
            //  "attribute {2} in the modelspace.",
            //  msCount,
            //  msCount == 1 ? "" : "s",
            //  attbName
            //);
            ed.WriteMessage(
              "\nUpdated {0} instance{1} of " +
              "attribute {2} in the default paperspace.",
              psCount,
              psCount == 1 ? "" : "s",
              attbName
            );
        }

        [CommandMethod("UPDATEATTRIBUTESINBLOCK")]
        public int UPDATEATTRIBUTESINBLOCK(
          ObjectId btrId,
          string blockName,
          string attbName,
          string attbValue
        )
        {
            // Will return the number of attributes modified

            int changedCount = 0;
            Document doc = Application.DocumentManager.MdiActiveDocument;
            Database db = doc.Database;
            Editor ed = doc.Editor;

            Transaction tr =
              doc.TransactionManager.StartTransaction();
            using (tr)
            {
                BlockTableRecord btr =
                  (BlockTableRecord)tr.GetObject(
                    btrId,
                    OpenMode.ForRead
                  );

                // Test each entity in the container...

                foreach (ObjectId entId in btr)
                {
                    Entity ent =
                      tr.GetObject(entId, OpenMode.ForRead)
                      as Entity;

                    if (ent != null)
                    {
                        BlockReference br = ent as BlockReference;
                        if (br != null)
                        {
                            BlockTableRecord bd =
                              (BlockTableRecord)tr.GetObject(
                                br.BlockTableRecord,
                                OpenMode.ForRead
                            );

                            // ... to see whether it's a block with
                            // the name we're after

                            if (bd.Name.ToUpper() == blockName)
                            {

                                // Check each of the attributes...

                                foreach (
                                  ObjectId arId in br.AttributeCollection
                                )
                                {
                                    DBObject obj =
                                      tr.GetObject(
                                        arId,
                                        OpenMode.ForRead
                                      );
                                    AttributeReference ar =
                                      obj as AttributeReference;
                                    if (ar != null)
                                    {
                                        // ... to see whether it has
                                        // the tag we're after

                                        if (ar.Tag.ToUpper() == attbName)
                                        {
                                            // If so, update the value
                                            // and increment the counter

                                            ar.UpgradeOpen();
                                            ar.TextString = attbValue;
                                            ar.DowngradeOpen();
                                            changedCount++;
                                        }
                                    }
                                }
                            }

                            // Recurse for nested blocks
                            changedCount +=
                              UPDATEATTRIBUTESINBLOCK(
                                br.BlockTableRecord,
                                blockName,
                                attbName,
                                attbValue
                              );
                        }
                    }
                }
                tr.Commit();
            }
            return changedCount;
        }


        [CommandMethod("CHECKATTRIBUTEVALUE")]
        public string CHECKATTRIBUTEVALUE(
          string blockName,
          string attbName
        )
        {
            Document doc = Application.DocumentManager.MdiActiveDocument;
            Editor ed = doc.Editor;
            Database db = doc.Database;
            doc.LockDocument();
            string attributeValue = "";

            // Get the IDs of the spaces we want to process
            // and simply call a function to process each

            ObjectId psId;
            Transaction tr1 =
              db.TransactionManager.StartTransaction();
            using (tr1)
            {
                BlockTable bt =
                  (BlockTable)tr1.GetObject(
                    db.BlockTableId,
                    OpenMode.ForRead
                  );
                psId =
                  bt[BlockTableRecord.PaperSpace];

                // Not needed, but quicker than aborting
                tr1.Commit();
            }


            // Will return the value of the named attribute.

            Transaction tr2 =
              doc.TransactionManager.StartTransaction();
            using (tr2)
            {
                BlockTableRecord btr =
                  (BlockTableRecord)tr2.GetObject(
                    psId,
                    OpenMode.ForRead
                  );

                // Test each entity in the container...

                foreach (ObjectId entId in btr)
                {
                    Entity ent =
                      tr2.GetObject(entId, OpenMode.ForRead)
                      as Entity;

                    if (ent != null)
                    {
                        //////////attributeValue = "1";

                        BlockReference br = ent as BlockReference;
                        if (br != null)
                        {
                            ////////////attributeValue = "2";
                            BlockTableRecord bd =
                              (BlockTableRecord)tr2.GetObject(
                                br.BlockTableRecord,
                                OpenMode.ForRead
                            );

                            // ... to see whether it's a block with
                            // the name we're after

                            ////////////attributeValue = bd.Name.ToUpper() + " = " + blockName;

                            if (bd.Name.ToUpper() == blockName)
                            {
                                // Check each of the attributes...

                                foreach (ObjectId arId in br.AttributeCollection)
                                {
                                    DBObject obj = tr2.GetObject(arId, OpenMode.ForRead);
                                    AttributeReference ar =
                                      obj as AttributeReference;
                                    if (ar != null)
                                    {
                                        //attributeValue = ar.Tag.ToUpper() + " = " + attbName;
                                        // ... to see whether it has
                                        // the tag we're after

                                        if (ar.Tag.ToUpper() == attbName)
                                        {
                                            ////////////attributeValue = "5";
                                            // If so, update the value
                                            // and increment the counter

                                            ar.UpgradeOpen();
                                            attributeValue = ar.TextString;
                                            ar.DowngradeOpen();
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                tr2.Commit();
            }
            return attributeValue;
        }
    }
}
