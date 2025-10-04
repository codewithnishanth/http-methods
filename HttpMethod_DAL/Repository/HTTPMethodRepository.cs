using HttpMethod_DAL.IRepository;
using HttpMethod_DAL.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace HttpMethod_DAL.Repository
{
    public class HTTPMethodRepository : IHTTPMethodRepository
    {
        public async Task<IEnumerable<Product>> GetAllProduct()
        {
            string connectionString = HttpMethod_DAL.DBContext.DBContext.GetConnectionString();
            using var connection = new SqlConnection(connectionString);
            try
            {
                var products =  await connection.QueryAsync<Product>("sp_GetAllProducts", null, null, 0, System.Data.CommandType.StoredProcedure);
                return products;
            }
            catch (Exception ex) 
            {
                Console.WriteLine(ex.Message);
                return Enumerable.Empty<Product>();
            }
            finally
            {
                connection.Close();
            }
        }
    }
}
