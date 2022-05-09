using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DrawingModel;

namespace DrawingTests
{
    class UnitTestGraphicsAdaptor : IGraphics
    {
        List<Shape> _shapes = new List<Shape>();

        // ClearAll
        public void ClearAll()
        {
            _shapes.Clear();
        }

        // Draw Ellipse
        public void DrawEllipse(Point point, double width, double height)
        {
            Ellipse ellipse = new Ellipse(point, width, height);
            _shapes.Add(ellipse);
        }

        // Draw Rectangle
        public void DrawRectangle(Point point, double width, double height)
        {
            Rectangle rectangle = new Rectangle(point, width, height);
            _shapes.Add(rectangle);
        }

        // Get Last
        public Shape GetLastDraw()
        {
            return _shapes.Last();
        }

        // Get All
        public List<Shape> GetAll()
        {
            return _shapes;
        }
    }
}
