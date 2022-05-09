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
            this._point1 = upperLeft;
            this._point2 = new Point(upperLeft.X + width, upperLeft.Y + height);
        }

        // draw rectangle
        public override void Draw(IGraphics graphics)
        {
            graphics.DrawRectangle(UpperLeft, Width, Height);
        }
    }
}
