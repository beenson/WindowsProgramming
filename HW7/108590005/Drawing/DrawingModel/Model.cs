using System.Collections.Generic;

namespace DrawingModel
{
    public class Model
    {
        public event ShapesChangedEventHandler _shapesChanged;
        public delegate void ShapesChangedEventHandler();
        public event SelectedChangedEventHandler _selectedChanged;
        public delegate void SelectedChangedEventHandler();
        bool _isPressed = false;
        Shapes _shapes = new Shapes();
        CommandManager _commandManager = new CommandManager();
        Shape _hint;
        ShapeFactory.ShapeType _drawingShapeType;

        const ShapeFactory.ShapeType DEFAULT_SHAPE_TYPE = ShapeFactory.ShapeType.None;

        // Click
        public void Click(Point point)
        {
            if (_drawingShapeType != ShapeFactory.ShapeType.None)
                return;
            _shapes.SelectShape(point);
            NotifySelectedChanged();
            NotifyShapesChanged();
        }

        // Pointer Pressed
        public void PressPointer(Point point)
        {
            if (!IsShapeAvailable)
                return;

            if (point.IsAvailable && _hint != null)
            {
                _hint.Point1 = point;
                _isPressed = true;
            }
        }

        // Pointer Moved
        public void MovePointer(Point point)
        {
            if (!IsShapeAvailable)
                return;

            if (_isPressed)
            {
                _hint.Point2 = point;
                NotifyShapesChanged();
            }
        }

        // Pointer Released
        public void ReleasePointer(Point point)
        {
            if (!IsShapeAvailable)
                return;

            if (_isPressed)
            {
                _isPressed = false;
                _hint.Point2 = point;
                Shape newShape = CreateNewShape();
                if (IsShapeNull(newShape))
                    return;
                _commandManager.Execute(new DrawCommand(this, newShape));
                ChangeShape(DEFAULT_SHAPE_TYPE);
            }
        }

        // Change shape
        public void ChangeShape(ShapeFactory.ShapeType type)
        {
            _drawingShapeType = type;
            _hint = ShapeFactory.CreateShape(_drawingShapeType);
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
            if (_isPressed)
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

        // RemoveShape
        public void RemoveShape(Shape shape)
        {
            _shapes.RemoveShape(shape);
        }

        // Create New Shape
        private Shape CreateNewShape()
        {
            if (_drawingShapeType == ShapeFactory.ShapeType.Line)
                return CreateNewLine();

            Shape newShape = ShapeFactory.CreateShape(_drawingShapeType);
            newShape.Point1 = _hint.Point1;
            newShape.Point2 = _hint.Point2;
            return newShape;
        }

        // Create New Line
        private Line CreateNewLine()
        {
            Line line = new Line();
            Shape shape1 = _shapes.GetShapeOnPoint(_hint.Point1);
            Shape shape2 = _shapes.GetShapeOnPoint(_hint.Point2);
            if (IsShapeNull(shape1) || IsShapeNull(shape2))
            {
                ChangeShape(ShapeFactory.ShapeType.Line);
                return null;
            }
            line.Shape1 = shape1;
            line.Shape2 = shape2;
            return line;
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

        private bool IsShapeAvailable
        {
            get
            {
                return _drawingShapeType != ShapeFactory.ShapeType.None;
            }
        }
    }
}
