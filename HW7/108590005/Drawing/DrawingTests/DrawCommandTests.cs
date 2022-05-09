using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace DrawingModel.Tests
{
    [TestClass]
    public class DrawCommandTests
    {
        Model model;
        Shape A, B, C;
        DrawCommand commandA, commandB, commandC;
        PrivateObject shapesPrivateObject;

        //Initialize
        [TestInitialize]
        public void Initialize()
        {
            model = new Model();
            A = new Ellipse();
            B = new Rectangle();
            C = new Line();
            commandA = new DrawCommand(model, A);
            commandB = new DrawCommand(model, B);
            commandC = new DrawCommand(model, C);
            PrivateObject privateObject = new PrivateObject(model);
            shapesPrivateObject = new PrivateObject(privateObject.GetField("_shapes"));
        }

        // Execute and UnExecute Test
        [TestMethod]
        public void ExecuteUnExecuteTest()
        {
            commandA.Execute();
            List<Shape> shapes = (List<Shape>)shapesPrivateObject.GetField("_shapes");
            Assert.AreEqual(1, shapes.Count);
            Assert.IsTrue(shapes.Contains(A));
            commandC.Execute();
            shapes = (List<Shape>)shapesPrivateObject.GetField("_shapes");
            Assert.AreEqual(2, shapes.Count);
            Assert.IsTrue(shapes.Contains(A));
            Assert.IsTrue(shapes.Contains(C));
            commandB.Execute();
            shapes = (List<Shape>)shapesPrivateObject.GetField("_shapes");
            Assert.AreEqual(3, shapes.Count);
            Assert.IsTrue(shapes.Contains(A));
            Assert.IsTrue(shapes.Contains(C));
            Assert.IsTrue(shapes.Contains(B));
            commandC.Revoke();
            shapes = (List<Shape>)shapesPrivateObject.GetField("_shapes");
            Assert.AreEqual(2, shapes.Count);
            Assert.IsTrue(shapes.Contains(A));
            Assert.IsTrue(shapes.Contains(B));
            commandB.Revoke();
            shapes = (List<Shape>)shapesPrivateObject.GetField("_shapes");
            Assert.AreEqual(1, shapes.Count);
            Assert.IsTrue(shapes.Contains(A));
            commandA.Revoke();
            shapes = (List<Shape>)shapesPrivateObject.GetField("_shapes");
            Assert.AreEqual(0, shapes.Count);
        }
    }
}
