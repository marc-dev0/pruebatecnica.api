using Dapper;
using PruebaTecnica.Domain.Entities;
using PruebaTecnica.Infrastructure.Persistences.Contexts;
using PruebaTecnica.Infrastructure.Persistences.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTecnica.Infrastructure.Persistences.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly IConnectionFactory _connectionFactory;

        public UsuarioRepository(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async Task<Usuario> GetAsync(string userName, string password)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "UsuarioGetByPassword";
                var parameters = new DynamicParameters();
                parameters.Add("userName", userName);
                parameters.Add("password", password);

                var account = await connection.QuerySingleOrDefaultAsync<Usuario>(query, param: parameters, commandType: CommandType.StoredProcedure);
                return account;
            }
        }

        public async Task<bool> InsertAsync(Usuario account)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "UsuarioInsert";
                var parameters = new DynamicParameters();
                parameters.Add("userName", account.UserName);
                parameters.Add("password", account.Password);

                var result = await connection.ExecuteAsync(query, param: parameters, commandType: CommandType.StoredProcedure);
                return result > 0;
            }
        }
    }
}
