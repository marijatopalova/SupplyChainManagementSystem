using AutoMapper;
using SCMS.Application.Dtos;
using SCMS.Domain.Entities;

namespace SCMS.Application.Mappings
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<Product, ProductDto>().ReverseMap();
        }
    }
}
