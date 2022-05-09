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
            _model.PressPointer(point);
        }

        // Pointer Released
        public void ReleasePointer(Point point)
        {
            _model.ReleasePointer(point);
            NotifyShapeChanged();
            NotifyCommandChanged();
        }

        // Pointer Moved
        public void MovePointer(Point point)
        {
            _model.MovePointer(point);
        }

        // Pointer Click
        public void Click(Point point)
        {
            _model.Click(point);
            NotifyPropertyChanged(nameof(SelectInformationLabelText));
        }

        // Draw
        public void Draw(IGraphics graphics)
        {
            _model.Draw(graphics);
        }

        // Change Shape
        public void ChangeShape(ShapeFactory.ShapeType shapeType)
        {
            _model.ChangeShape(shapeType);
            NotifyShapeChanged();
        }

        // Clear
        public void Clear()
        {
            _model.Clear();
        }

        // Undo
        public void Undo()
        {
            _model.Undo();
            NotifyCommandChanged();
        }

        // Redo
        public void Redo()
        {
            _model.Redo();
            NotifyCommandChanged();
        }

        // Notify Command Changed
        private void NotifyCommandChanged()
        {
            NotifyPropertyChanged(nameof(IsUndoEnable));
            NotifyPropertyChanged(nameof(IsRedoEnable));
        }

        // Notify Shape Changed
        private void NotifyShapeChanged()
        {
            NotifyPropertyChanged(nameof(IsRectangleButtonEnable));
            NotifyPropertyChanged(nameof(IsEllipseButtonEnable));
            NotifyPropertyChanged(nameof(IsLineButtonEnable));
        }

        // Notify Property
        private void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        public string SelectInformationLabelText
        {
            get
            {
                if (_model.SelectedShape == null)
                    return "";
                return "Selected ： " + _model.SelectedShape.ToString();
            }
        }

        public bool IsRectangleButtonEnable
        {
            get
            {
                return _model.DrawingShapeType != ShapeFactory.ShapeType.Rectangle;
            }
        }

        public bool IsEllipseButtonEnable
        {
            get
            {
                return _model.DrawingShapeType != ShapeFactory.ShapeType.Ellipse;
            }
        }

        public bool IsLineButtonEnable
        {
            get
            {
                return _model.DrawingShapeType != ShapeFactory.ShapeType.Line;
            }
        }

        public bool IsUndoEnable
        {
            get
            {
                return _model.IsUndoEnabled;
            }
        }

        public bool IsRedoEnable
        {
            get
            {
                return _model.IsRedoEnabled;
            }
        }
    }
}
