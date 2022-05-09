using System.Drawing;
using System.Windows.Forms;

namespace DrawingForm
{
    public partial class DrawingForm : Form
    {
        public const string CANVAS_NAME = "_canvas";
        private const string ENABLED = "Enabled";
        FormPresentationModel _presentationModel;
        Panel _canvas = new DoubleBufferedPanel();

        public DrawingForm(FormPresentationModel presentationModel)
        {
            InitializeComponent();
            //
            // prepare canvas
            //
            _canvas.Name = CANVAS_NAME;
            _canvas.Dock = DockStyle.Fill;
            _canvas.BackColor = Color.LightYellow;
            _canvas.MouseDown += HandleCanvasPointerPressed;
            _canvas.MouseUp += HandleCanvasPointerReleased;
            _canvas.MouseMove += HandleCanvasPointerMoved;
            _canvas.Paint += HandleCanvasPaint;
            // Note: setting "_canvas.DoubleBuffered = true" does not work
            Controls.Add(_canvas);
            //
            // prepare presentation model and model
            //
            _presentationModel = presentationModel;
            _presentationModel.GetModel()._modelChanged += HandleModelChanged;
            // databinding
            _rectangleButton.DataBindings.Add(ENABLED, _presentationModel, nameof(FormPresentationModel.IsRectangleButtonEnable));
            _ellipseButton.DataBindings.Add(ENABLED, _presentationModel, nameof(FormPresentationModel.IsEllipseButtonEnable));
        }

        // Clear Button Click
        public void HandleClearButtonClick(object sender, System.EventArgs e)
        {
            _presentationModel.Clear();
        }

        // Pointer Pressed
        public void HandleCanvasPointerPressed(object sender, MouseEventArgs e)
        {
            _presentationModel.PressPointer(new DrawingModel.Point(e.X, e.Y));
        }

        // Pointer Released
        public void HandleCanvasPointerReleased(object sender, MouseEventArgs e)
        {
            _presentationModel.ReleasePointer(new DrawingModel.Point(e.X, e.Y));
        }

        // Pointer Moved
        public void HandleCanvasPointerMoved(object sender, MouseEventArgs e)
        {
            _presentationModel.MovePointer(new DrawingModel.Point(e.X, e.Y));
        }

        // Canvas Paint
        public void HandleCanvasPaint(object sender, PaintEventArgs e)
        {
            // e.Graphics物件是Paint事件帶進來的，只能在當次Paint使用
            // 而Adaptor又直接使用e.Graphics，因此，Adaptor不能重複使用
            // 每次都要重新new
            _presentationModel.Draw(new PresentationModel.WindowsFormsGraphicsAdaptor(e.Graphics));
        }

        // Model Changed
        public void HandleModelChanged()
        {
            Invalidate(true);
        }

        // Ellipse Button Click
        private void HandleEllipseButtonClick(object sender, System.EventArgs e)
        {
            _presentationModel.ChangeShape(DrawingModel.ShapeFactory.ShapeType.Ellipse);
        }

        // Rectangle Button Click
        private void HandleRectangleButtonClick(object sender, System.EventArgs e)
        {
            _presentationModel.ChangeShape(DrawingModel.ShapeFactory.ShapeType.Rectangle);
        }
    }
}
