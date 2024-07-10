using AutoMapper;
using WebAppGeek.Dto;
using WebAppGeek.Models;

namespace WebAppGeek.Mapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Product, ProductDto>().ReverseMap();
            CreateMap<ProductGroup, ProductGroupDto>().ReverseMap();
        }
    }
}