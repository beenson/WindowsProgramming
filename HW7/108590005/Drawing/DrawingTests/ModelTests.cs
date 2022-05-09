using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

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
            Assert.AreEqual(new Point(10, 10), shape.Point1);
            model.ChangeShape(ShapeFactory.ShapeType.Rectangle);
            model.PressPointer(new Point(20, 20));
            shape = (Shape)privateObject.GetField("_hint");
            Assert.IsNotNull(shape as Rectangle);
            Assert.AreEqual(new Point(20, 20), shape.Point1);
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
            Assert.AreEqual(new Point(20, 20), hint.Point2);
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
            Assert.AreEqual(new Point(10, 10), shapeList[0].Point1);
            Assert.AreEqual(new Point(25, 25), shapeList[0].Point2);

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
            Assert.AreEqual(new Point(30, 20), shapeList[1].Point1);
            Assert.AreEqual(new Point(5, 15), shapeList[1].Point2);
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

        // Select Test
        [TestMethod]
        public void SelectTest()
        {
            model.ChangeShape(ShapeFactory.ShapeType.Rectangle);
            model.PressPointer(new Point(0, 0));
            model.ReleasePointer(new Point(100, 100));
            model.ChangeShape(ShapeFactory.ShapeType.Ellipse);
            model.PressPointer(new Point(25, 25));
            model.ReleasePointer(new Point(75, 75));
            model.Click(new Point(90, 90));
            Assert.IsNotNull(model.SelectedShape as Rectangle);
            Assert.AreEqual(new Point(0, 0), model.SelectedShape.UpperLeft);
            Assert.AreEqual(new Point(100, 100), model.SelectedShape.LowerRight);
            model.Click(new Point(200, 200));
            Assert.IsNull(model.SelectedShape);
            model.ChangeShape(ShapeFactory.ShapeType.Rectangle);
            model.Click(new Point(50, 50));
            Assert.IsNull(model.SelectedShape);
            model.ChangeShape(ShapeFactory.ShapeType.None);
            model.Click(new Point(50, 50));
            Assert.IsNotNull(model.SelectedShape as Ellipse);
            Assert.AreEqual(new Point(25, 25), model.SelectedShape.UpperLeft);
            Assert.AreEqual(new Point(75, 75), model.SelectedShape.LowerRight);
        }

        // Draw Line Test
        [TestMethod]
        public void DrawLineTest()
        {
            model.ChangeShape(ShapeFactory.ShapeType.Ellipse);
            model.PressPointer(new Point(0, 0));
            model.ReleasePointer(new Point(50, 50));
            model.ChangeShape(ShapeFactory.ShapeType.Rectangle);
            model.PressPointer(new Point(100, 100));
            model.ReleasePointer(new Point(150, 150));
            model.ChangeShape(ShapeFactory.ShapeType.Line);
            model.PressPointer(new Point(100, 0));
            model.ReleasePointer(new Point(200, 0));
            Assert.AreEqual(2, ((List<Shape>)shapesPrivateObject.GetField("_shapes")).Count);
            Assert.AreEqual(ShapeFactory.ShapeType.Line, model.DrawingShapeType);
            model.PressPointer(new Point(0, 0));
            model.ReleasePointer(new Point(200, 0));
            Assert.AreEqual(2, ((List<Shape>)shapesPrivateObject.GetField("_shapes")).Count);
            Assert.AreEqual(ShapeFactory.ShapeType.Line, model.DrawingShapeType);
            model.PressPointer(new Point(100, 0));
            model.ReleasePointer(new Point(125, 125));
            Assert.AreEqual(2, ((List<Shape>)shapesPrivateObject.GetField("_shapes")).Count);
            Assert.AreEqual(ShapeFactory.ShapeType.Line, model.DrawingShapeType);
            model.PressPointer(new Point(25, 25));
            model.ReleasePointer(new Point(100, 100));
            Assert.AreEqual(3, ((List<Shape>)shapesPrivateObject.GetField("_shapes")).Count);
            Assert.AreEqual(ShapeFactory.ShapeType.None, model.DrawingShapeType);
            model.PressPointer(new Point(0, 0));
            model.ReleasePointer(new Point(200, 0));
            Line line = ((List<Shape>)shapesPrivateObject.GetField("_shapes")).Last() as Line;
            Assert.IsNotNull(line);
            Assert.AreEqual(new Point(25, 25), line.Point1);
            Assert.AreEqual(new Point(125, 125), line.Point2);
        }

        // Undo Redo
        [TestMethod]
        public void UndoRedoTest()
        {
            Assert.IsFalse(model.IsRedoEnabled);
            Assert.IsFalse(model.IsUndoEnabled);
            model.ChangeShape(ShapeFactory.ShapeType.Ellipse);
            model.PressPointer(new Point(0, 0));
            model.ReleasePointer(new Point(50, 50));
            Assert.IsFalse(model.IsRedoEnabled);
            Assert.IsTrue(model.IsUndoEnabled);
            model.ChangeShape(ShapeFactory.ShapeType.Rectangle);
            model.PressPointer(new Point(100, 100));
            model.ReleasePointer(new Point(150, 150));
            Assert.IsFalse(model.IsRedoEnabled);
            Assert.IsTrue(model.IsUndoEnabled);
            Assert.AreEqual(2, ((List<Shape>)shapesPrivateObject.GetField("_shapes")).Count);
            model.Click(new Point(25, 25));
            Assert.IsNotNull(model.SelectedShape as Ellipse);
            model.Undo();
            Assert.AreEqual(1, ((List<Shape>)shapesPrivateObject.GetField("_shapes")).Count);
            Assert.IsNull(model.SelectedShape);
            Assert.IsTrue(model.IsRedoEnabled);
            Assert.IsTrue(model.IsUndoEnabled);
            model.Undo();
            Assert.AreEqual(0, ((List<Shape>)shapesPrivateObject.GetField("_shapes")).Count);
            Assert.IsTrue(model.IsRedoEnabled);
            Assert.IsFalse(model.IsUndoEnabled);
            model.Redo();
            Assert.AreEqual(1, ((List<Shape>)shapesPrivateObject.GetField("_shapes")).Count);
            Assert.IsNull(model.SelectedShape);
            Assert.IsTrue(model.IsRedoEnabled);
            Assert.IsTrue(model.IsUndoEnabled);
            model.Click(new Point(25, 25));
            model.Clear();
            Assert.AreEqual(0, ((List<Shape>)shapesPrivateObject.GetField("_shapes")).Count);
            Assert.IsNull(model.SelectedShape);
            Assert.IsFalse(model.IsRedoEnabled);
            Assert.IsFalse(model.IsUndoEnabled);
        }

        // Delegate Test
        [TestMethod]
        public void DelegateTest()
        {
            model._shapesChanged += TriggerDelegate;
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

            triggered = false;
            model.Click(new Point(15, 15));
            model._selectedChanged += TriggerDelegate;
            Assert.IsTrue(triggered);
            triggered = false;
            model.Click(new Point(100, 100));
            model._selectedChanged += TriggerDelegate;
            Assert.IsTrue(triggered);
        }

        // Delegate Triggered
        private void TriggerDelegate()
        {
            triggered = true;
        }
    }
}
