using HttpMethod_BAL.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HttpMethod_DAL.Models;
using HttpMethod_DAL.IRepository;

namespace HttpMethod_BAL.Service
{
    public class HTTPMethodService : IHTTPMethodService
    {
        private readonly IHTTPMethodRepository _repository;

        public HTTPMethodService(IHTTPMethodRepository repository)
        {
            this._repository = repository;
        }

        public Task<IEnumerable<Product>> GetAllProduct()
        {
            return _repository.GetAllProduct();
        }
    }
}
