using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingModel
{
    public class Ellipse : Shape
    {
        public Ellipse()
        {
            
        }

        public Ellipse(Point upperLeft, double width, double height)
        {
            this._point1 = upperLeft;
            this._point2 = new Point(upperLeft.X + width, upperLeft.Y + height);
        }

        // draw Ellipse
        public override void Draw(IGraphics graphics)
        {
            graphics.DrawEllipse(UpperLeft, Width, Height);
        }
    }
}
