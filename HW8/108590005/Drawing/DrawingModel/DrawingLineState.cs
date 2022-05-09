using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingModel
{
    public class DrawingLineState : IState
    {
        Model _model;

        public DrawingLineState(Model model)
        {
            this._model = model;
        }

        // Click
        public void Click(Point point)
        {
            return;
        }

        // Move Pointer
        public void MovePointer(Point point)
        {
            _model.ChangeHintSecondPoint(point);
        }

        // Press Pointer
        public void PressPointer(Point point)
        {
            _model.SetHintStart(point);
        }

        // Release Pointer
        public void ReleasePointer(Point point)
        {
            _model.ChangeHintSecondPoint(point);
            _model.CreateNewLine();
        }
    }
}
