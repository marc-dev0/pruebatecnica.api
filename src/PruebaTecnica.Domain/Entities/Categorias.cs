using System;

namespace PruebaTecnica.Domain.Entities
{
    public class Categorias
    {
        public int IdCategoria { get; set; }
        public int IdUsuario { get; set; }
        public string UserName { get; set; }
        public string Descripcion { get; set; }
        public string NombreCorto { get; set; }
        public bool Estado { get; set; }
        public string EstadoDesc { get; set; }
        public DateTime FechaRegistro { get; set; }
    }
}
