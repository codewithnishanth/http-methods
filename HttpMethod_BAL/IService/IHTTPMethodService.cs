using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HttpMethod_DAL.Models;

namespace HttpMethod_BAL.IService
{
    public interface IHTTPMethodService
    {
        Task<IEnumerable<Product>> GetAllProduct();
    }
}
