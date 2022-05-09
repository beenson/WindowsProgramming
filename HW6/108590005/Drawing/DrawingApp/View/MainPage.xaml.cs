using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;

// 空白頁項目範本已記錄在 https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x404

namespace DrawingApp
{
    /// <summary>
    /// 可以在本身使用或巡覽至框架內的空白頁面。
    /// </summary>
    public sealed partial class MainPage : Page
    {
        AppPresentationModel _presentationModel;
        DrawingModel.IGraphics _iGraphics;

        public MainPage()
        {
            this.InitializeComponent();
            // Model
            _presentationModel = new AppPresentationModel(new DrawingModel.Model());
            // Note: 重複使用_igraphics物件
            _iGraphics = new View.WindowsStoreGraphicsAdaptor(_canvas);
            // Databinding
            DataContext = _presentationModel;
            // Events
            _canvas.PointerPressed += HandleCanvasPointerPressed;
            _canvas.PointerReleased += HandleCanvasPointerReleased;
            _canvas.PointerMoved += HandleCanvasPointerMoved;
            _clear.Click += HandleClearButtonClick;
            _rectangle.Click += HandleRectangleButtonClick;
            _ellipse.Click += HandleEllipseButtonClick;
            _presentationModel.GetModel()._modelChanged += HandleModelChanged;
        }

        // Rectangle Button Click
        private void HandleRectangleButtonClick(object sender, RoutedEventArgs e)
        {
            _presentationModel.ChangeShape(DrawingModel.ShapeFactory.ShapeType.Rectangle);
        }

        // Ellipse Button Click
        private void HandleEllipseButtonClick(object sender, RoutedEventArgs e)
        {
            _presentationModel.ChangeShape(DrawingModel.ShapeFactory.ShapeType.Ellipse);
        }

        // Clear Button Click
        private void HandleClearButtonClick(object sender, RoutedEventArgs e)
        {
            _presentationModel.Clear();
        }

        // Canvas Pointer Pressed
        public void HandleCanvasPointerPressed(object sender, PointerRoutedEventArgs e)
        {
            _presentationModel.PressPointer(new DrawingModel.Point(e.GetCurrentPoint(_canvas).Position.X, e.GetCurrentPoint(_canvas).Position.Y));
        }

        // Canvas Pointer Released
        public void HandleCanvasPointerReleased(object sender, PointerRoutedEventArgs e)
        {
            _presentationModel.ReleasePointer(new DrawingModel.Point(e.GetCurrentPoint(_canvas).Position.X, e.GetCurrentPoint(_canvas).Position.Y));
        }

        // Canvas Pointer Moved
        public void HandleCanvasPointerMoved(object sender, PointerRoutedEventArgs e)
        {
            _presentationModel.MovePointer(new DrawingModel.Point(e.GetCurrentPoint(_canvas).Position.X, e.GetCurrentPoint(_canvas).Position.Y));
        }

        // Model Changed
        public void HandleModelChanged()
        {
            _presentationModel.Draw(_iGraphics);
        }
    }
}
