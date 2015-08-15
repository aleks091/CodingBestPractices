using AccesoDatos;
using ContratosDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DistribuidorLlamadas
{
    public class EnvioLlamadas
    {
        private readonly IProveedorSip _proveedorSip;
        private readonly IDataApi _dataApi;
        private ListaDeContactos _listaDeContactos;

        public EnvioLlamadas(IProveedorSip proveedorSip, IDataApi dataApi)
        {
            _proveedorSip = proveedorSip;
            _dataApi = dataApi;
        }

        public void IniciarDatos(int listaDeContactosId)
        {
            _listaDeContactos = new ListaDeContactos(listaDeContactosId, _dataApi);
            _listaDeContactos.CargarLista();
        }

        public void OriginarLlamadas()
        {
            while (_listaDeContactos.TieneContacto())
            {
                _proveedorSip.Llamar(_listaDeContactos.NumeroTelefonico.Numero);
            }            
        }
    }
}
