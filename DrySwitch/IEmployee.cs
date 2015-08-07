using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrySwitch
{
    public interface IEmployee
    {
        bool IsPayday(DateTime dateTime);
        decimal CalculatePay();
    }
}
