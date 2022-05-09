using DrawingModel;
using Windows.UI;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;

namespace DrawingApp.View
{
    // Windows Store App的繪圖方式採用"物件"模型(與Windows Forms完全不同)
    // 當繪圖時，必須先建立"圖形物件"，再將"圖形物件"加入畫布的Children，此後該圖形就會被畫出來
    // 由於畫布管理其Children，因此有以下優缺點
    //   優點：畫布可以自行處理OnPaint()，而使用者則省掉處理OnPaint()的麻煩
    //   缺點：繪圖時必須先建立"圖形物件"；清除某圖形時，必須刪除Children中對應的物件
    class WindowsStoreGraphicsAdaptor : IGraphics
    {
        private Canvas _canvas;
        private const int LINE_WIDTH = 1;
        private const int CIRCLE_RADIUS = 5;
        private const int CIRCLE_DIAMETER = CIRCLE_RADIUS * 2;
        private const double OFFSET = (LINE_WIDTH + 1) / 2;
        private readonly double[] _dashes = new double[] { 5, 2, 2, 2 };

        public WindowsStoreGraphicsAdaptor(Canvas canvas)
        {
            this._canvas = canvas;
        }

        // Clear
        public void ClearAll()
        {
            // 清除Children也就清除畫布
            _canvas.Children.Clear();
        }

        // Draw Ellipse
        public void DrawEllipse(Point point, double width, double height)
        {
            Windows.UI.Xaml.Shapes.Ellipse ellipse = new Windows.UI.Xaml.Shapes.Ellipse();
            ellipse.Fill = new SolidColorBrush(Colors.Orange);
            ellipse.Stroke = new SolidColorBrush(Colors.Black);
            ellipse.StrokeThickness = LINE_WIDTH;
            ellipse.Width = width;
            ellipse.Height = height;
            ellipse.Margin = new Windows.UI.Xaml.Thickness(point.X, point.Y, 0, 0);
            _canvas.Children.Add(ellipse);
        }

        // Draw Rectangle
        public void DrawRectangle(Point point, double width, double height)
        {
            Windows.UI.Xaml.Shapes.Rectangle rectangle = new Windows.UI.Xaml.Shapes.Rectangle();
            rectangle.Fill = new SolidColorBrush(Colors.Yellow);
            rectangle.Stroke = new SolidColorBrush(Colors.Black);
            rectangle.StrokeThickness = LINE_WIDTH;
            rectangle.Width = width + LINE_WIDTH;
            rectangle.Height = height + LINE_WIDTH;
            rectangle.Margin = new Windows.UI.Xaml.Thickness(point.X, point.Y, 0, 0);
            _canvas.Children.Add(rectangle);
        }

        // Draw Line
        public void DrawLine(Point start, Point end)
        {
            Windows.UI.Xaml.Shapes.Line line = new Windows.UI.Xaml.Shapes.Line();
            line.Stroke = new SolidColorBrush(Colors.Black);
            line.StrokeThickness = LINE_WIDTH;
            line.X1 = start.X;
            line.Y1 = start.Y;
            line.X2 = end.X;
            line.Y2 = end.Y;
            _canvas.Children.Add(line);
        }

        // Draw Selected
        public void DrawSelected(Point point, double width, double height)
        {
            Windows.UI.Xaml.Shapes.Rectangle selected = new Windows.UI.Xaml.Shapes.Rectangle();
            selected.Stroke = new SolidColorBrush(Colors.Red);
            selected.StrokeThickness = LINE_WIDTH + 1;
            selected.Width = width + selected.StrokeThickness;
            selected.Height = height + selected.StrokeThickness;
            selected.Margin = new Windows.UI.Xaml.Thickness(point.X - OFFSET, point.Y - OFFSET, 0, 0);
            DoubleCollection dash = new DoubleCollection();
            foreach (double d in _dashes)
                dash.Add(d);
            selected.StrokeDashArray = dash;
            _canvas.Children.Add(selected);
            double right = point.X + width;
            double down = point.Y + height;
            DrawCircle(new Point(point.X, point.Y));
            DrawCircle(new Point(right, point.Y));
            DrawCircle(new Point(point.X, down));
            DrawCircle(new Point(right, down));
        }

        // Draw Circle
        private void DrawCircle(Point point)
        {
            Windows.UI.Xaml.Shapes.Ellipse circle = new Windows.UI.Xaml.Shapes.Ellipse();
            circle.Fill = new SolidColorBrush(Colors.White);
            circle.Stroke = new SolidColorBrush(Colors.Black);
            circle.Width = CIRCLE_DIAMETER;
            circle.Height = CIRCLE_DIAMETER;
            circle.Margin = new Windows.UI.Xaml.Thickness(point.X - CIRCLE_RADIUS, point.Y - CIRCLE_RADIUS, 0, 0);
            _canvas.Children.Add(circle);
        }
    }
}