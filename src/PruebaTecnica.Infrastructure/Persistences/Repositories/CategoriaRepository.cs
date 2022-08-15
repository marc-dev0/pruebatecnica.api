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
    public class CategoriaRepository : ICategoriaRepository
    {
        private readonly IConnectionFactory _connectionFactory;

        public CategoriaRepository(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async Task<IEnumerable<Categorias>> GetAllFilterAsync(string descripcion)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "CategoriaListByParam";
                var parameters = new DynamicParameters();
                parameters.Add("Descripcion", descripcion);

                var customer = await connection.QueryAsync<Categorias>(query, param: parameters, commandType: CommandType.StoredProcedure);
                return customer;
            }
        }

        public async Task<bool> InsertUpdateAsync(Categorias categoria)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "CategoriaInsUpd";
                var parameters = new DynamicParameters();
                parameters.Add("CategoriaId", categoria.IdCategoria);
                parameters.Add("UsuarioId", categoria.IdUsuario);
                parameters.Add("Descripcion", categoria.Descripcion);
                parameters.Add("NombreCorto", categoria.NombreCorto);
                parameters.Add("Estado", categoria.Estado);

                var result = await connection.ExecuteAsync(query, param: parameters, commandType: CommandType.StoredProcedure);
                return result > 0;
            }
        }
        public async Task<bool> DeleteAsync(string categoriaId)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "CategoriaDelete";
                var parameters = new DynamicParameters();
                parameters.Add("CategoriaId", categoriaId);
                var result = await connection.ExecuteAsync(query, param: parameters, commandType: CommandType.StoredProcedure);
                return result > 0;
            }
        }
    }
}
