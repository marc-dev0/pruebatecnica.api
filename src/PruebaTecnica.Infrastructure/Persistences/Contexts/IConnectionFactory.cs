using System.Data;

namespace PruebaTecnica.Infrastructure.Persistences.Contexts
{
    public interface IConnectionFactory
    {
        IDbConnection GetConnection { get; }
    }
}
