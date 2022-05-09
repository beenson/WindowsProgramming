using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingModel
{
    public class PointerState : IState
    {
        Model _model;
        bool _selectedShapeClicked = false;
        Point _origin;
        Point _offset;

        public PointerState(Model model)
        {
            this._model = model;
        }

        // Click
        public void Click(Point point)
        {
            if (_selectedShapeClicked)
                return;
            _model.SelectShape(point);
        }

        // Move Pointer
        public void MovePointer(Point point)
        {
            if (!_selectedShapeClicked)
                return;
            //_model.MoveSelectedShape(point - _offset);
            _model.MoveSelectedShape(point.Subtract(_offset));
        }

        // Press Pointer
        public void PressPointer(Point point)
        {
            _selectedShapeClicked = false;
            if (_model.SelectedShape == null)
                return;
            _selectedShapeClicked = _model.SelectedShape.IsPointInShape(point);
            _origin = _model.SelectedShape.UpperLeft;
            //_offset = point - _model.SelectedShape.UpperLeft;
            _offset = point.Subtract(_model.SelectedShape.UpperLeft);
        }

        // Release Pointer
        public void ReleasePointer(Point point)
        {
            if (!_selectedShapeClicked)
                return;
            _selectedShapeClicked = false;
            //_model.MoveSelectedShapeWithCommandManager(new MoveCommand(_model.SelectedShape, _origin, point - _offset));
            _model.MoveSelectedShapeWithCommandManager(new MoveCommand(_model.SelectedShape, _origin, point.Subtract(_offset)));
        }
    }
}
