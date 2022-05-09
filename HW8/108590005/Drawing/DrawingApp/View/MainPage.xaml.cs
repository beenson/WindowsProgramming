using DrawingModel;
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
            _presentationModel = new AppPresentationModel(new Model(new GoogleDriveService(Strings.APPLICATION_NAME, Strings.CLIENT_SECRET_FILE_NAME)));
            // Note: 重複使用_igraphics物件
            _iGraphics = new View.WindowsStoreGraphicsAdaptor(_canvas);
            // Databinding
            DataContext = _presentationModel;
            // Set Shape Button
            _rectangle.Tag = DrawingModel.ShapeFactory.ShapeType.Rectangle;
            _ellipse.Tag = DrawingModel.ShapeFactory.ShapeType.Ellipse;
            _line.Tag = DrawingModel.ShapeFactory.ShapeType.Line;
            _rectangle.Click += HandleShapeButtonClick;
            _ellipse.Click += HandleShapeButtonClick;
            _line.Click += HandleShapeButtonClick;
            _save.Click += HandleSaveButtonClick;
            _load.Click += HandleLoadButtonClick;
            // Events
            _canvas.PointerPressed += HandleCanvasPointerPressed;
            _canvas.PointerReleased += HandleCanvasPointerReleased;
            _canvas.PointerMoved += HandleCanvasPointerMoved;
            _clear.Click += HandleClearButtonClick;
            _undoMenuItem.Click += HandleUndoClick;
            _redoMenuItem.Click += HandleRedoClick;

            _presentationModel.GetModel()._shapesChanged += HandleModelChanged;
        }

        // Save
        private void HandleSaveButtonClick(object sender, RoutedEventArgs e)
        {
            _presentationModel.Save();
        }

        // Load
        private void HandleLoadButtonClick(object sender, RoutedEventArgs e)
        {
            _presentationModel.Load();
        }

        // Undo
        private void HandleUndoClick(object sender, RoutedEventArgs e)
        {
            _presentationModel.Undo();
        }

        // Redo
        private void HandleRedoClick(object sender, RoutedEventArgs e)
        {
            _presentationModel.Redo();
        }

        // Shapes Button Click
        private void HandleShapeButtonClick(object sender, RoutedEventArgs e)
        {
            _presentationModel.ChangeShape((DrawingModel.ShapeFactory.ShapeType)((Button)sender).Tag);
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
            DrawingModel.Point point = new DrawingModel.Point(e.GetCurrentPoint(_canvas).Position.X, e.GetCurrentPoint(_canvas).Position.Y);
            _presentationModel.Click(point);
            _presentationModel.ReleasePointer(point);
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
