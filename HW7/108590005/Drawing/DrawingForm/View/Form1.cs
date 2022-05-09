using System;
using System.Drawing;
using System.Windows.Forms;

namespace DrawingForm
{
    public partial class DrawingForm : Form
    {
        public const string CANVAS_NAME = "_canvas";
        private const string ENABLED = "Enabled";
        private const string TEXT = "Text";
        FormPresentationModel _presentationModel;
        Panel _canvas = new DoubleBufferedPanel();

        public DrawingForm(FormPresentationModel presentationModel)
        {
            DrawingModel.Model model = presentationModel.GetModel();
            InitializeComponent();
            this.AutoScaleMode = AutoScaleMode.Dpi;
            // prepare canvas
            _canvas.Name = CANVAS_NAME;
            _canvas.Dock = DockStyle.Fill;
            _canvas.BackColor = Color.LightYellow;
            _canvas.MouseDown += HandleCanvasPointerPressed;
            _canvas.MouseUp += HandleCanvasPointerReleased;
            _canvas.MouseMove += HandleCanvasPointerMoved;
            _canvas.Click += HandleCanvasClick;
            _canvas.Paint += HandleCanvasPaint;
            // Note: setting "_canvas.DoubleBuffered = true" does not work
            Controls.Add(_canvas);
            // set label background to transparent
            _shapeInformationLabel.BackColor = Color.LightYellow;
            // prepare presentation model and model
            _presentationModel = presentationModel;
            model._shapesChanged += HandleModelChanged;
            _undoToolStripMenuItem.Enabled = false;
            _redoToolStripMenuItem.Enabled = false;
            // databinding
            _rectangleButton.DataBindings.Add(ENABLED, _presentationModel, nameof(FormPresentationModel.IsRectangleButtonEnable));
            _ellipseButton.DataBindings.Add(ENABLED, _presentationModel, nameof(FormPresentationModel.IsEllipseButtonEnable));
            _lineButton.DataBindings.Add(ENABLED, _presentationModel, nameof(FormPresentationModel.IsLineButtonEnable));
            _shapeInformationLabel.DataBindings.Add(TEXT, _presentationModel, nameof(FormPresentationModel.SelectInformationLabelText));
        }

        // Canvas Click
        private void HandleCanvasClick(object sender, EventArgs e)
        {
            MouseEventArgs mouse = e as MouseEventArgs;
            _presentationModel.Click(new DrawingModel.Point(mouse.X, mouse.Y));
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
            _undoToolStripMenuItem.Enabled = _presentationModel.IsUndoEnable;
            _redoToolStripMenuItem.Enabled = _presentationModel.IsRedoEnable;
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

        // Line Button Click
        private void HandleLineButtonClick(object sender, System.EventArgs e)
        {
            _presentationModel.ChangeShape(DrawingModel.ShapeFactory.ShapeType.Line);
        }

        // Undo Click
        private void ClickUndo(object sender, EventArgs e)
        {
            _presentationModel.Undo();
        }

        // Redo Click
        private void ClickRedo(object sender, EventArgs e)
        {
            _presentationModel.Redo();
        }
    }
}
