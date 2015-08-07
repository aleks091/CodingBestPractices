using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrySwitch
{
    public class SalaryEmployee : IEmployee
    {
        public bool IsPayday(DateTime date)
        {
            //Implementar logica para determinar si la fecha es un dia de pago.
            return date.Day == 5 || date.Day == 20;
        }

        public decimal CalculatePay()
        {
            return 10m;
        }
    }
}
