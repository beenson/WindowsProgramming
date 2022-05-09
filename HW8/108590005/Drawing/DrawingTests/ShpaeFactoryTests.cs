using Microsoft.VisualStudio.TestTools.UnitTesting;
using DrawingModel;
using System;

namespace DrawingModel.Tests
{
    [TestClass]
    public class ShpaeFactoryTests
    {
        // Create None
        [TestMethod]
        public void CreateNoneTest()
        {
            Assert.IsNull(ShapeFactory.CreateShape(ShapeFactory.ShapeType.None));
        }

        // Create Ellipse
        [TestMethod]
        public void CreateEllipseTest()
        {
            Assert.IsNotNull(ShapeFactory.CreateShape(ShapeFactory.ShapeType.Ellipse) as Ellipse);
        }

        // Create Rectangle
        [TestMethod]
        public void CreateRectangleTest()
        {
            Assert.IsNotNull(ShapeFactory.CreateShape(ShapeFactory.ShapeType.Rectangle) as Rectangle);
        }

        // Create Line
        [TestMethod]
        public void CreateLineTest()
        {
            Assert.IsNotNull(ShapeFactory.CreateShape(ShapeFactory.ShapeType.Line) as Line);
        }

        // Create Unknown Shape
        [TestMethod]
        public void CreateUnknownTest()
        {
            Assert.IsNull(ShapeFactory.CreateShape((ShapeFactory.ShapeType)10));
        }
    }
}
