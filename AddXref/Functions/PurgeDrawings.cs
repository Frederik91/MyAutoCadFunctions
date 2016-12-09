using Autodesk.AutoCAD.DatabaseServices;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XrefManager.Forms;

namespace XrefManager
{
    public class PurgeDrawings
    {
        public List<string> getDrawingsToPurge()
        {
            var fileDiag = new OpenFileDialog();
            fileDiag.Filter = "*.dwg | *.dwg";
            fileDiag.Multiselect = true;
            fileDiag.ShowDialog();
            if (fileDiag.CheckFileExists)
            {
                return fileDiag.FileNames.ToList();
            }

            return null;
        }

        public void purgeMultipleFiles()
        {
            var drawingList = new List<string>();

            using (var _form = new PurgeAttributeForm())
            {
                _form.SetTabIndex(0);

                var result = _form.ShowDialog();

                if (result == System.Windows.Forms.DialogResult.OK)
                {
                    drawingList = _form.PurgeDrawingList;
                }
                if (result == System.Windows.Forms.DialogResult.None)
                {
                    return;
                }
            }

            foreach (var drawing in drawingList)
            {
                purgeDrawing(drawing);
;            }
        }

        private void purgeDrawing(string filePath)
        {
            Database xrefDb = new Database(false, true);

            var layerList = new List<string>();

            try
            {
                xrefDb.ReadDwgFile(filePath, FileShare.ReadWrite, false, "");

                using (Transaction trx = xrefDb.TransactionManager.StartTransaction())
                {
                    var allObj = trx.GetAllObjects();

                    foreach (ObjectIdGraph obj in allObj)
                    {
                        xrefDb.Purge(obj);
                    }                  


                    trx.Commit();
                }

                xrefDb.CloseInput(true);
                xrefDb.SaveAs(filePath, false, DwgVersion.Current, null);

                //successfullDrawings.Add(drawing);
            }
            catch (Exception)
            {
                //failedDrawings.Add(drawing);
            }
        }
    }
}
