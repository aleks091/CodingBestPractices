using System;

namespace DrySwitch
{
    public class Payroll
    {
        public decimal CalculatePay(Employee e)
        {
            switch (e.Type)
            {
                case EmployeeType.Salary:
                    return CalculateSalaryPay(e);
                case EmployeeType.Hourly:
                    return CalculateHourlyPay(e);
                default:
                    throw new InvalidOperationException(e.Type.ToString());
            }
        }

        private decimal CalculateHourlyPay(Employee e)
        {
            return 50m;
        }

        private decimal CalculateSalaryPay(Employee e)
        {
            return 50m;
        }
    }
}
