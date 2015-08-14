using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examples.ObjectsAndData.Shapes.RefactoredShapes
{
    public class Circle : Shape
    {
        public double Radius { get; set; }
        private const double PI = 3.141592653589793;
        
        public double Area()
        {
            return PI * Radius * Radius;
        }
    }
}
