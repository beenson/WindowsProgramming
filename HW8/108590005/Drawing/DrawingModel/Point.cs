using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingModel
{
    public struct Point
    {
        public Point(double x, double y)
        {
            this.X = x;
            this.Y = y;
        }

        // Add
        public Point Add(Point point)
        {
            return new Point(this.X + point.X, this.Y + point.Y);
        }

        // Subtraction
        public Point Subtract(Point point)
        {
            return new Point(this.X - point.X, this.Y - point.Y);
        }

        /*public static Point operator +(Point point1, Point point2)
        {
            return new Point(point1.X + point2.X, point1.Y + point2.Y);
        }

        public static Point operator -(Point point1, Point point2)
        {
            return new Point(point1.X - point2.X, point1.Y - point2.Y);
        }*/

        public bool IsAvailable
        {
            get
            {
                return X >= 0 && Y >= 0;
            }
        }

        // To String
        public override string ToString()
        {
            return ((int)X).ToString() + Strings.COMMA + Strings.SPACE + ((int)Y).ToString();
        }

        public double X
        {
            get;
            set;
        }

        public double Y
        {
            get;
            set;
        }
    }
}
