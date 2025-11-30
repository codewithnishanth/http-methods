using AutoMapper;
using HttpMethod_DAL.Models;
using HttpMethod_WEB.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using HttpMethod_BAL.IService;
using HttpMethod_WEB.DTO;
using Swashbuckle.AspNetCore.Annotations;

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
        public IActionResult GetTest()
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

        // GET: api/httpmethods
        [HttpGet]
        public IActionResult Get() => Ok("GET response");

        // POST: api/httpmethods
        [HttpPost]
        public IActionResult Post() => Ok("POST response");

        // PUT: api/httpmethods
        [HttpPut]
        public IActionResult Put() => Ok("PUT response");

        // PATCH: api/httpmethods
        [HttpPatch]
        public IActionResult Patch() => Ok("PATCH response");

        // DELETE: api/httpmethods
        [HttpDelete]
        public IActionResult Delete() => Ok("DELETE response");

        // HEAD: api/httpmethods
        [HttpHead]
        public IActionResult Head() => Ok();

        // OPTIONS: api/httpmethods
        [HttpOptions]
        public IActionResult Options()
        {
            Response.Headers.Add("Allow", "GET,POST,PUT,PATCH,DELETE,HEAD,OPTIONS,TRACE,CONNECT");
            return Ok();
        }

        // TRACE: api/httpmethods/trace
        [ApiExplorerSettings(IgnoreApi = false)]
        [AcceptVerbs("TRACE")]               //[HttpTrace("trace")]
        [Route("api/httpmethods/trace")]
        [SwaggerOperation(Summary = "Simulated TRACE request", Description = "Echoes back request data")]
        [SwaggerResponse(200, "Successful TRACE response")]
        public IActionResult Trace()
        {
            using var reader = new StreamReader(Request.Body);
            var body = reader.ReadToEndAsync().Result;
            return Ok(new
            {
                Method = Request.Method,
                Headers = Request.Headers,
                Body = body
            });
        }


        // CONNECT: api/httpmethods/connect
        [ApiExplorerSettings(IgnoreApi = true)]
        [AcceptVerbs("CONNECT")]
        [Route("api/httpmethods/connect")]      //[HttpConnect] [HttpPost("connect")]
        public IActionResult Connect()
        {
            // Simulate a CONNECT method for demonstration purposes
            return Ok("CONNECT method simulated.");
        }


    }
}
