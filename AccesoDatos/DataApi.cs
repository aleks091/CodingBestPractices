using ContratosDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos
{
    public interface IDataApi
    {
        ListaContactos ObtenerListaDeContactos(int listaId);
    }
}
