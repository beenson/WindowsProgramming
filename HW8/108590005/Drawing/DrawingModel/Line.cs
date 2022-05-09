using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingModel
{
    public class Line : Shape
    {
        public Line()
        {
            _shapeType = ShapeFactory.ShapeType.Line;
        }

        // Draw Line
        public override void Draw(IGraphics graphics, DrawLayer layer = DrawLayer.All)
        {
            if (layer != DrawLayer.All && layer != DrawLayer.Line)
                return;
            graphics.DrawLine(Point1, Point2);
        }

        // Is Point In Shape
        public override bool IsPointInShape(Point point)
        {
            return false;
        }

        // Write To Json
        public override void WriteFile(JsonTextWriter fileTextWriter)
        {
            fileTextWriter.WriteStartObject();
            fileTextWriter.WritePropertyName(Strings.ID);
            fileTextWriter.WriteValue(Id);
            fileTextWriter.WritePropertyName(Strings.SHAPE_TYPE);
            fileTextWriter.WriteValue(ShapeType);
            fileTextWriter.WritePropertyName(Strings.SHAPE1);
            fileTextWriter.WriteValue(_shape1.Id);
            fileTextWriter.WritePropertyName(Strings.SHAPE2);
            fileTextWriter.WriteValue(_shape2.Id);
            fileTextWriter.WriteEndObject();
        }

        Shape _shape1;
        public Shape Shape1
        {
            set
            {
                _shape1 = value;
            }
        }

        Shape _shape2;
        public Shape Shape2
        {
            set
            {
                _shape2 = value;
            }
        }

        public override Point Point1
        {
            get
            {
                if (_shape1 != null)
                    return _shape1.center;
                return _point1;
            }
        }

        public override Point Point2
        {
            get
            {
                if (_shape2 != null)
                    return _shape2.center;
                return _point2;
            }
        }
    }
}
