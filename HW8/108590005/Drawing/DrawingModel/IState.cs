using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingModel
{
    interface IState
    {
        // Click
        void Click(Point point);

        // Press Pointer
        void PressPointer(Point point);

        // Move Pointer
        void MovePointer(Point point);

        // Release Pointer
        void ReleasePointer(Point point);
    }
}
