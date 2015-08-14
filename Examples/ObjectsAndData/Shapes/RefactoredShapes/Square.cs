using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examples.ObjectsAndData.Shapes.RefactoredShapes
{
    public class Square : Shape
    {
        public double Side { get; set; }

        public double Area()
        {
            return Side * Side;
        }
    }
}
