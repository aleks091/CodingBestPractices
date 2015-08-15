using AccesoDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContratosDatos
{
    public class ListaDeContactos
    {
        private readonly IDataApi _dataApi;
        private ListaContactos _contactos;
        private int _posicionActual = 0;

        public TipoReenvioLlamadasLista Tipo { get; set; }
        public int ListaId { get; set; }
        public int Id { get; set; }
        public NumeroTelefonico NumeroTelefonico { get; set; }

        public ListaDeContactos(int id, IDataApi dataApi)
        {
            Id = id;
            _dataApi = dataApi;
        }

        public void CargarLista()
        {
            _contactos = _dataApi.ObtenerListaDeContactos(Id);
        }
        
        public bool TieneContacto()
        {
            if (_posicionActual >= _contactos.Contactos.Count())
                return false;

            var contacto = _contactos.Contactos.ElementAt(_posicionActual);

            _posicionActual++;

            NumeroTelefonico = contacto.NumeroTelefonico;

            return NumeroTelefonico != null;
        }
    }
}
