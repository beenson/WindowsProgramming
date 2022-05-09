using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingModel
{
    public class Rectangle : Shape
    {
        public Rectangle()
        {

        }
        
        public Rectangle(Point upperLeft, double width, double height)
        {
            this.Point1 = upperLeft;
            this.Point2 = new Point(upperLeft.X + width, upperLeft.Y + height);
        }

        // draw rectangle
        public override void Draw(IGraphics graphics, DrawLayer layer = DrawLayer.All)
        {
            if (layer != DrawLayer.All && layer != DrawLayer.WithOutLine)
                return;
            graphics.DrawRectangle(UpperLeft, Width, Height);
        }

        // Is Point In Shape
        public override bool IsPointInShape(Point point)
        {
            return IsBetween(point.X, LowerRight.X, UpperLeft.X) && IsBetween(point.Y, LowerRight.Y, UpperLeft.Y);
        }

        // Is Between Two Value
        private bool IsBetween(double value, double high, double low)
        {
            return value <= high && value >= low;
        }
    }
}
