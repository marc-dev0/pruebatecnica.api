using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTecnica.Application.Dtos
{
    public class CategoriaDto
    {
        public int IdCategoria { get; set; }
        public string Descripcion { get; set; }
        public string UserName { get; set; }
        public string FechaRegistro { get; set; }
        public string Estado { get; set; }

    }
}
