using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace DrawingModel.Tests
{
    [TestClass]
    public class ModelTests
    {
        Model model;
        PrivateObject privateObject;
        PrivateObject shapesPrivateObject;
        DrawingTests.UnitTestGraphicsAdaptor graphics;
        bool triggered = false;

         // Initialize
         [TestInitialize]
        public void Initialize()
        {
            model = new Model();
            privateObject = new PrivateObject(model);
            graphics = new DrawingTests.UnitTestGraphicsAdaptor();
            Shapes shapes = (Shapes)privateObject.GetField("_shapes");
            shapesPrivateObject = new PrivateObject(shapes);
        }

        // PressPointer Test
        [TestMethod]
        public void PressPointerTest()
        {
            model.PressPointer(new Point(-1, -10));
            Assert.IsFalse((bool)privateObject.GetField("_isPressed"));
            model.PressPointer(new Point(10, 10));
            Assert.IsFalse((bool)privateObject.GetField("_isPressed"));
            model.ChangeShape(ShapeFactory.ShapeType.None);
            model.PressPointer(new Point(10, 10));
            Assert.IsFalse((bool)privateObject.GetField("_isPressed"));
            model.ChangeShape(ShapeFactory.ShapeType.Ellipse);
            model.PressPointer(new Point(10, 10));
            Assert.IsTrue((bool)privateObject.GetField("_isPressed"));
            Shape shape = (Shape)privateObject.GetField("_hint");
            Assert.IsNotNull(shape as Ellipse);
            Assert.AreEqual(new Point(10, 10), shape._point1);
            model.ChangeShape(ShapeFactory.ShapeType.Rectangle);
            model.PressPointer(new Point(20, 20));
            shape = (Shape)privateObject.GetField("_hint");
            Assert.IsNotNull(shape as Rectangle);
            Assert.AreEqual(new Point(20, 20), shape._point1);
        }

        // MovePointer Test
        [TestMethod]
        public void MovePointerTest()
        {
            model.ChangeShape(ShapeFactory.ShapeType.Ellipse);
            model.PressPointer(new Point(10, 10));
            model.MovePointer(new Point(20, 20));
            Shape hint = (Shape)privateObject.GetField("_hint");
            Assert.IsNotNull(hint);
            Assert.AreEqual(new Point(20, 20), hint._point2);
            List<Shape> shapeList = (List<Shape>)shapesPrivateObject.GetField("_shapes");
            Assert.AreEqual(0, shapeList.Count);
        }

        // ReleasePointer Test
        [TestMethod]
        public void ReleasePointerTest()
        {
            model.ChangeShape(ShapeFactory.ShapeType.Ellipse);
            model.PressPointer(new Point(10, 10));
            model.ReleasePointer(new Point(25, 25));
            Assert.IsFalse((bool)privateObject.GetField("_isPressed"));
            List<Shape> shapeList = (List<Shape>)shapesPrivateObject.GetField("_shapes");
            Assert.AreEqual(1, shapeList.Count);
            Assert.AreEqual(new Point(10, 10), shapeList[0]._point1);
            Assert.AreEqual(new Point(25, 25), shapeList[0]._point2);

            model.PressPointer(new Point(30, 20));
            model.ReleasePointer(new Point(5, 15));
            Assert.IsFalse((bool)privateObject.GetField("_isPressed"));
            shapeList = (List<Shape>)shapesPrivateObject.GetField("_shapes");
            Assert.AreEqual(1, shapeList.Count);

            model.ChangeShape(ShapeFactory.ShapeType.Rectangle);
            model.PressPointer(new Point(30, 20));
            model.ReleasePointer(new Point(5, 15));
            Assert.IsFalse((bool)privateObject.GetField("_isPressed"));
            shapeList = (List<Shape>)shapesPrivateObject.GetField("_shapes");
            Assert.AreEqual(2, shapeList.Count);
            Assert.AreEqual(new Point(30, 20), shapeList[1]._point1);
            Assert.AreEqual(new Point(5, 15), shapeList[1]._point2);
        }

        // ChangeShape Test
        [TestMethod]
        public void ChangeShapeTest()
        {
            Shape hint;
            hint = (Shape)privateObject.GetField("_hint");
            Assert.IsNull(hint);
            model.ChangeShape(ShapeFactory.ShapeType.None);
            hint = (Shape)privateObject.GetField("_hint");
            Assert.IsNull(hint);
            model.ChangeShape(ShapeFactory.ShapeType.Ellipse);
            hint = (Shape)privateObject.GetField("_hint");
            Assert.IsNotNull(hint);
            Assert.IsNotNull(hint as Ellipse);
            model.ChangeShape(ShapeFactory.ShapeType.Rectangle);
            hint = (Shape)privateObject.GetField("_hint");
            Assert.IsNotNull(hint);
            Assert.IsNotNull(hint as Rectangle);
        }

        // Clear Test
        [TestMethod]
        public void Clear()
        {
            model.ChangeShape(ShapeFactory.ShapeType.Ellipse);
            model.PressPointer(new Point(10, 10));
            model.ReleasePointer(new Point(25, 25));
            List<Shape> shapeList = (List<Shape>)shapesPrivateObject.GetField("_shapes");
            Assert.AreEqual(1, shapeList.Count);

            model.ChangeShape(ShapeFactory.ShapeType.Rectangle);
            model.PressPointer(new Point(30, 20));
            model.ReleasePointer(new Point(5, 15));
            shapeList = (List<Shape>)shapesPrivateObject.GetField("_shapes");
            Assert.AreEqual(2, shapeList.Count);

            model.Clear();
            shapeList = (List<Shape>)shapesPrivateObject.GetField("_shapes");
            Assert.AreEqual(0, shapeList.Count);
        }

        // Draw Test
        [TestMethod]
        public void DrawTest()
        {
            model.ChangeShape(ShapeFactory.ShapeType.Ellipse);
            model.PressPointer(new Point(10, 10));
            model.MovePointer(new Point(15, 15));
            model.Draw(graphics);
            Assert.AreEqual(1, graphics.GetAll().Count);
            Assert.IsNotNull(graphics.GetAll()[0] as Ellipse);
            Assert.AreEqual(new Point(10, 10), graphics.GetAll()[0].UpperLeft);
            Assert.AreEqual(new Point(15, 15), graphics.GetAll()[0].LowerRight);
            model.ReleasePointer(new Point(25, 25));
            model.Draw(graphics);
            Assert.AreEqual(1, graphics.GetAll().Count);
            Assert.IsNotNull(graphics.GetAll()[0] as Ellipse);
            Assert.AreEqual(new Point(10, 10), graphics.GetAll()[0].UpperLeft);
            Assert.AreEqual(new Point(25, 25), graphics.GetAll()[0].LowerRight);
            model.ChangeShape(ShapeFactory.ShapeType.Rectangle);
            model.PressPointer(new Point(30, 20));
            model.MovePointer(new Point(15, 15));
            model.Draw(graphics);
            Assert.AreEqual(2, graphics.GetAll().Count);
            Assert.IsNotNull(graphics.GetAll()[0] as Ellipse);
            Assert.AreEqual(new Point(15, 15), graphics.GetAll()[1].UpperLeft);
            Assert.AreEqual(new Point(30, 20), graphics.GetAll()[1].LowerRight);
            model.ReleasePointer(new Point(5, 15));
            model.Draw(graphics);
            Assert.AreEqual(2, graphics.GetAll().Count);
            Assert.IsNotNull(graphics.GetAll()[1] as Rectangle);
            Assert.AreEqual(new Point(5, 15), graphics.GetAll()[1].UpperLeft);
            Assert.AreEqual(new Point(30, 20), graphics.GetAll()[1].LowerRight);
        }

        // Delegate Test
        [TestMethod]
        public void DelegateTest()
        {
            model._modelChanged += TriggerDelegate;
            model.PressPointer(new Point(10, 10));
            Assert.IsFalse(triggered);
            model.MovePointer(new Point(15, 15));
            Assert.IsFalse(triggered);
            model.ReleasePointer(new Point(20, 20));
            Assert.IsFalse(triggered);

            model.ChangeShape(ShapeFactory.ShapeType.Ellipse);
            model.PressPointer(new Point(10, 10));
            Assert.IsFalse(triggered);
            model.MovePointer(new Point(15, 15));
            Assert.IsTrue(triggered);
            triggered = false;
            model.ReleasePointer(new Point(20, 20));
            Assert.IsTrue(triggered);
        }

        // Delegate Triggered
        private void TriggerDelegate()
        {
            triggered = true;
        }
    }
}
