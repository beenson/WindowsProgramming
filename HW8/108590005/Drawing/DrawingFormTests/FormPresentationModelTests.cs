using Microsoft.VisualStudio.TestTools.UnitTesting;
using DrawingForm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DrawingModel;
using System.IO;

namespace DrawingForm.Tests
{
    [TestClass()]
    public class FormPresentationModelTests
    {
        Model model;
        FormPresentationModel presentationModel;
        PrivateObject modelPrivateObject, shapesPrivateObject, presentationModelPrivateObject;
        DrawingTests.UnitTestGraphicsAdaptor graphics;
        DrawingTests.MockGoogleDriveSerivce service;

        // Initialize
        [TestInitialize]
        public void Initizlize()
        {
            service = new DrawingTests.MockGoogleDriveSerivce();
            model = new Model(service);
            modelPrivateObject = new PrivateObject(model);
            Shapes shapes = (Shapes)modelPrivateObject.GetField("_shapes");
            shapesPrivateObject = new PrivateObject(shapes);
            presentationModel = new FormPresentationModel(model);
            presentationModelPrivateObject = new PrivateObject(presentationModel);
            graphics = new DrawingTests.UnitTestGraphicsAdaptor();
        }

        // GetModel Test
        [TestMethod()]
        public void GetModelTest()
        {
            Assert.AreEqual(model, presentationModel.GetModel());
        }

        // PressPointer Test
        [TestMethod()]
        public void PressPointerTest()
        {
            presentationModel.PressPointer(new DrawingModel.Point(10, 10));
            Assert.IsNull(modelPrivateObject.GetField("_hint"));
            presentationModel.ChangeShape(DrawingModel.ShapeFactory.ShapeType.Ellipse);
            presentationModel.PressPointer(new DrawingModel.Point(20, 20));
            Shape shape = (Shape)modelPrivateObject.GetField("_hint");
            Assert.IsNotNull(shape as Ellipse);
            Assert.AreEqual(new Point(20, 20), shape.Point1);
        }

        // ReleasePointer Test
        [TestMethod()]
        public void ReleasePointerTest()
        {
            List<Shape> shapes;
            presentationModel.PressPointer(new DrawingModel.Point(10, 10));
            presentationModel.ReleasePointer(new DrawingModel.Point(20, 20));
            shapes = (List<Shape>)shapesPrivateObject.GetField("_shapes");
            Assert.AreEqual(0, shapes.Count);
            presentationModel.ChangeShape(DrawingModel.ShapeFactory.ShapeType.Ellipse);
            presentationModel.PressPointer(new DrawingModel.Point(10, 10));
            presentationModel.ReleasePointer(new DrawingModel.Point(20, 20));
            shapes = (List<Shape>)shapesPrivateObject.GetField("_shapes");
            Assert.AreEqual(1, shapes.Count);
            Assert.IsNotNull(shapes[0] as Ellipse);
            Assert.AreEqual(new Point(10, 10), shapes[0].UpperLeft);
            Assert.AreEqual(new Point(20, 20), shapes[0].LowerRight);
        }

        // MovePointer Test
        [TestMethod()]
        public void MovePointerTest()
        {
            presentationModel.PressPointer(new DrawingModel.Point(10, 10));
            presentationModel.MovePointer(new DrawingModel.Point(20, 20));
            Shape shape = (Shape)modelPrivateObject.GetField("_hint");
            Assert.IsNull(shape);
            presentationModel.ChangeShape(DrawingModel.ShapeFactory.ShapeType.Ellipse);
            presentationModel.PressPointer(new DrawingModel.Point(10, 10));
            presentationModel.MovePointer(new DrawingModel.Point(20, 20));
            shape = (Shape)modelPrivateObject.GetField("_hint");
            Assert.IsNotNull(shape as Ellipse);
            Assert.AreEqual(new Point(10, 10), shape.UpperLeft);
            Assert.AreEqual(new Point(20, 20), shape.LowerRight);
        }

        // Click Test
        [TestMethod]
        public void ClickTest()
        {
            presentationModel.ChangeShape(ShapeFactory.ShapeType.Rectangle);
            presentationModel.PressPointer(new Point(0, 0));
            presentationModel.ReleasePointer(new Point(100, 100));
            Assert.AreEqual("", presentationModel.SelectInformationLabelText);
            // Simple Click
            presentationModel.Click(new Point(50, 50));
            Assert.AreEqual("Selected ： Rectangle(0, 0, 100, 100)", presentationModel.SelectInformationLabelText);
            presentationModel.Click(new Point(200, 250));
            Assert.AreEqual("", presentationModel.SelectInformationLabelText);
            // Undo
            presentationModel.Click(new Point(50, 50));
            presentationModel.Undo();
            Assert.AreEqual("", presentationModel.SelectInformationLabelText);
            // Redo
            presentationModel.Click(new Point(50, 50));
            presentationModel.Redo();
            Assert.AreEqual("", presentationModel.SelectInformationLabelText);
            // Clear
            presentationModel.Click(new Point(50, 50));
            presentationModel.Clear();
            Assert.AreEqual("", presentationModel.SelectInformationLabelText);
        }

        // Redo Undo Test
        [TestMethod]
        public void RedoUndoTest()
        {
            Assert.IsFalse(presentationModel.IsRedoEnable);
            Assert.IsFalse(presentationModel.IsUndoEnable);
            presentationModel.PressPointer(new Point(0, 0));
            presentationModel.ReleasePointer(new Point(100, 100));
            Assert.IsFalse(presentationModel.IsRedoEnable);
            Assert.IsFalse(presentationModel.IsUndoEnable);
            presentationModel.ChangeShape(ShapeFactory.ShapeType.Rectangle);
            presentationModel.PressPointer(new Point(0, 0));
            presentationModel.ReleasePointer(new Point(100, 100));
            Assert.IsFalse(presentationModel.IsRedoEnable);
            Assert.IsTrue(presentationModel.IsUndoEnable);
            presentationModel.ChangeShape(ShapeFactory.ShapeType.Ellipse);
            presentationModel.PressPointer(new Point(100, 0));
            presentationModel.ReleasePointer(new Point(200, 100));
            Assert.IsFalse(presentationModel.IsRedoEnable);
            Assert.IsTrue(presentationModel.IsUndoEnable);
            presentationModel.Undo();
            Assert.IsTrue(presentationModel.IsRedoEnable);
            Assert.IsTrue(presentationModel.IsUndoEnable);
            presentationModel.Undo();
            Assert.IsTrue(presentationModel.IsRedoEnable);
            Assert.IsFalse(presentationModel.IsUndoEnable);
            presentationModel.Redo();
            Assert.IsTrue(presentationModel.IsRedoEnable);
            Assert.IsTrue(presentationModel.IsUndoEnable);
            presentationModel.Clear();
            Assert.IsFalse(presentationModel.IsRedoEnable);
            Assert.IsFalse(presentationModel.IsUndoEnable);
        }

        // Draw Test
        [TestMethod()]
        public void DrawTest()
        {
            presentationModel.Draw(graphics);
        }

        // ChangeShape Test
        [TestMethod()]
        public void ChangeShapeTest()
        {
            ShapeFactory.ShapeType shapeType = (ShapeFactory.ShapeType)modelPrivateObject.GetField("_drawingShapeType");
            Assert.AreEqual(ShapeFactory.ShapeType.None, shapeType);
            presentationModel.ChangeShape(ShapeFactory.ShapeType.Ellipse);
            shapeType = (ShapeFactory.ShapeType)modelPrivateObject.GetField("_drawingShapeType");
            Assert.AreEqual(ShapeFactory.ShapeType.Ellipse, shapeType);
            presentationModel.ChangeShape(ShapeFactory.ShapeType.Rectangle);
            shapeType = (ShapeFactory.ShapeType)modelPrivateObject.GetField("_drawingShapeType");
            Assert.AreEqual(ShapeFactory.ShapeType.Rectangle, shapeType);
            presentationModel.ChangeShape(ShapeFactory.ShapeType.None);
            shapeType = (ShapeFactory.ShapeType)modelPrivateObject.GetField("_drawingShapeType");
            Assert.AreEqual(ShapeFactory.ShapeType.None, shapeType);
        }

        // Clear Test
        [TestMethod()]
        public void ClearTest()
        {
            presentationModel.Clear();
            presentationModel.Draw(graphics);
        }

        // Is Rectangle Button Enable Test
        [TestMethod]
        public void IsRectangleButtonEnableTest()
        {
            Assert.IsTrue(presentationModel.IsRectangleButtonEnable);
            presentationModel.ChangeShape(ShapeFactory.ShapeType.Rectangle);
            Assert.IsFalse(presentationModel.IsRectangleButtonEnable);
            presentationModel.Clear();
            Assert.IsFalse(presentationModel.IsRectangleButtonEnable);
            presentationModel.ChangeShape(ShapeFactory.ShapeType.Ellipse);
            Assert.IsTrue(presentationModel.IsRectangleButtonEnable);
            presentationModel.ChangeShape(ShapeFactory.ShapeType.Line);
            Assert.IsTrue(presentationModel.IsEllipseButtonEnable);
            presentationModel.ChangeShape(ShapeFactory.ShapeType.None);
            Assert.IsTrue(presentationModel.IsRectangleButtonEnable);
        }

        // Is Ellipse Button Enable Test
        [TestMethod]
        public void IsEllipseButtonEnableTest()
        {
            Assert.IsTrue(presentationModel.IsEllipseButtonEnable);
            presentationModel.ChangeShape(ShapeFactory.ShapeType.Rectangle);
            Assert.IsTrue(presentationModel.IsEllipseButtonEnable);
            presentationModel.ChangeShape(ShapeFactory.ShapeType.Line);
            Assert.IsTrue(presentationModel.IsEllipseButtonEnable);
            presentationModel.ChangeShape(ShapeFactory.ShapeType.Ellipse);
            Assert.IsFalse(presentationModel.IsEllipseButtonEnable);
            presentationModel.Clear();
            Assert.IsFalse(presentationModel.IsEllipseButtonEnable);
            presentationModel.ChangeShape(ShapeFactory.ShapeType.None);
            Assert.IsTrue(presentationModel.IsEllipseButtonEnable);
        }

        // Is Line Button Enable Test
        [TestMethod]
        public void IsLineButtonEnableTest()
        {
            Assert.IsTrue(presentationModel.IsLineButtonEnable);
            presentationModel.ChangeShape(ShapeFactory.ShapeType.Rectangle);
            Assert.IsTrue(presentationModel.IsLineButtonEnable);
            presentationModel.ChangeShape(ShapeFactory.ShapeType.Ellipse);
            Assert.IsTrue(presentationModel.IsLineButtonEnable);
            presentationModel.ChangeShape(ShapeFactory.ShapeType.Line);
            Assert.IsFalse(presentationModel.IsLineButtonEnable);
            presentationModel.Clear();
            Assert.IsFalse(presentationModel.IsLineButtonEnable);
            presentationModel.ChangeShape(ShapeFactory.ShapeType.None);
            Assert.IsTrue(presentationModel.IsLineButtonEnable);
        }

        // delegate Test
        [TestMethod]
        public void DelegateTest()
        {
            List<string> propertyNames = new List<string>()
            {
                nameof(FormPresentationModel.IsEllipseButtonEnable),
                nameof(FormPresentationModel.IsRectangleButtonEnable)
            };
            List<string> testingList = propertyNames.ToList();
            presentationModel.PropertyChanged += (sender, args) => { testingList.Remove(args.PropertyName); };
            Assert.AreEqual(propertyNames.Count, testingList.Count);
            presentationModel.ChangeShape(ShapeFactory.ShapeType.Ellipse);
            Assert.AreEqual(0, testingList.Count);
            testingList = propertyNames.ToList();
            presentationModel.ChangeShape(ShapeFactory.ShapeType.Rectangle);
            Assert.AreEqual(0, testingList.Count);
            testingList = propertyNames.ToList();
            presentationModel.Clear();
            Assert.AreEqual(propertyNames.Count, testingList.Count);
        }

        // Save Load Test
        [TestMethod]
        public void SaveLoadTest()
        {
            service.DeleteFile(Strings.FILE_NAME);
            List<Shape> shapes;
            presentationModel.ChangeShape(DrawingModel.ShapeFactory.ShapeType.Ellipse);
            presentationModel.PressPointer(new DrawingModel.Point(10, 10));
            presentationModel.ReleasePointer(new DrawingModel.Point(20, 20));
            presentationModel.ChangeShape(DrawingModel.ShapeFactory.ShapeType.Rectangle);
            presentationModel.PressPointer(new DrawingModel.Point(50, 10));
            presentationModel.ReleasePointer(new DrawingModel.Point(60, 20));
            presentationModel.ChangeShape(DrawingModel.ShapeFactory.ShapeType.Line);
            presentationModel.PressPointer(new DrawingModel.Point(15, 15));
            presentationModel.ReleasePointer(new DrawingModel.Point(55, 15));
            presentationModel.Save();
            shapes = (List<Shape>)shapesPrivateObject.GetField("_shapes");
            Assert.AreEqual(3, shapes.Count);
            while(!File.Exists(Strings.FILE_NAME))
            {
                Task.Delay(100);
            }
            presentationModel.ChangeShape(DrawingModel.ShapeFactory.ShapeType.Rectangle);
            presentationModel.PressPointer(new DrawingModel.Point(150, 110));
            presentationModel.ReleasePointer(new DrawingModel.Point(160, 120));
            presentationModel.Load();
            shapes = (List<Shape>)shapesPrivateObject.GetField("_shapes");
            Assert.AreEqual(3, shapes.Count);
        }
    }
}