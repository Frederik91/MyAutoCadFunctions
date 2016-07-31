using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using XrefManager;
using XrefManager.Forms;
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
    }
}
