using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using TestProj;

namespace TestDrawingManagerDLL
{
    [TestClass]
    public class TestTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            var prog = new TestProj.Program();
            prog.test();
        }


    }
}
