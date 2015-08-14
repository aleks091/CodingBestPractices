using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examples.ObjectsAndData.Shapes.RefactoredShapes
{
    public class Rectangle : Shape
    {
        public double Height { get; set; }
        public double Width { get; set; }

        public double Area()
        {
            return Height * Width;
        }
    }
}
