using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrySwitch
{
    public class EmployeeFactory
    {
        public IEmployee CreateEmployee(EmployeeType type)
        {
            switch (type)
            {
                case EmployeeType.Salary:
                    return new SalaryEmployee();
                case EmployeeType.Hourly:
                    return new HourlyEmployee();
                default:
                    throw new InvalidOperationException(string.Format("Couldn't create employee of type: {0}", type.ToString("G")));                    
            }
        }
    }
}
