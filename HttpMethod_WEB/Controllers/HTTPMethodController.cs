using AutoMapper;
using HttpMethod_DAL.Models;
using HttpMethod_WEB.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using HttpMethod_BAL.IService;
using HttpMethod_WEB.DTO;

namespace HttpMethod_WEB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HTTPMethodController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IHTTPMethodService _service;

        public HTTPMethodController(IMapper mapper, IHTTPMethodService service)
        {
            this._mapper = mapper;
            this._service = service;
        }

        [HttpGet("test")]
        public IActionResult Get()
        {
            ProductDto productDto = new ProductDto();
            Product product = new Product
            {
                Id = 1,
                Name = "Laptop",
                Price = 1000
            }; ;

            productDto = _mapper.Map<ProductDto>(product);

            return Ok(productDto);
        }

        [HttpGet("GetAllProducts")]
        public async Task<IActionResult> GetAllProducts()
        {
            try
            {
                var products = await _service.GetAllProduct();

                var productsDto = _mapper.Map<IEnumerable<ProductDto>>(products);

                return Ok(productsDto);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }



    }
}
