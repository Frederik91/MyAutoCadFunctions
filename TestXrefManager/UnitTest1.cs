using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using XrefManager;
using XrefManager.Forms;
using XrefManager.Workers;  
using System.Collections.Generic;
using System.Windows.Forms;

namespace TestXrefManager
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void AddXref_test()
        {
            string xRefFile;
            var drawingList = new List<string>();

            using (var _form = new AddXrefForm())
            {
                var result = _form.ShowDialog();

                if (result == DialogResult.OK)
                {
                    xRefFile = _form.xrefFile;
                    drawingList = _form.AddXrefDrawingList;
                }
                if (result == DialogResult.None)
                {
                    return;
                }

                Assert.AreEqual(DialogResult.OK, result);
            }
        }


        [TestMethod]
        public void checkXMLPath()
        {
            var readXml = new ReadXml();
            Assert.AreEqual(true, readXml.checkXmlPath());

        }

        [TestMethod]
        public void testLayerUpdateForm()
        {
            var LU = new LayerUpdate();
            LU.UpdateLayers();

        }

        [TestMethod]
        public void LocateFile()
        {
            var root = @"\\cowi.net\projects\A050000\A051350";
            var FilePath = @"O:\A050000\A051350\3.7 Tegninger\E40 RIE\E43\00 Modellfiler\11448-05-E-430-XX-001.dwg";

            var LF = new LocateFileProject();
            Assert.IsTrue(LF.FileExists(root,FilePath));
        }

    }
}
