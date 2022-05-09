using System.Collections.Generic;

namespace DrawingModel
{
    public class Model
    {
        public event ModelChangedEventHandler _modelChanged;
        public delegate void ModelChangedEventHandler();
        bool _isPressed = false;
        Shapes _shapes = new Shapes();
        Shape _hint;
        ShapeFactory.ShapeType _shapeType;

        // Pointer Pressed
        public void PressPointer(Point point)
        {
            if (point.IsAvailable && _hint != null)
            {
                _hint._point1 = point;
                _isPressed = true;
            }
        }

        // Pointer Moved
        public void MovePointer(Point point)
        {
            if (_isPressed)
            {
                _hint._point2 = point;
                NotifyModelChanged();
            }
        }

        // Pointer Released
        public void ReleasePointer(Point point)
        {
            if (_isPressed)
            {
                _isPressed = false;
                _shapes.AddShape(_shapeType, _hint._point1, point);
                _hint = ShapeFactory.CreateShape(ShapeFactory.ShapeType.None);
                NotifyModelChanged();
            }
        }

        // Change shape
        public void ChangeShape(ShapeFactory.ShapeType type)
        {
            _shapeType = type;
            _hint = ShapeFactory.CreateShape(_shapeType);
        }

        // Clear
        public void Clear()
        {
            _isPressed = false;
            _shapes.Clear();
            NotifyModelChanged();
        }

        // Draw
        public void Draw(IGraphics graphics)
        {
            _shapes.Draw(graphics);
            if (_isPressed)
            {
                _hint.Draw(graphics);
            }
        }

        // Notify ModelChanged
        void NotifyModelChanged()
        {
            if (_modelChanged != null)
                _modelChanged();
        }
    }
}
