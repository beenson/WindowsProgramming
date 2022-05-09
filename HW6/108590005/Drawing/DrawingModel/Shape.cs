using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingModel
{
    public abstract class Shape
    {
        // draw
        public abstract void Draw(IGraphics graphics);

        public Point _point1
        {
            get;
            set;
        }

        public Point _point2
        {
            get;
            set;
        }

        public Point UpperLeft
        {
            get
            {
                return new Point(Math.Min(_point1.X, _point2.X), Math.Min(_point1.Y, _point2.Y));
            }
        }

        public Point LowerRight
        {
            get
            {
                return new Point(Math.Max(_point1.X, _point2.X), Math.Max(_point1.Y, _point2.Y));
            }
        }

        public double Height
        {
            get
            {
                return Math.Abs(_point1.Y - _point2.Y);
            }
        }
        public double Width
        {
            get
            {
                return Math.Abs(_point1.X - _point2.X);
            }
        }
    }
}
