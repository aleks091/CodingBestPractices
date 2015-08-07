using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrySwitch
{
    public class Employee
    {
        public EmployeeType Type { get; private set; }

        public Employee()
        {
            Type = EmployeeType.Salary;
        }
    }
}
