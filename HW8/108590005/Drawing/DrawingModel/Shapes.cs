using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingModel
{
    public class Shapes
    {
        List<Shape> _shapes = new List<Shape>();
        Shape _selected;

        // Load
        public void Load(string shapesInformations)
        {
            Clear();
            JObject shapes = JObject.Parse(shapesInformations);
            foreach (JObject shapeInformation in shapes[Strings.SHAPES])
            {
                Shape shape = CreateShapeFromInformation(shapeInformation);
                _shapes.Add(shape);
            }
        }

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

        // Convert To Json
        public string ConvertToFile()
        {
            StringWriter stringWriter = new StringWriter();
            JsonTextWriter fileTextWriter = new JsonTextWriter(stringWriter);
            fileTextWriter.WriteStartObject();
            fileTextWriter.WritePropertyName(Strings.SHAPES);
            fileTextWriter.WriteStartArray();
            foreach (Shape shape in _shapes)
            {
                shape.Id = GetShapeId(shape);
                shape.WriteFile(fileTextWriter);
            }
            fileTextWriter.WriteEndArray();
            fileTextWriter.WriteEndObject();
            return stringWriter.ToString();
        }

        // Create Shape From Information
        private Shape CreateShapeFromInformation(JObject shapeInformation)
        {
            ShapeFactory.ShapeType shapeType = (ShapeFactory.ShapeType)(int)shapeInformation[Strings.SHAPE_TYPE];
            Shape shape = ShapeFactory.CreateShape(shapeType);
            switch (shapeType)
            {
                case ShapeFactory.ShapeType.Rectangle:
                case ShapeFactory.ShapeType.Ellipse:
                    shape.Point1 = new Point((int)shapeInformation[Strings.LEFT], (int)shapeInformation[Strings.UPPER]);
                    shape.Point2 = new Point((int)shapeInformation[Strings.RIGHT], (int)shapeInformation[Strings.LOWER]);
                    break;
                case ShapeFactory.ShapeType.Line:
                    ((Line)shape).Shape1 = _shapes[(int)shapeInformation[Strings.SHAPE1]];
                    ((Line)shape).Shape2 = _shapes[(int)shapeInformation[Strings.SHAPE2]];
                    break;
            }
            return shape;
        }

        // Get Shape Id
        private int GetShapeId(Shape shape)
        {
            return _shapes.IndexOf(shape);
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
