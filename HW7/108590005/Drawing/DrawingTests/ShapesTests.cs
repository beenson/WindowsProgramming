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
            Shape shape1 = ShapeFactory.CreateShape(ShapeFactory.ShapeType.Ellipse);
            shape1.Point1 = new Point(0, 5);
            shape1.Point2 = new Point(30, 40);
            Shape shape2 = ShapeFactory.CreateShape(ShapeFactory.ShapeType.Rectangle);
            shape2.Point1 = new Point(20, 50);
            shape2.Point2 = new Point(100, 30);
            Shape shape3 = ShapeFactory.CreateShape(ShapeFactory.ShapeType.Ellipse);
            shape3.Point1 = new Point(40, 60);
            shape3.Point2 = new Point(20, 10);
            shapes.AddShape(shape1);
            shapes.AddShape(shape2);
            shapes.AddShape(shape3);
        }

        // Add Shape Test
        [TestMethod]
        public void AddShapeTest()
        {
            List<Shape> shapeList = (List<Shape>)(privateObject.GetField("_shapes"));
            Assert.AreEqual(3, shapeList.Count);
            Assert.IsNotNull(shapeList[0] as Ellipse);
            Assert.AreEqual(0, shapeList[0].Point1.X);
            Assert.AreEqual(5, shapeList[0].Point1.Y);
            Assert.AreEqual(30, shapeList[0].Point2.X);
            Assert.AreEqual(40, shapeList[0].Point2.Y);
            Assert.IsNotNull(shapeList[1] as Rectangle);
            Assert.AreEqual(20, shapeList[1].Point1.X);
            Assert.AreEqual(50, shapeList[1].Point1.Y);
            Assert.AreEqual(100, shapeList[1].Point2.X);
            Assert.AreEqual(30, shapeList[1].Point2.Y);
            Assert.IsNotNull(shapeList[2] as Ellipse);
            Assert.AreEqual(40, shapeList[2].Point1.X);
            Assert.AreEqual(60, shapeList[2].Point1.Y);
            Assert.AreEqual(20, shapeList[2].Point2.X);
            Assert.AreEqual(10, shapeList[2].Point2.Y);
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

        // Get Shape On Point Test
        [TestMethod]
        public void GetShapeOnPointTest()
        {
            Rectangle rectangle = new Rectangle(new Point(0, 0), 100, 100);
            Ellipse ellipse = new Ellipse(new Point(0, 0), 100, 100);
            shapes.AddShape(rectangle);
            shapes.AddShape(ellipse);
            Assert.AreEqual(rectangle, shapes.GetShapeOnPoint(new Point(0, 0)));
            Assert.AreEqual(rectangle, shapes.GetShapeOnPoint(new Point(100, 0)));
            Assert.AreEqual(rectangle, shapes.GetShapeOnPoint(new Point(0, 100)));
            Assert.AreEqual(rectangle, shapes.GetShapeOnPoint(new Point(100, 100)));
            Assert.AreEqual(rectangle, shapes.GetShapeOnPoint(new Point(99, 99)));
            Assert.AreEqual(ellipse, shapes.GetShapeOnPoint(new Point(50, 50)));
            Assert.IsNull(shapes.GetShapeOnPoint(new Point(101, 0)));
        }

        // Select Shape Test
        [TestMethod]
        public void SelectShapeTest()
        {
            Rectangle rectangle = new Rectangle(new Point(0, 0), 100, 100);
            Ellipse ellipse = new Ellipse(new Point(0, 0), 100, 100);
            shapes.AddShape(rectangle);
            shapes.AddShape(ellipse);
            Assert.IsTrue(shapes.SelectShape(new Point(99, 99)));
            Assert.AreEqual(rectangle, shapes.SelectedShape);
            shapes.ResetSelected();
            Assert.IsNull(shapes.SelectedShape);
            Assert.IsTrue(shapes.SelectShape(new Point(50, 50)));
            Assert.AreEqual(ellipse, shapes.SelectedShape);
            shapes.ResetSelected();
            Assert.IsNull(shapes.SelectedShape);
            Assert.IsFalse(shapes.SelectShape(new Point(150, 150)));
            Assert.IsNull(shapes.SelectedShape);
        }

        // Draw Selected Test
        [TestMethod]
        public void DrawSelectedTest()
        {
            Rectangle rectangle = new Rectangle(new Point(0, 0), 100, 100);
            Ellipse ellipse = new Ellipse(new Point(25, 25), 50, 50);
            shapes.AddShape(rectangle);
            shapes.AddShape(ellipse);
            shapes.SelectShape(new Point(99, 99));
            Assert.AreEqual(rectangle, shapes.SelectedShape);
            shapes.Draw(graphics);
            Assert.IsNotNull(graphics.Selected as Rectangle);
            Assert.AreEqual(rectangle.UpperLeft, graphics.Selected.UpperLeft);
            Assert.AreEqual(rectangle.Width, graphics.Selected.Width);
            Assert.AreEqual(rectangle.Height, graphics.Selected.Height);
            shapes.SelectShape(new Point(50, 50));
            Assert.AreEqual(ellipse, shapes.SelectedShape);
            shapes.Draw(graphics);
            Assert.IsNotNull(graphics.Selected as Rectangle);
            Assert.AreEqual(ellipse.UpperLeft, graphics.Selected.UpperLeft);
            Assert.AreEqual(ellipse.Width, graphics.Selected.Width);
            Assert.AreEqual(ellipse.Height, graphics.Selected.Height);
            shapes.SelectShape(new Point(150, 150));
            shapes.Draw(graphics);
            Assert.IsNull(graphics.Selected);
        }
    }
}
