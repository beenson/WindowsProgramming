using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace DrawingModel.Tests
{
    [TestClass]
    public class RectangleTests
    {
        Rectangle A, B, C, D;
        DrawingTests.UnitTestGraphicsAdaptor graphics;

        // Initialize
        [TestInitialize]
        public void Initialize()
        {
            graphics = new DrawingTests.UnitTestGraphicsAdaptor();
            A = new Rectangle();
            B = new Rectangle();
            C = new Rectangle();
            D = new Rectangle();
            A._point1 = new Point(10, 20);
            A._point2 = new Point(5, 15);
            B._point1 = new Point(20, 30);
            B._point2 = new Point(30, 40);
            C._point1 = new Point(50, 40);
            C._point2 = new Point(40, 50);
            D._point1 = new Point(25, 30);
            D._point2 = new Point(50, 10);
        }

        // Draw
        [TestMethod]
        public void DrawTest()
        {
            Shape shape;
            A.Draw(graphics);
            shape = graphics.GetLastDraw();
            Assert.IsNotNull(shape as Rectangle);
            Assert.AreEqual(A.UpperLeft, shape.UpperLeft);
            Assert.AreEqual(A.Width, shape.Width);
            Assert.AreEqual(A.Height, shape.Height);
            B.Draw(graphics);
            shape = graphics.GetLastDraw();
            Assert.IsNotNull(shape as Rectangle);
            Assert.AreEqual(B.UpperLeft, shape.UpperLeft);
            Assert.AreEqual(B.Width, shape.Width);
            Assert.AreEqual(B.Height, shape.Height);
            C.Draw(graphics);
            shape = graphics.GetLastDraw();
            Assert.IsNotNull(shape as Rectangle);
            Assert.AreEqual(C.UpperLeft, shape.UpperLeft);
            Assert.AreEqual(C.Width, shape.Width);
            Assert.AreEqual(C.Height, shape.Height);
            D.Draw(graphics);
            shape = graphics.GetLastDraw();
            Assert.IsNotNull(shape as Rectangle);
            Assert.AreEqual(D.UpperLeft, shape.UpperLeft);
            Assert.AreEqual(D.Width, shape.Width);
            Assert.AreEqual(D.Height, shape.Height);
        }

        // UpperLeft
        [TestMethod]
        public void UpperLeftTest()
        {
            Assert.AreEqual(5, A.UpperLeft.X);
            Assert.AreEqual(15, A.UpperLeft.Y);
            Assert.AreEqual(20, B.UpperLeft.X);
            Assert.AreEqual(30, B.UpperLeft.Y);
            Assert.AreEqual(40, C.UpperLeft.X);
            Assert.AreEqual(40, C.UpperLeft.Y);
            Assert.AreEqual(25, D.UpperLeft.X);
            Assert.AreEqual(10, D.UpperLeft.Y);
        }

        // LowerRight
        [TestMethod]
        public void LowerRightTest()
        {
            Assert.AreEqual(10, A.LowerRight.X);
            Assert.AreEqual(20, A.LowerRight.Y);
            Assert.AreEqual(30, B.LowerRight.X);
            Assert.AreEqual(40, B.LowerRight.Y);
            Assert.AreEqual(50, C.LowerRight.X);
            Assert.AreEqual(50, C.LowerRight.Y);
            Assert.AreEqual(50, D.LowerRight.X);
            Assert.AreEqual(30, D.LowerRight.Y);
        }

        // Height
        [TestMethod]
        public void HeightTest()
        {
            Assert.AreEqual(5, A.Height);
            Assert.AreEqual(10, B.Height);
            Assert.AreEqual(10, C.Height);
            Assert.AreEqual(20, D.Height);
        }

        // Width
        [TestMethod]
        public void WidthTest()
        {
            A._point1 = new Point(10, 20);
            A._point2 = new Point(5, 15);
            B._point1 = new Point(20, 30);
            B._point2 = new Point(30, 40);
            C._point1 = new Point(50, 40);
            C._point2 = new Point(40, 50);
            D._point1 = new Point(25, 30);
            D._point2 = new Point(50, 10);
            Assert.AreEqual(5, A.Width);
            Assert.AreEqual(10, B.Width);
            Assert.AreEqual(10, C.Width);
            Assert.AreEqual(25, D.Width);
        }
    }
}
