using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace DrawingModel.Tests
{
    [TestClass]
    public class EllipseTests
    {
        Ellipse A, B, C, D;
        DrawingTests.UnitTestGraphicsAdaptor graphics;

        // Initialize
        [TestInitialize]
        public void Initialize()
        {
            graphics = new DrawingTests.UnitTestGraphicsAdaptor();
            A = new Ellipse();
            B = new Ellipse();
            C = new Ellipse();
            D = new Ellipse();
            A.Point1 = new Point(10, 20);
            A.Point2 = new Point(5, 15);
            B.Point1 = new Point(20, 30);
            B.Point2 = new Point(30, 40);
            C.Point1 = new Point(50, 40);
            C.Point2 = new Point(40, 50);
            D.Point1 = new Point(25, 30);
            D.Point2 = new Point(50, 10);
        }

        // Draw
        [TestMethod]
        public void DrawTest()
        {
            Shape shape;
            A.Draw(graphics);
            shape = graphics.GetLastDraw();
            Assert.IsNotNull(shape as Ellipse);
            Assert.AreEqual(A.UpperLeft, shape.UpperLeft);
            Assert.AreEqual(A.Width, shape.Width);
            Assert.AreEqual(A.Height, shape.Height);
            B.Draw(graphics);
            shape = graphics.GetLastDraw();
            Assert.IsNotNull(shape as Ellipse);
            Assert.AreEqual(B.UpperLeft, shape.UpperLeft);
            Assert.AreEqual(B.Width, shape.Width);
            Assert.AreEqual(B.Height, shape.Height);
            C.Draw(graphics);
            shape = graphics.GetLastDraw();
            Assert.IsNotNull(shape as Ellipse);
            Assert.AreEqual(C.UpperLeft, shape.UpperLeft);
            Assert.AreEqual(C.Width, shape.Width);
            Assert.AreEqual(C.Height, shape.Height);
            D.Draw(graphics);
            shape = graphics.GetLastDraw();
            Assert.IsNotNull(shape as Ellipse);
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
            A.Point1 = new Point(10, 20);
            A.Point2 = new Point(5, 15);
            B.Point1 = new Point(20, 30);
            B.Point2 = new Point(30, 40);
            C.Point1 = new Point(50, 40);
            C.Point2 = new Point(40, 50);
            D.Point1 = new Point(25, 30);
            D.Point2 = new Point(50, 10);
            Assert.AreEqual(5, A.Width);
            Assert.AreEqual(10, B.Width);
            Assert.AreEqual(10, C.Width);
            Assert.AreEqual(25, D.Width);
        }

        // ToString
        [TestMethod]
        public void ToStringTest()
        {
            Assert.AreEqual("Ellipse(5, 15, 10, 20)", A.ToString());
            Assert.AreEqual("Ellipse(20, 30, 30, 40)", B.ToString());
            Assert.AreEqual("Ellipse(40, 40, 50, 50)", C.ToString());
            Assert.AreEqual("Ellipse(25, 10, 50, 30)", D.ToString());
        }

        // Is Point In Shape
        [TestMethod]
        public void IsPointInShapeTest()
        {
            Assert.IsFalse(A.IsPointInShape(new Point(5, 15)));
            Assert.IsFalse(A.IsPointInShape(new Point(5, 16)));
            Assert.IsFalse(A.IsPointInShape(new Point(10, 20)));
            Assert.IsFalse(A.IsPointInShape(new Point(10, 18)));
            Assert.IsFalse(A.IsPointInShape(new Point(5.5, 15.5)));
            Assert.IsTrue(A.IsPointInShape(new Point(5, 17.5)));
            Assert.IsTrue(A.IsPointInShape(new Point(10, 17.5)));
            Assert.IsTrue(A.IsPointInShape(new Point(7.5, 15)));
            Assert.IsTrue(A.IsPointInShape(new Point(7.5, 20)));
            Assert.IsTrue(A.IsPointInShape(new Point(7.5, 17.5)));
        }

        // Draw Layer Test
        [TestMethod]
        public void DrawLayerTest()
        {
            A.Draw(graphics, Shape.DrawLayer.Line);
            Assert.AreEqual(0, graphics.GetAll().Count);
            A.Draw(graphics, Shape.DrawLayer.WithOutLine);
            Assert.AreEqual(1, graphics.GetAll().Count);
            A.Draw(graphics, Shape.DrawLayer.All);
            Assert.AreEqual(2, graphics.GetAll().Count);
        }
    }
}
