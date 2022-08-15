using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace PruebaTecnica.Infrastructure.Persistences.Contexts
{
    public class ConnectionFactory : IConnectionFactory
    {
        private readonly IConfiguration _configuration;

        public ConnectionFactory(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IDbConnection GetConnection
        {
            get
            {
                var sqlConnection = new SqlConnection();
                if (sqlConnection == null) return null;

                sqlConnection.ConnectionString = _configuration.GetConnectionString("CRMConnection");
                sqlConnection.Open();
                return sqlConnection;
            }
        }
    }
}
