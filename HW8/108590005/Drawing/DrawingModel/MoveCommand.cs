using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingModel
{
    public class MoveCommand : ICommand
    {
        Shape _shape;
        Point _origin;
        Point _moved;

        public MoveCommand(Shape shape, Point origin, Point moved)
        {
            this._shape = shape;
            this._origin = origin;
            this._moved = moved;
        }

        // Execute
        public void Execute()
        {
            _shape.MoveTo(_moved);
        }

        // Revoke
        public void Revoke()
        {
            _shape.MoveTo(_origin);
        }
    }
}
