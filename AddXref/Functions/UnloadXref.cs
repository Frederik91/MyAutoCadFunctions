using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.EditorInput;
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
    class UnloadXref
    {
        public void unloadXref()
        {
            var DrawingList = new List<string>();

            using (var _form = new AddXrefForm())
            {
                _form.SetTab(1);

                var result = _form.ShowDialog();

                if (result == System.Windows.Forms.DialogResult.OK)
                {
                    DrawingList = _form.UnloadXrefDrawingList;
                }
                if (result == System.Windows.Forms.DialogResult.None)
                {
                    return;
                }
            }

            //Get the document
            Document Doc = Application.DocumentManager.MdiActiveDocument;
            Editor ed = Doc.Editor;

            foreach (var drawing in DrawingList)
            {
                //create a database and try to load the file
                Database db = new Database(false, true);
                using (db)
                {
                    try
                    {
                        db.ReadDwgFile(drawing, FileShare.ReadWrite, false, "");
                    }
                    catch (System.Exception)
                    {
                        ed.WriteMessage("\nUnable to read the drawingfile.");
                        continue;
                    }
                    using (Transaction tr = db.TransactionManager.StartTransaction())
                    {
                        XrefGraph xg = db.GetHostDwgXrefGraph(true);
                        int xrefcount = xg.NumNodes - 1;

                        if (xrefcount != 0)
                        {
                            ObjectIdCollection XrefColl = new ObjectIdCollection();

                            for (int r = 1; r < (xrefcount + 1); r++)
                            {
                                XrefGraphNode xrefNode = xg.GetXrefNode(r);

                                ObjectId xrefId = xrefNode.BlockTableRecordId;
                                XrefColl.Add(xrefId);

                            }
                            db.UnloadXrefs(XrefColl);
                            tr.Commit();
                        }
                    }
                    // Overwrite the current drawing file with new updated XRef paths
                    db.SaveAs(drawing, false, DwgVersion.Current, null);

                }
            }

            Doc.Editor.WriteMessage("Xrefs unloaded\n");
        }

        public void detachXref()
        {
            var DrawingList = new List<string>();

            using (var _form = new AddXrefForm())
            {
                _form.SetTab(2);

                var result = _form.ShowDialog();

                if (result == System.Windows.Forms.DialogResult.OK)
                {
                    DrawingList = _form.DetachXrefDrawingList;
                }
                if (result == System.Windows.Forms.DialogResult.None)
                {
                    return;
                }
            }

            //Get the document
            Document Doc = Application.DocumentManager.MdiActiveDocument;
            Editor ed = Doc.Editor;

            foreach (var drawing in DrawingList)
            {
                //create a database and try to load the file
                Database db = new Database(false, true);
                using (db)
                {
                    try
                    {
                        db.ReadDwgFile(drawing, System.IO.FileShare.ReadWrite, false, "");
                    }
                    catch (System.Exception)
                    {
                        ed.WriteMessage("\nUnable to read the drawingfile.");
                        return;
                    }
                    db.ResolveXrefs(true, false);
                    using (Transaction tr = db.TransactionManager.StartTransaction())
                    {
                        XrefGraph xg = db.GetHostDwgXrefGraph(true);
                        int xrefcount = xg.NumNodes;
                        for (int j = 0; j < xrefcount; j++)
                        {
                            XrefGraphNode xrNode = xg.GetXrefNode(j);
                            String nodeName = xrNode.Name;
                            if (xrNode.XrefStatus == XrefStatus.FileNotFound)
                            {
                                ObjectId detachid = xrNode.BlockTableRecordId;
                                db.DetachXref(detachid);
                                ed.WriteMessage("\nDetached successfully\n");
                                break;
                            }
                        }
                        tr.Commit();
                    }
                    // Overwrite the current drawing file with new updated XRef paths
                    try
                    {
                        db.SaveAs(drawing, false, DwgVersion.Current, null);
                    }
                    catch (System.Exception)
                    {
                        continue;
                    }
                }
            }

            Doc.Editor.WriteMessage("Xref is detached");
        }

        public string getFileToXref()
        {
            var FD = new OpenFileDialog();

            FD.Filter = "AutoCAD Files | *.dwg";
            FD.ShowDialog();

            return FD.FileName;
        }

        public List<string> getDrawingList()
        {
            var FD = new OpenFileDialog();

            FD.Filter = "AutoCAD Files | *.dwg";
            FD.Multiselect = true;
            FD.ShowDialog();


            return FD.FileNames.ToList();
        }
    }
}
