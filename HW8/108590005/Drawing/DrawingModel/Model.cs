using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace DrawingModel
{
    public class Model
    {
        public event ShapesChangedEventHandler _shapesChanged;
        public delegate void ShapesChangedEventHandler();
        public event SelectedChangedEventHandler _selectedChanged;
        public delegate void SelectedChangedEventHandler();
        private const ShapeFactory.ShapeType DEFAULT_SHAPE_TYPE = ShapeFactory.ShapeType.None;
        bool _isPressed = false;
        Shapes _shapes = new Shapes();
        CommandManager _commandManager = new CommandManager();
        Shape _hint;
        ShapeFactory.ShapeType _drawingShapeType;
        IState _state;
        IGoogleDriveService _service;

        public Model(IGoogleDriveService service = null)
        {
            _state = new PointerState(this);
            _service = service;
        }

        // Click
        public void Click(Point point)
        {
            _state.Click(point);
        }

        // Pointer Pressed
        public void PressPointer(Point point)
        {
            _isPressed = true;
            _state.PressPointer(point);
        }

        // Pointer Moved
        public void MovePointer(Point point)
        {
            if (!_isPressed)
                return;
            _state.MovePointer(point);
        }

        // Pointer Released
        public void ReleasePointer(Point point)
        {
            if (!_isPressed)
                return;

            _state.ReleasePointer(point);
            _isPressed = false;
        }

        // Change shape
        public void ChangeShape(ShapeFactory.ShapeType type)
        {
            _drawingShapeType = type;
            _hint = ShapeFactory.CreateShape(_drawingShapeType);
            switch (_drawingShapeType)
            {
                case ShapeFactory.ShapeType.None:
                    _state = new PointerState(this);
                    break;
                case ShapeFactory.ShapeType.Rectangle:
                case ShapeFactory.ShapeType.Ellipse:
                    _state = new DrawingState(this);
                    break;
                case ShapeFactory.ShapeType.Line:
                    _state = new DrawingLineState(this);
                    break;
            }
            NotifyShapesChanged();
        }

        // Select Shape
        public void SelectShape(Point point)
        {
            _shapes.SelectShape(point);
            NotifySelectedChanged();
            NotifyShapesChanged();
        }

        // Set Hint start
        public void SetHintStart(Point point)
        {
            _hint.Point1 = point;
        }

        // Change Hint Second Point
        public void ChangeHintSecondPoint(Point point)
        {
            _hint.Point2 = point;
            NotifyShapesChanged();
        }

        // Clear
        public void Clear()
        {
            _isPressed = false;
            _shapes.Clear();
            _commandManager.Reset();
            NotifyShapesChanged();
        }

        // Draw
        public void Draw(IGraphics graphics)
        {
            _shapes.Draw(graphics);
            if (_isPressed && DrawingShapeType != ShapeFactory.ShapeType.None)
                _hint.Draw(graphics, Shape.DrawLayer.All);
        }

        // Undo
        public void Undo()
        {
            _commandManager.Undo();
            ClearSelected();
        }

        // Redo
        public void Redo()
        {
            _commandManager.Redo();
            ClearSelected();
        }

        // Clear Status
        private void ClearSelected()
        {
            _shapes.ResetSelected();
            NotifySelectedChanged();
            NotifyShapesChanged();
        }

        // Add Shape
        public void AddShape(Shape shape)
        {
            _shapes.AddShape(shape);
        }

        // Add Shape With Command Manager
        public void AddShapeWithCommandManager(Shape shape)
        {
            _commandManager.Execute(new DrawCommand(this, shape));
            ChangeShape(DEFAULT_SHAPE_TYPE);
        }

        // RemoveShape
        public void RemoveShape(Shape shape)
        {
            _shapes.RemoveShape(shape);
        }

        // Move Selected Shape
        public void MoveSelectedShape(Point point)
        {
            SelectedShape.MoveTo(point);
            NotifySelectedChanged();
            NotifyShapesChanged();
        }

        // Move Selected Shape With CommandManager
        public void MoveSelectedShapeWithCommandManager(MoveCommand moveCommand)
        {
            _commandManager.Execute(moveCommand);
        }

        // Save
        public void Save()
        {
            Task.Run(() => SaveToDrive());
        }

        // Save To Drive
        public void SaveToDrive()
        {
            try
            {
                File.WriteAllText(Strings.FILE_NAME, _shapes.ConvertToFile());
                _service.UploadFile(Strings.FILE_NAME, Strings.FILE_CONTENT_TYPE);
            }
            catch (IOException)
            {
                throw new Exception(Strings.SOMEONE_IS_USING_THE_FILE);
            }
        }

        // Load
        public void Load()
        {
            _service.DownloadFile(Strings.FILE_NAME, Directory.GetCurrentDirectory());
            if (!File.Exists(Strings.FILE_NAME))
                throw new Exception(Strings.FILE_NOT_EXIST);
            string readText = File.ReadAllText(Strings.FILE_NAME);
            _shapes.Load(readText);
            _commandManager.Reset();
            ChangeShape(ShapeFactory.ShapeType.None);
            NotifyShapesChanged();
        }

        // Create New Shape
        public void CreateNewShape()
        {
            Shape newShape = ShapeFactory.CreateShape(_drawingShapeType);
            if (newShape == null)
                return;
            newShape.Point1 = _hint.Point1;
            newShape.Point2 = _hint.Point2;
            AddShapeWithCommandManager(newShape);
        }

        // Create New Line
        internal void CreateNewLine()
        {
            Line line = new Line();
            Shape shape1 = _shapes.GetShapeOnPoint(_hint.Point1);
            Shape shape2 = _shapes.GetShapeOnPoint(_hint.Point2);
            if (IsShapeNull(shape1) || IsShapeNull(shape2))
            {
                ChangeShape(ShapeFactory.ShapeType.Line);
                return;
            }
            line.Shape1 = shape1;
            line.Shape2 = shape2;
            AddShapeWithCommandManager(line);
        }

        // Is Shape Null
        private bool IsShapeNull(Shape shape)
        {
            return shape == null;
        }

        // Notify Shapes Changed
        private void NotifyShapesChanged()
        {
            if (_shapesChanged != null)
                _shapesChanged();
        }

        // Notify Selected Changed
        private void NotifySelectedChanged()
        {
            if (_selectedChanged != null)
                _selectedChanged();
        }

        public Shape SelectedShape
        {
            get
            {
                return _shapes.SelectedShape;
            }
        }

        public ShapeFactory.ShapeType DrawingShapeType
        {
            get
            {
                return _drawingShapeType;
            }
        }

        public bool IsRedoEnabled
        {
            get
            {
                return _commandManager.IsRedoEnabled;
            }
        }

        public bool IsUndoEnabled
        {
            get
            {
                return _commandManager.IsUndoEnabled;
            }
        }
    }
}
