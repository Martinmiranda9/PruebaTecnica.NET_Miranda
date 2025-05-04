using AutoMapper;
using PruebaTecnica_Miranda.Data;
using PruebaTecnica_Miranda.Dtos;
using PruebaTecnica_Miranda.Models;


namespace PruebaTecnica_Miranda.Mappings
{
    // // Definicion de un perfil de mapeo personalizado para AutoMapper.
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile() 
        {
            // Mapeo de la entidad Product al DTO de Product
            CreateMap<Product, ProductDto>()
            .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category.CategoryName));

            // Mapeo del DTO CreateProductDto a la entidad Product.
            CreateMap<CreateProductDto, Product>();

            // Mapeo de el DTO de actualizacion de producto a la entidad Product
            CreateMap<UpdateProductDto, Product>();

            // Mapeo de la entidad Category al DTO de Category.
            CreateMap<Category, CategoryDto>();

            // Mapeo del DTO CreateCategoryDto a la entidad Category.
            CreateMap<CreateCategoryDto, Category>();

        }
    }
}
