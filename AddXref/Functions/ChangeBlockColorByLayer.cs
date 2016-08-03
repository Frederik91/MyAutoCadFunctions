using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.EditorInput;
using Autodesk.AutoCAD.Windows;
using Autodesk.AutoCAD.Colors;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Win32;
using System.IO;
using System;

namespace XrefManager
{
    class ChangeBlockColorByLayer
    {
        public void ChangeColorsBlocksAllDrawings()
        {
            foreach (var drawing in getDrawingList())
            {
                ModifyClosedDrawing(drawing);
            }
        }

        private List<string> getDrawingList()
        {
            var fileDiag = new Microsoft.Win32.OpenFileDialog();
            fileDiag.Multiselect = true;
            fileDiag.Filter = "*.dwg | *.dwg";
            fileDiag.ShowDialog();

            return fileDiag.FileNames.ToList();
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
                    GetAllBlocksAndChangeColor(trx, xrefDb);

                    trx.Commit();
                }

                xrefDb.CloseInput(true);
                xrefDb.SaveAs(drawing, false, DwgVersion.Current, null);
            }

            catch (Exception)
            {
            }
        }

        private void GetAllBlocksAndChangeColor(Transaction trx, Database db)
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
                    ColorBlock(trx, ent);
                }
            }

        }

        private void ColorBlock(Transaction tr, Entity ent)
        {
            try
            {
                BlockReference br = ent as BlockReference;
                if (br != null)
                {
                    // Change the color of the block itself

                    br.UpgradeOpen();
                    br.Color = Color.FromColorIndex(ColorMethod.ByLayer, 256);

                    // Change every entity to be of color ByBlock

                    BlockTableRecord btr =
                      (BlockTableRecord)tr.GetObject(
                        br.BlockTableRecord,
                        OpenMode.ForRead
                      );

                    // Iterate through the BlockTableRecord contents

                    foreach (ObjectId id in btr)
                    {
                        // Open the entity

                        Entity ent2 =
                          (Entity)tr.GetObject(id, OpenMode.ForWrite);

                        // Change each entity's color to ByBlock

                        ent2.Color =
                          Color.FromColorIndex(ColorMethod.ByBlock, 0);
                    }
                }
            }
            catch (Autodesk.AutoCAD.Runtime.Exception)
            {
            }
        }
    }
}

