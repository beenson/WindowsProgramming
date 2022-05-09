using DrawingModel;
using System.Drawing;

namespace DrawingForm.PresentationModel
{
    class WindowsFormsGraphicsAdaptor : IGraphics
    {
        private Graphics _graphics;
        private const int PEN_WIDTH = 3;
        private const int CIRCLE_RADIUS = 5;
        private const int CIRCLE_DIAMETER = CIRCLE_RADIUS * 2;

        public WindowsFormsGraphicsAdaptor(Graphics graphics)
        {
            this._graphics = graphics;
        }

        // Clear
        public void ClearAll()
        {
            // OnPaint時會自動清除畫面，因此不需實作
        }

        // Draw Ellipse
        public void DrawEllipse(DrawingModel.Point point, double width, double height)
        {
            SolidBrush brush = new SolidBrush(Color.Orange);
            _graphics.FillEllipse(brush, (float)point.X, (float)point.Y, (float)width, (float)height);
            _graphics.DrawEllipse(Pens.Black, (float)point.X, (float)point.Y, (float)width, (float)height);
        }

        // Draw Rectangle
        public void DrawRectangle(DrawingModel.Point point, double width, double height)
        {
            SolidBrush brush = new SolidBrush(Color.Yellow);
            _graphics.FillRectangle(brush, (float)point.X, (float)point.Y, (float)width, (float)height);
            _graphics.DrawRectangle(Pens.Black, (float)point.X, (float)point.Y, (float)width, (float)height);
        }

        // Draw Line
        public void DrawLine(DrawingModel.Point start, DrawingModel.Point end)
        {
            _graphics.DrawLine(Pens.Black, (float)start.X, (float)start.Y, (float)end.X, (float)end.Y);
        }

        // Draw Selected
        public void DrawSelected(DrawingModel.Point point, double width, double height)
        {
            Pen pen = new Pen(Brushes.Red);
            pen.DashStyle = System.Drawing.Drawing2D.DashStyle.DashDotDot;
            pen.Width = PEN_WIDTH;
            _graphics.DrawRectangle(pen, (float)point.X, (float)point.Y, (float)width, (float)height);
            double right = point.X + width;
            double down = point.Y + height;
            DrawCircle(point);
            DrawCircle(new DrawingModel.Point(right, point.Y));
            DrawCircle(new DrawingModel.Point(point.X, down));
            DrawCircle(new DrawingModel.Point(right, down));
        }

        // Draw Circle
        private void DrawCircle(DrawingModel.Point point)
        {
            int offset = CIRCLE_RADIUS;
            SolidBrush brush = new SolidBrush(Color.White);
            _graphics.FillEllipse(brush, (float)point.X - offset, (float)point.Y - offset, CIRCLE_DIAMETER, CIRCLE_DIAMETER);
            _graphics.DrawEllipse(Pens.Black, (float)point.X - offset, (float)point.Y - offset, CIRCLE_DIAMETER, CIRCLE_DIAMETER);
        }
    }
}
