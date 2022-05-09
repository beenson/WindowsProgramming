using System;
using System.Collections.Generic;
using System.Linq;
using DrawingApp;
using DrawingModel;
using DrawingTests;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DrawingAppTests.Tests
{
    [TestClass]
    public class AppPresentationModelTests
    {
        Model model;
        AppPresentationModel presentationModel;
        DrawingTests.UnitTestGraphicsAdaptor graphics;

        // Initialize
        [TestInitialize]
        public void Initizlize()
        {
            model = new Model();
            presentationModel = new AppPresentationModel(model);
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
            presentationModel.ChangeShape(DrawingModel.ShapeFactory.ShapeType.Ellipse);
            presentationModel.PressPointer(new DrawingModel.Point(20, 20));
        }

        // ReleasePointer Test
        [TestMethod()]
        public void ReleasePointerTest()
        {
            presentationModel.PressPointer(new DrawingModel.Point(10, 10));
            presentationModel.ReleasePointer(new DrawingModel.Point(20, 20));
            presentationModel.ChangeShape(DrawingModel.ShapeFactory.ShapeType.Ellipse);
            presentationModel.PressPointer(new DrawingModel.Point(10, 10));
            presentationModel.ReleasePointer(new DrawingModel.Point(20, 20));
        }

        // MovePointer Test
        [TestMethod()]
        public void MovePointerTest()
        {
            presentationModel.PressPointer(new DrawingModel.Point(10, 10));
            presentationModel.MovePointer(new DrawingModel.Point(20, 20));
            presentationModel.ChangeShape(DrawingModel.ShapeFactory.ShapeType.Ellipse);
            presentationModel.PressPointer(new DrawingModel.Point(10, 10));
            presentationModel.MovePointer(new DrawingModel.Point(20, 20));
        }

        // Draw Test
        [TestMethod()]
        public void DrawTest()
        {
            presentationModel.Draw(graphics);
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
                nameof(AppPresentationModel.IsEllipseButtonEnable),
                nameof(AppPresentationModel.IsRectangleButtonEnable)
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
