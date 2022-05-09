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
        Canvas _canvas;
        const int LINE_WIDTH = 5;

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
            rectangle.Width = width;
            rectangle.Height = height;
            rectangle.Margin = new Windows.UI.Xaml.Thickness(point.X, point.Y, 0, 0);
            _canvas.Children.Add(rectangle);
        }
    }
}