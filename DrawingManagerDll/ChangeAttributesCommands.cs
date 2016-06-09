using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.AutoCAD.Runtime;
using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.EditorInput;
using Autodesk.AutoCAD.Geometry;
using Autodesk.AutoCAD.PlottingServices;
using System.IO;
using System.Threading;
using DrawingManagerDll.Models;
using DrawingManagerDll.Methods;

namespace DrawingManagerDll
{
    public class ChangeAttributesCommands
    {
        private string FilePath = "";

        public ChangeAttributesCommands(string Filepath)
        {
            FilePath = Filepath;
        }

        [CommandMethod("UPDATEATTRIBUTE")]
        public void UPDATEATTRIBUTE()
        {
            //CloseDocuments();
            var ExcelReader = new ExcelFileReader(FilePath);
            var Settings = ExcelReader.ReadFile();
            DocumentCollection docs = Application.DocumentManager;
            var DM = new DrawingManager();

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
                    var CA = new ChangeAttributes();
                    CA.UPDATEATTRIBUTES(Settings, drawing);

                    //save
                    DM.SAVEDRAWING(filePath);

                    //close
                    DM.CLOSEDRAWING(filePath);
                }
            }

        }
    }
}
