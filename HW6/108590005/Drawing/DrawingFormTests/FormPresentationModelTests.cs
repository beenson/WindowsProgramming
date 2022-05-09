using Microsoft.VisualStudio.TestTools.UnitTesting;
using DrawingForm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DrawingModel;

namespace DrawingForm.Tests
{
    [TestClass()]
    public class FormPresentationModelTests
    {
        Model model;
        FormPresentationModel presentationModel;
        PrivateObject modelPrivateObject, shapesPrivateObject, presentationModelPrivateObject;
        DrawingTests.UnitTestGraphicsAdaptor graphics;

        // Initialize
        [TestInitialize]
        public void Initizlize()
        {
            model = new Model();
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
            Assert.AreEqual(new Point(20, 20), shape._point1);
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
            ShapeFactory.ShapeType shapeType = (ShapeFactory.ShapeType)presentationModelPrivateObject.GetField("_shapeType");
            Assert.AreEqual(ShapeFactory.ShapeType.None, shapeType);
            presentationModel.ChangeShape(ShapeFactory.ShapeType.Ellipse);
            shapeType = (ShapeFactory.ShapeType)presentationModelPrivateObject.GetField("_shapeType");
            Assert.AreEqual(ShapeFactory.ShapeType.Ellipse, shapeType);
            presentationModel.ChangeShape(ShapeFactory.ShapeType.Rectangle);
            shapeType = (ShapeFactory.ShapeType)presentationModelPrivateObject.GetField("_shapeType");
            Assert.AreEqual(ShapeFactory.ShapeType.Rectangle, shapeType);
            presentationModel.ChangeShape(ShapeFactory.ShapeType.None);
            shapeType = (ShapeFactory.ShapeType)presentationModelPrivateObject.GetField("_shapeType");
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
            presentationModel.ChangeShape(ShapeFactory.ShapeType.Ellipse);
            Assert.IsFalse(presentationModel.IsEllipseButtonEnable);
            presentationModel.Clear();
            Assert.IsFalse(presentationModel.IsEllipseButtonEnable);
            presentationModel.ChangeShape(ShapeFactory.ShapeType.None);
            Assert.IsTrue(presentationModel.IsEllipseButtonEnable);
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
    }
}