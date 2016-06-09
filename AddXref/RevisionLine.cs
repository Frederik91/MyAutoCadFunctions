using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.DatabaseServices;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XrefManager
{
    class RevisionLine
    {

        public void addRevisionLine(List<string> drawingList, string blockName, string attributeTag, string oldString, string newString)
        {
            foreach (var drawing in drawingList)
            {
                var openDocs = Application.DocumentManager;

                if (DrawingIsOpen(drawing))
                {
                    foreach (Document openDoc in openDocs)
                    {
                        if (openDoc.Name == drawing)
                        {
                            using (DocumentLock docloc = openDoc.LockDocument())
                            {
                                using (Transaction trx = openDoc.TransactionManager.StartTransaction())
                                {
                                    ChangeAttributeValue(trx, openDoc.Database, blockName, attributeTag, oldString, newString);
                                    trx.Commit();
                                    trx.Dispose();
                                }
                            }
                        }
                    }
                }
                else
                {
                    Database xrefDb = new Database(false, true);

                    xrefDb.ReadDwgFile(drawing, FileShare.ReadWrite, false, "");

                    try
                    {
                        using (Transaction trx = xrefDb.TransactionManager.StartTransaction())
                        {
                            ChangeAttributeValue(trx, xrefDb, blockName, attributeTag, oldString, newString);
                            trx.Commit();
                            trx.Dispose();
                        }
                    }
                    catch (Exception) { }
                    xrefDb.CloseInput(true);
                    xrefDb.SaveAs(drawing, false, DwgVersion.Current, null);
                }

            }
        }

        private bool DrawingIsOpen(string drawing)
        {
            var openDocs = Application.DocumentManager;

            foreach (Document openDoc in openDocs)
            {
                if (openDoc.Name == drawing)
                {
                    return true;
                }
            }
            return false;
        }

        private void ChangeAttributeValue(Transaction trx, Database db, string blockName, string attributeTag, string oldString, string newString)
        {
            ObjectId psId;
            BlockTable bt = (BlockTable)trx.GetObject(db.BlockTableId, OpenMode.ForRead);
            psId = bt[BlockTableRecord.PaperSpace];

            BlockTableRecord btr = (BlockTableRecord)trx.GetObject(psId, OpenMode.ForRead);

            foreach (var entId in btr)
            {
                Entity ent = trx.GetObject(entId, OpenMode.ForRead) as Entity;
                if (ent != null)
                {
                    BlockReference br = ent as BlockReference;
                    if (br != null)
                    {
                        BlockTableRecord bd = (BlockTableRecord)trx.GetObject(br.BlockTableRecord, OpenMode.ForRead);

                        // ... to see whether it's a block with the name we're after

                        if (bd.Name.ToUpper() == blockName.ToUpper())
                        {
                            // Check each of the attributes...

                            foreach (ObjectId arId in br.AttributeCollection)
                            {
                                DBObject obj = trx.GetObject(arId, OpenMode.ForRead);
                                AttributeReference ar = obj as AttributeReference;
                                if (ar != null)
                                {
                                    // ... to see whether it has
                                    // the tag we're after

                                    if (ar.Tag.ToUpper() == attributeTag.ToUpper())
                                    {
                                        // check if attribute has correct value
                                        if (ar.TextString == oldString)
                                        {
                                            // If so, update the value
                                            ar.UpgradeOpen();
                                            ar.TextString = newString;
                                            ar.DowngradeOpen();
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }

        }
    }
}

