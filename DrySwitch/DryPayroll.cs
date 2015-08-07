using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrySwitch
{
    public class DryPayroll
    {
        private readonly IEmployee _employee;

        public DryPayroll(IEmployee employee)
        {
            _employee = employee;
        }

        public decimal CalculatePay()
        {
            //Executar logica de negocio concerniente al calculo general de salarios
            return _employee.CalculatePay();
        }
    }
}
