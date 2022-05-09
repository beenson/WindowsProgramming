using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingModel
{
    public class Ellipse : Shape
    {
        const int TWO = 2;

        public Ellipse()
        {

        }

        public Ellipse(Point upperLeft, double width, double height)
        {
            this.Point1 = upperLeft;
            this.Point2 = new Point(upperLeft.X + width, upperLeft.Y + height);
        }

        // draw Ellipse
        public override void Draw(IGraphics graphics, DrawLayer layer = DrawLayer.All)
        {
            if (layer != DrawLayer.All && layer != DrawLayer.WithOutLine)
                return;
            graphics.DrawEllipse(UpperLeft, Width, Height);
        }

        // Is Point In Shape
        public override bool IsPointInShape(Point point)
        {
            return ((Math.Pow(GetSubstract(center.X, point.X), TWO) / Math.Pow(Width / TWO, TWO)) + (Math.Pow(GetSubstract(center.Y, point.Y), TWO) / Math.Pow(Height / TWO, TWO))) <= 1;
        }

        // Get Substract
        private double GetSubstract(double number1, double number2)
        {
            return number2 - number1;
        }
    }
}
