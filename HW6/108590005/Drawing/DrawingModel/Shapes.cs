using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingModel
{
    public class Shapes
    {
        List<Shape> _shapes = new List<Shape>();

        // Draw shapes
        public void Draw(IGraphics graphics)
        {
            graphics.ClearAll();
            foreach (Shape shape in _shapes)
            {
                shape.Draw(graphics);
            }
        }

        // Clear shapes list
        public void Clear()
        {
            _shapes.Clear();
        }

        // Add Shape into list
        public void AddShape(ShapeFactory.ShapeType shapeType, Point point1, Point point2)
        {
            Shape newShape = ShapeFactory.CreateShape(shapeType);
            newShape._point1 = point1;
            newShape._point2 = point2;
            _shapes.Add(newShape);
        }
    }
}
