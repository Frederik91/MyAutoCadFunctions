using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DrawingManagerDll;
using DrawingManagerDll.Models;
using DrawingManagerDll.Methods;
using Autodesk.AutoCAD.ApplicationServices;

namespace TestDrawingManagerDLL
{
    [TestClass]
    public class TestChangeAttributesCommands
    {
        [TestMethod]
        public void UpdateAttributes()
        {
            var FilePath = "E:\\Plottefil\\PlottingFileConfig.xlsx";
            var ExcelReader = new ExcelFileReader(FilePath);
            var Settings = ExcelReader.ReadFile();

            var CAC = new ChangeAttributes();
            //CAC.UPDATEATTRIBUTES(Settings, Settings.DrawingData[0].revDate.ToShortDateString());
        }
    }
}
