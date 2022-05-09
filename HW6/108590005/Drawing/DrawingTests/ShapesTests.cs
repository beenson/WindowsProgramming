using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace DrawingModel.Tests
{
    [TestClass]
    public class ShapesTests
    {
        Shapes shapes;
        PrivateObject privateObject;
        DrawingTests.UnitTestGraphicsAdaptor graphics;

        // Initialize
        [TestInitialize]
        public void Initialize()
        {
            graphics = new DrawingTests.UnitTestGraphicsAdaptor();
            shapes = new Shapes();
            privateObject = new PrivateObject(shapes);
            shapes.AddShape(ShapeFactory.ShapeType.Ellipse, new Point(0, 5), new Point(30, 40));
            shapes.AddShape(ShapeFactory.ShapeType.Rectangle, new Point(20, 50), new Point(100, 30));
            shapes.AddShape(ShapeFactory.ShapeType.Ellipse, new Point(40, 60), new Point(20, 10));
        }

        // Add Shape Test
        [TestMethod]
        public void AddShapeTest()
        {
            List<Shape> shapeList = (List<Shape>)(privateObject.GetField("_shapes"));
            Assert.AreEqual(3, shapeList.Count);
            Assert.IsNotNull(shapeList[0] as Ellipse);
            Assert.AreEqual(0, shapeList[0]._point1.X);
            Assert.AreEqual(5, shapeList[0]._point1.Y);
            Assert.AreEqual(30, shapeList[0]._point2.X);
            Assert.AreEqual(40, shapeList[0]._point2.Y);
            Assert.IsNotNull(shapeList[1] as Rectangle);
            Assert.AreEqual(20, shapeList[1]._point1.X);
            Assert.AreEqual(50, shapeList[1]._point1.Y);
            Assert.AreEqual(100, shapeList[1]._point2.X);
            Assert.AreEqual(30, shapeList[1]._point2.Y);
            Assert.IsNotNull(shapeList[2] as Ellipse);
            Assert.AreEqual(40, shapeList[2]._point1.X);
            Assert.AreEqual(60, shapeList[2]._point1.Y);
            Assert.AreEqual(20, shapeList[2]._point2.X);
            Assert.AreEqual(10, shapeList[2]._point2.Y);
        }

        // Clear Test
        [TestMethod]
        public void ClearTest()
        {
            Assert.AreEqual(3, ((List<Shape>)(privateObject.GetField("_shapes"))).Count);
            shapes.Clear();
            Assert.AreEqual(0, ((List<Shape>)(privateObject.GetField("_shapes"))).Count);
        }

        // Draw Test
        [TestMethod]
        public void DrawTest()
        {
            List<Shape> draw;
            shapes.Draw(graphics);
            draw = graphics.GetAll();
            Assert.AreEqual(3, draw.Count);
            Assert.IsNotNull(draw[0] as Ellipse);
            Assert.AreEqual(0, draw[0].UpperLeft.X);
            Assert.AreEqual(5, draw[0].UpperLeft.Y);
            Assert.AreEqual(30, draw[0].Width);
            Assert.AreEqual(35, draw[0].Height);
            Assert.IsNotNull(draw[1] as Rectangle);
            Assert.AreEqual(20, draw[1].UpperLeft.X);
            Assert.AreEqual(30, draw[1].UpperLeft.Y);
            Assert.AreEqual(80, draw[1].Width);
            Assert.AreEqual(20, draw[1].Height);
            Assert.IsNotNull(draw[2] as Ellipse);
            Assert.AreEqual(20, draw[2].UpperLeft.X);
            Assert.AreEqual(10, draw[2].UpperLeft.Y);
            Assert.AreEqual(20, draw[2].Width);
            Assert.AreEqual(50, draw[2].Height);
            shapes.Draw(graphics);
            draw = graphics.GetAll();
            Assert.AreEqual(3, draw.Count);
            shapes.Clear();
            shapes.Draw(graphics);
            Assert.AreEqual(0, graphics.GetAll().Count);
        }
    }
}
