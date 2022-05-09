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
        Shape _selected;

        // Draw shapes
        public void Draw(IGraphics graphics)
        {
            graphics.ClearAll();
            Shape.DrawLayer[] layers = (Shape.DrawLayer[])Enum.GetValues(typeof(Shape.DrawLayer));
            foreach (Shape.DrawLayer layer in layers.Skip(1).ToArray())
                foreach (Shape shape in _shapes)
                    shape.Draw(graphics, layer);

            if (_selected != null)
                graphics.DrawSelected(_selected.UpperLeft, _selected.Width, _selected.Height);
        }

        // Clear shapes list
        public void Clear()
        {
            _shapes.Clear();
            ResetSelected();
        }

        // Reset Selected
        public void ResetSelected()
        {
            _selected = null;
        }

        // Add Shape into list
        public bool AddShape(Shape shape)
        {
            _shapes.Add(shape);
            return true;
        }

        // Remove Shape
        public void RemoveShape(Shape shape)
        {
            _shapes.Remove(shape);
        }

        // Select Shape
        public bool SelectShape(Point point)
        {
            _selected = GetShapeOnPoint(point);
            return _selected != null;
        }

        // Get Shape On Point
        public Shape GetShapeOnPoint(Point point)
        {
            for (int i = _shapes.Count - 1; i >= 0; i--)
                if (_shapes[i].IsPointInShape(point))
                    return _shapes[i];

            return null;
        }

        public Shape SelectedShape
        {
            get
            {
                return _selected;
            }
        }
    }
}
