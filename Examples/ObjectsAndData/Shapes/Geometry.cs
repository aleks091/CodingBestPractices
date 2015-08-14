using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examples.ObjectsAndData.Shapes
{
    public class Geometry
    {
        public double PI = 3.141592653589793;

        public double Area(object shape)
        {
            if (shape is Square)
            {
                var s = (Square)shape;
                return s.Side * s.Side;
            }
            else if (shape is Rectangle)
            {
                var r = (Rectangle)shape;
                return r.Height * r.Width;
            }
            else if (shape is Circle)
            {
                var c = (Circle)shape;
                return PI * c.Radius * c.Radius;
            }

            throw new InvalidOperationException("Invalid Shape");
        }
    }
}
