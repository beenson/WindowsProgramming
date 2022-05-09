using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingModel
{
    public interface IGraphics
    {
        // Clear All Screen
        void ClearAll();
        // Draw Rectangle
        void DrawRectangle(Point point, double width, double height);
        // Draw Ellipse
        void DrawEllipse(Point point, double width, double height);
    }
}