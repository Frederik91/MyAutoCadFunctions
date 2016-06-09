using Microsoft.VisualStudio.TestTools.UnitTesting;
using DrawingManagerDll.Models;
using System.Collections.Generic;
using System.Xml.Linq;
using Autodesk.AutoCAD.ApplicationServices;
using DrawingManagerDll.MAGIIFC;
using System.IO;
using XrefManager;
using System.Text;
using Microsoft.VisualBasic.CompilerServices;
using Microsoft.Win32;
using System;

namespace TestDrawingManagerDLL
{
    /// <summary>
    /// Summary description for UnitTest1
    /// </summary>
    [TestClass]
    public class UnitTest1
    {
        public UnitTest1()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        [TestMethod]
        public void IFCExport()
        {
            bool drawingClosed = false;

            foreach (Document doc in Application.DocumentManager)
            {
                foreach (var file in Directory.GetFiles("C:\\IFCEXPORT\\Projects\\MH2\\RIE\\E41\\00 Modellfiler"))
                {
                    if (Path.GetFileName(file) == Path.GetFileName(doc.Name))
                    {
                        drawingClosed = true;
                    }
                }
            }

            Assert.Equals(drawingClosed, true);

        }

        [TestMethod]
        public void TestLayerFilter()
        {
            var Pattern = "*G - 200*";
            var Text = "AB - 07 - G - 200 - 20 - 01|Graphic";

            Assert.IsTrue(LayerComparer.IsLike(Pattern, Text));
        }

        [TestMethod]
        public void TestLayerUpdate()
        {
            var layerArray = File.ReadAllLines(@"C:\Temp\LayerList.txt");

            var frozenLayerList = new List<string>();

            var LU = new LayerUpdate();
            var propertyList = LU.ReadLayerPropertyFile(@"O:\A015000\A017068\3.7 Tegninger\Navn\FRTE\UNN layer plot.txt");

            foreach (var layer in layerArray)
            {
                bool layerFrozen = false;
                foreach (var property in propertyList)
                {
                    if (LayerComparer.IsLike(property.Name, layer))
                    {
                        if (property.freeze && layer.Contains("- G -"))
                        {
                            layerFrozen = true;
                        }
                    }
                }
                if (layerFrozen)
                {
                    frozenLayerList.Add(layer);
                }


            }

            File.WriteAllLines(@"C:\Temp\ModifiedLayers.txt", frozenLayerList.ToArray());
        }
    }
}
