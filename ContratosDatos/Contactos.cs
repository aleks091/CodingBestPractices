using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContratosDatos
{
    public class ListaContactos
    {
        public int Id { get; set; }
        public TipoReenvioLlamadasLista Tipo { get; set; }
        public int GrupoId { get; set; }
        public IEnumerable<Contacto> Contactos { get; set; }
    }
}
