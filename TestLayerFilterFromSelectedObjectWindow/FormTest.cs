using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using LayerFilterFromSelectedObjectWindow;

namespace TestLayerFilterFromSelectedObjectWindow
{
    [TestClass]
    public class FormTest
    {
        [TestMethod]
        public void TestDataGrid()
        {
            var list = "testLayerName";

            var window = new MainWindow();
            window.MainViewModel.MapLayerStringToLayerFilter(list);
            window.ShowDialog();

            var filterList = window.MainViewModel.NewLayerFilterList;

            Assert.AreNotEqual(0, filterList.Count);
        }
    }
}
