using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingModel
{
    public class DrawCommand : ICommand
    {
        Model _model;
        Shape _shape;

        public DrawCommand(Model model, Shape shape)
        {
            this._model = model;
            this._shape = shape;
        }

        // Draw
        public void Execute()
        {
            _model.AddShape(_shape);
        }

        // Remove
        public void Revoke()
        {
            _model.RemoveShape(_shape);
        }
    }
}
