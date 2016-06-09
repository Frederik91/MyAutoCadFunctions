using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DrawingManagerDll;

namespace TestDrawingManagerDLL
{
    [TestClass]
    public class TestExcelFileReader
    {
        [TestMethod]
        public void ReadExcelFile()
        {
           ExcelFileReader EFR = new ExcelFileReader("O:\\A070000\\A074115\\CAD\\E40 RIE\\E99\\PlottingFileConfig.xlsx");
            EFR.ReadFile();
        }
    }
}
