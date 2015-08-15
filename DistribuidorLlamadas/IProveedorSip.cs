using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DistribuidorLlamadas
{
    public interface IProveedorSip
    {
        void ReproducirGrabacion(string grabacionId);
        void Llamar(string pstn);
    }
}
