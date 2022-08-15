using PruebaTecnica.Domain.Entities;
using System;
using System.Threading.Tasks;

namespace PruebaTecnica.Infrastructure.Persistences.Interfaces
{
    public interface IUsuarioRepository
    {
        Task<Usuario> GetAsync(string userName, string password);
        Task<bool> InsertAsync(Usuario account);
    }
}
