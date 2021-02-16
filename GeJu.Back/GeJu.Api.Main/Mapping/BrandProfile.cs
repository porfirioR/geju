using AutoMapper;
using GeJu.Api.Main.DTO.Brands;
using GeJu.DALModels.Brands;

namespace GeJu.Api.Main.Mapping
{
    public class BrandProfile : Profile
    {
        public BrandProfile()
        {
            CreateMap<CreateBrandDTO, CreateBrand>();
            
            CreateMap<UpdateBrandDTO, UpdateBrand>();

            CreateMap<Brand, BrandApi>();
        }
    }
}
