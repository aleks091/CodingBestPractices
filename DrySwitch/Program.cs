using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrySwitch
{
    class Program
    {
        static void Main(string[] args)
        {
            if(args.Any() && args[0] == "dry")
            {
                var employeeFactory = new EmployeeFactory();
                var employee = employeeFactory.CreateEmployee(EmployeeType.Hourly);
                var payroll = new DryPayroll(employee);

                Console.WriteLine("The employee salary is: {0}", payroll.CalculatePay());
            }
            else
            {
                var payroll = new Payroll();
                var employee = new Employee();
                var salary = payroll.CalculatePay(employee);

                Console.WriteLine("The employee salary is: {0}", salary);
            }

            Console.ReadKey();            
        }
    }
}

