using System;

namespace DrySwitch
{
    public class Payroll
    {
        public bool IsPayday(Employee e, DateTime date)
        {
            switch (e.Type)
            {
                case EmployeeType.Salary:
                    return date.Day == 5 || date.Day == 20;
                case EmployeeType.Hourly:
                    return date.Day == 10 || date.Day == 25;
                default:
                    throw new InvalidOperationException(e.Type.ToString());
            }
        }

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
