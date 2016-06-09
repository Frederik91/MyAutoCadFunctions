using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.Runtime;
using DrawingManagerDll.Methods;
using DrawingManagerDll.Models;
using DrawingManagerDll.Views;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingManagerDll
{
    public class MoveRevisionLineCommand
    {
        private string FilePath = "";

        public MoveRevisionLineCommand(string filePath)
        {
            FilePath = filePath;
        }

        [CommandMethod("MOVEREVISIONLINE")]
        public void MOVEREVISIONLINE()
        {
            var ExcelReader = new ExcelFileReader(FilePath);
            var Settings = ExcelReader.ReadFile();

            MoveRevLineView MRLV = new MoveRevLineView(Settings, this);

            MRLV.Show();
        }


        public void ExecuteMove(Settings Settings, string RevisionToMove, string DirectionToMove, bool FitRamainingRevLines)
        {
            var DM = new DrawingManager();
            DocumentCollection docs = Application.DocumentManager;

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
                    var MRL = new MoveRevisionLine();

                    MRL.MOVEREVLINE(Settings, drawing, RevisionToMove,  DirectionToMove, FitRamainingRevLines);

                    //save
                    DM.SAVEDRAWING(filePath);

                    //close
                    DM.CLOSEDRAWING(filePath);
                }
            }
        }
    }
}
