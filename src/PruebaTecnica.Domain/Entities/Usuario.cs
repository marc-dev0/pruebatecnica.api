using System;

namespace PruebaTecnica.Domain.Entities
{
    public class Usuario
    {
        public int IdUsuario { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public DateTime FechaRegistro { get; set; }
    }
}
