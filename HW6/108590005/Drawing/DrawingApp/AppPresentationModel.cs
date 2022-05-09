using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DrawingModel;

namespace DrawingApp
{
    public class AppPresentationModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        DrawingModel.Model _model;
        ShapeFactory.ShapeType _shapeType;

        public AppPresentationModel(Model model)
        {
            _model = model;
        }

        // Get Model
        public DrawingModel.Model GetModel()
        {
            return _model;
        }

        // Pointer Pressed
        public void PressPointer(Point point)
        {
            if (IsShapeAvailable)
                _model.PressPointer(point);
        }

        // Pointer Released
        public void ReleasePointer(Point point)
        {
            if (IsShapeAvailable)
                _model.ReleasePointer(point);
            ChangeShape(ShapeFactory.ShapeType.None);
        }

        // Pointer Moved
        public void MovePointer(Point point)
        {
            if (IsShapeAvailable)
                _model.MovePointer(point);
        }

        // Draw
        public void Draw(IGraphics graphics)
        {
            _model.Draw(graphics);
        }

        // Change Shape
        public void ChangeShape(ShapeFactory.ShapeType shapeType)
        {
            _shapeType = shapeType;
            _model.ChangeShape(_shapeType);
            NotifyShapeChanged();
        }

        // Clear
        public void Clear()
        {
            _model.Clear();
        }

        // Notify Shape Changed
        private void NotifyShapeChanged()
        {
            NotifyPropertyChanged(nameof(IsRectangleButtonEnable));
            NotifyPropertyChanged(nameof(IsEllipseButtonEnable));
        }

        // Notify Property
        private void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        private bool IsShapeAvailable
        {
            get
            {
                return _shapeType != ShapeFactory.ShapeType.None;
            }
        }

        public bool IsRectangleButtonEnable
        {
            get
            {
                return _shapeType != ShapeFactory.ShapeType.Rectangle;
            }
        }

        public bool IsEllipseButtonEnable
        {
            get
            {
                return _shapeType != ShapeFactory.ShapeType.Ellipse;
            }
        }
    }
}
