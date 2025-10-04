using HttpMethod_DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HttpMethod_DAL.IRepository
{
    public interface IHTTPMethodRepository
    {
        Task<IEnumerable<Product>> GetAllProduct();
    }
}
