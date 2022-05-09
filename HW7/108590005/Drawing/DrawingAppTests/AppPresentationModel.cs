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
