using AutoMapper;
using HttpMethod_WEB.DTO;
using HttpMethod_DAL.Models;

namespace HttpMethod_WEB.Profiles
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<ProductDto,Product>().ReverseMap();
        }
    }
}
