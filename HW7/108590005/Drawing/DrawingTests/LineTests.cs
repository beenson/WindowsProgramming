using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace DrawingModel.Tests
{
    [TestClass]
    public class LineTests
    {
        Line A, B, C, D, E;
        Ellipse ellipse;
        Rectangle rectangle;
        DrawingTests.UnitTestGraphicsAdaptor graphics;

        // Initialize
        [TestInitialize]
        public void Initialize()
        {
            graphics = new DrawingTests.UnitTestGraphicsAdaptor();
            A = new Line();
            B = new Line();
            C = new Line();
            D = new Line();
            A.Point1 = new Point(10, 20);
            A.Point2 = new Point(5, 15);
            B.Point1 = new Point(20, 30);
            B.Point2 = new Point(30, 40);
            C.Point1 = new Point(50, 40);
            C.Point2 = new Point(40, 50);
            D.Point1 = new Point(25, 30);
            D.Point2 = new Point(50, 10);
            ellipse = new Ellipse();
            ellipse.Point1 = new Point(90, 110);
            ellipse.Point2 = new Point(35, 65);
            rectangle = new Rectangle();
            rectangle.Point1 = new Point(45, 95);
            rectangle.Point2 = new Point(40, 120);
            E = new Line();
            E.Shape1 = ellipse;
            E.Shape2 = rectangle;
        }

        // Draw
        [TestMethod]
        public void DrawTest()
        {
            Shape shape;
            A.Draw(graphics);
            shape = graphics.GetLastDraw();
            Assert.IsNotNull(shape as Line);
            Assert.AreEqual(A.Point1, shape.Point1);
            Assert.AreEqual(A.Point2, shape.Point2);
            B.Draw(graphics);
            shape = graphics.GetLastDraw();
            Assert.IsNotNull(shape as Line);
            Assert.AreEqual(B.Point1, shape.Point1);
            Assert.AreEqual(B.Point2, shape.Point2);
            C.Draw(graphics);
            shape = graphics.GetLastDraw();
            Assert.IsNotNull(shape as Line);
            Assert.AreEqual(C.Point1, shape.Point1);
            Assert.AreEqual(C.Point2, shape.Point2);
            D.Draw(graphics);
            shape = graphics.GetLastDraw();
            Assert.IsNotNull(shape as Line);
            Assert.AreEqual(D.Point1, shape.Point1);
            Assert.AreEqual(D.Point2, shape.Point2);
            E.Draw(graphics);
            shape = graphics.GetLastDraw();
            Assert.IsNotNull(shape as Line);
            Assert.AreEqual(ellipse.center, shape.Point1);
            Assert.AreEqual(rectangle.center, shape.Point2);
        }

        // Is Pointer In Shape Test
        [TestMethod]
        public void IsPointerInShapeTest()
        {
            Assert.IsFalse(A.IsPointInShape(A.Point1));
            Assert.IsFalse(A.IsPointInShape(A.Point2));
            Assert.IsFalse(A.IsPointInShape(A.center));
        }

        // Draw Layer Test
        [TestMethod]
        public void DrawLayerTest()
        {
            A.Draw(graphics, Shape.DrawLayer.WithOutLine);
            Assert.AreEqual(0, graphics.GetAll().Count);
            A.Draw(graphics, Shape.DrawLayer.Line);
            Assert.AreEqual(1, graphics.GetAll().Count);
            A.Draw(graphics, Shape.DrawLayer.All);
            Assert.AreEqual(2, graphics.GetAll().Count);
        }
    }
}
