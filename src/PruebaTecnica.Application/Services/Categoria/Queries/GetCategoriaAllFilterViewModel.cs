using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTecnica.Application.Services.Categoria.Queries
{
    public class GetCategoriaAllFilterViewModel
    {
        public int IdCategoria { get; set; }
        public string Descripcion { get; set; }
        public string NombreCorto { get; set; }
        public string UserName { get; set; }
        public DateTime FechaRegistro { get; set; }
        public bool Estado { get; set; }
        public string EstadoDesc { get; set; }
    }
}
