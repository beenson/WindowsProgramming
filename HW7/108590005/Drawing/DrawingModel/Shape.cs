using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingModel
{
    public abstract class Shape
    {
        private const int TWO = 2;

        public enum DrawLayer
        {
            All,
            Line,
            WithOutLine
        }

        // draw
        public abstract void Draw(IGraphics graphics, DrawLayer layer = DrawLayer.All);

        // Is Point In Shape
        public abstract bool IsPointInShape(Point point);

        // To String
        public override string ToString()
        {
            return this.GetType().Name + Strings.LEFT + UpperLeft + Strings.COMMA + Strings.SPACE + LowerRight + Strings.RIGHT;
        }

        protected Point _point1;
        public virtual Point Point1
        {
            get
            {
                return _point1;
            }
            set
            {
                _point1 = value;
            }
        }

        protected Point _point2;
        public virtual Point Point2
        {
            get
            {
                return _point2;
            }
            set
            {
                _point2 = value;
            }
        }

        public Point UpperLeft
        {
            get
            {
                return new Point(Math.Min(Point1.X, Point2.X), Math.Min(Point1.Y, Point2.Y));
            }
        }

        public Point LowerRight
        {
            get
            {
                return new Point(Math.Max(Point1.X, Point2.X), Math.Max(Point1.Y, Point2.Y));
            }
        }

        public Point center
        {
            get
            {
                return new Point((Point1.X + Point2.X) / TWO, (Point1.Y + Point2.Y) / TWO);
            }
        }

        public double Height
        {
            get
            {
                return Math.Abs(Point1.Y - Point2.Y);
            }
        }
        public double Width
        {
            get
            {
                return Math.Abs(Point1.X - Point2.X);
            }
        }
    }
}
