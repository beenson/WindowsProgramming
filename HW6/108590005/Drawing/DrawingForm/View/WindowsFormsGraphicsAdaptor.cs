using DrawingModel;
using System.Drawing;

namespace DrawingForm.PresentationModel
{
    class WindowsFormsGraphicsAdaptor : IGraphics
    {
        Graphics _graphics;

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
    }
}
