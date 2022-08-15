using PruebaTecnica.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTecnica.Infrastructure.Persistences.Interfaces
{
    public interface ICategoriaRepository
    {
        Task<IEnumerable<Categorias>> GetAllFilterAsync(string descripcion);
        Task<bool> InsertUpdateAsync(Categorias categoria);
        Task<bool> DeleteAsync(string categoriaId);
    }
}
