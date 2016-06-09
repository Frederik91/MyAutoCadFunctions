using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.Runtime;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XrefManager
{
    class DrawingManager
    {
        [CommandMethod("OPENDRAWING")]
        public void OPENDRAWING(string filePath)
        {
            //open drawing

            DocumentCollection acDocMgr = Application.DocumentManager;


            foreach (Document document in acDocMgr)
            {
                if (document.Name == filePath)
                {
                    //System.Windows.MessageBox.Show("Drawing " + Path.GetFileName(filePath) + " is already open.");
                    return;
                }
            }

            if (File.Exists(filePath))
            {
                Application.DocumentManager.Open(filePath, false);
            }
            else
            {
                Application.DocumentManager.MdiActiveDocument.Editor.WriteMessage("File " + filePath + " does not exist.");
            }

        }

        [CommandMethod("ACTIVATEDRAWING")]
        public void ACTIVATEDRAWING(string filePath)
        {
            foreach (Document doc in Application.DocumentManager)
            {
                if (doc.Name == filePath)
                {
                    // switch the active document
                    Application.DocumentManager.MdiActiveDocument = doc;
                }
            }
        }



        [CommandMethod("SAVEDRAWING")]
        public void SAVEDRAWING(string filePath)
        {
            DocumentCollection docCol = Application.DocumentManager;

            foreach (Document doc in docCol)
            {
                if (doc.Name == filePath)
                {
                    string strDWGName = doc.Name;
                    object obj = Application.GetSystemVariable("DWGTITLED");  // Check to see if the drawing has been named 
                    if (System.Convert.ToInt16(obj) == 0)
                    {
                        // If the drawing is using a default name (Drawing1, Drawing2, etc) 
                        // then provide a new name 
                        strDWGName = "E:\\Plottefil\\MyDrawing.dwg";
                    }

                    // Save the active drawing 
                    doc.Database.SaveAs(strDWGName, true, DwgVersion.Current, doc.Database.SecurityParameters);
                }
            }
        }

        [CommandMethod("MagiCADTest")]
        public void MagiCadTest(string filePath)
        {
            var MT = new MagiTest();
            MT.test();
        }

        [CommandMethod("CLOSEDRAWING")]
        public void CLOSEDRAWING(string filePath)
        {
            DocumentCollection docs = Application.DocumentManager;
            foreach (Document doc in docs)
            {
                if (doc.Name == filePath)
                {
                    if (doc.IsReadOnly)
                    {
                        doc.CloseAndDiscard();
                    }
                    else
                    {
                        int isModified =
                          System.Convert.ToInt32(
                            Application.GetSystemVariable("DBMOD")
                          );

                        // No need to save if not modified
                        if (isModified == 0)
                        {
                            doc.CloseAndDiscard();
                        }
                        else
                        {
                            // This may create documents in strange places
                            doc.CloseAndSave(filePath);
                        }
                    }
                }
            }
        }
    }
}

