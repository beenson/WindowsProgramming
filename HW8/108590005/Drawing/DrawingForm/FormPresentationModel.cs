using DrawingForm.PresentationModel;
using DrawingModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingForm
{
    public class FormPresentationModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        const string HEADER = "Selected ： ";
        DrawingModel.Model _model;

        public FormPresentationModel(DrawingModel.Model model)
        {
            _model = model;
            model._selectedChanged += NotifySelectInformationLabelTextChanged;
        }

        // Get Model
        public DrawingModel.Model GetModel()
        {
            return _model;
        }

        // Click
        public void Click(Point point)
        {
            _model.Click(point);
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
        }

        // Pointer Moved
        public void MovePointer(Point point)
        {
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
            _model.ChangeShape(shapeType);
            NotifyShapeChanged();
        }

        // Clear
        public void Clear()
        {
            _model.Clear();
        }

        // Save
        public void Save()
        {
            _model.Save();
        }

        // Load
        public void Load()
        {
            _model.Load();
            NotifyShapeChanged();
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

        // Notify SelectInformationLabelText Changed
        private void NotifySelectInformationLabelTextChanged()
        {
            NotifyPropertyChanged(nameof(SelectInformationLabelText));
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

        public string SelectInformationLabelText
        {
            get
            {
                if (_model.SelectedShape == null)
                    return "";
                return HEADER + _model.SelectedShape.ToString();
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
