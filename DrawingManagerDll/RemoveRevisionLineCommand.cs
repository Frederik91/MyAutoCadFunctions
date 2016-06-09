using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.Runtime;
using DrawingManagerDll.Methods;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic;

namespace DrawingManagerDll
{
    class RemoveRevisionLineCommand
    {
        private string FilePath = "";

        public RemoveRevisionLineCommand(string filePath)
        {
            FilePath = filePath;
        }


        [CommandMethod("REMOVEREVISIONLINE")]
        public void REMOVEREVISIONLINE()
        {
            var ExcelReader = new ExcelFileReader(FilePath);
            var Settings = ExcelReader.ReadFile();
            DocumentCollection docs = Application.DocumentManager;
            var revToDel = "";
            var DM = new DrawingManager();

            revToDel = Interaction.InputBox("Enter revision to remove", "Remove revision");

            if (revToDel == "")
            {
                Application.ShowAlertDialog("Revision cannot be blank");
                return;
            }

            foreach (var drawing in Settings.DrawingData)
            {
                if (drawing.ToBeUpdated)
                {
                    string filePath = drawing.FolderPath + "\\" + drawing.DrawingName + ".dwg";

                    //Open drawings
                    DM.OPENDRAWING(filePath);

                    //set drawing active
                    DM.ACTIVATEDRAWING(filePath);

                    //update Attribute
                    var RRL = new RemoveRevLine();
                    RRL.REMOVEREVLINE(Settings, drawing, revToDel);

                    //save
                    DM.SAVEDRAWING(filePath);

                    //close
                    DM.CLOSEDRAWING(filePath);
                }
            }

        }

    }
}
