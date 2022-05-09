using Microsoft.VisualStudio.TestTools.UnitTesting;
using DrawingModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingModel.Tests
{
    [TestClass()]
    public class PointTests
    {
        Point A, B, C, D, E;

        // Initialize
        [TestInitialize()]
        public void Initialize()
        {
            A = new Point(-1.5, -1.5);
            B = new Point(0, -1.5);
            C = new Point(-2.4, 0);
            D = new Point(0, 0);
            E = new Point(23.7, 25.8);
        }

        // Available Test
        [TestMethod()]
        public void AvailableTest()
        {
            Assert.IsFalse(A.IsAvailable);
            Assert.IsFalse(B.IsAvailable);
            Assert.IsFalse(C.IsAvailable);
            Assert.IsTrue(D.IsAvailable);
            Assert.IsTrue(E.IsAvailable);
        }
    }
}