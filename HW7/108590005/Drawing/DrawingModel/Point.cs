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
