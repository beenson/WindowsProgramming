using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DrawingModel
{
    public class ShapeFactory
    {
        // Model Namespace
        const string MODEL_NAMESPACE = "DrawingModel.";

        public enum ShapeType
        {
            None,
            Rectangle,
            Ellipse
        }

        // CreateShape
        public static Shape CreateShape(ShapeType type)
        {
            //return (Shape)Assembly.GetAssembly(typeof(Shape)).CreateInstance(MODEL_NAMESPACE + name);
            switch (type)
            {
                case ShapeType.Rectangle:
                    return new Rectangle();
                case ShapeType.Ellipse:
                    return new Ellipse();
            }
            return null;
        }
    }
}
