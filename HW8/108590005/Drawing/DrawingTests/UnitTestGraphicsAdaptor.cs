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
        const string SELECT_TWO_EXCEPTION = "There should not be two shape selected at the same time";
        List<Shape> _shapes = new List<Shape>();
        Shape _selected;

        // ClearAll
        public void ClearAll()
        {
            _shapes.Clear();
            _selected = null;
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

        // Draw Line
        public void DrawLine(Point start, Point end)
        {
            Line line = new Line();
            line.Point1 = start;
            line.Point2 = end;
            _shapes.Add(line);
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

        // Draw Selected
        public void DrawSelected(Point point, double width, double height)
        {
            if (_selected != null)
                throw new Exception(SELECT_TWO_EXCEPTION);
            _selected = new Rectangle(point, width, height);
        }

        public Shape Selected
        {
            get
            {
                return _selected;
            }
        }
    }
}
