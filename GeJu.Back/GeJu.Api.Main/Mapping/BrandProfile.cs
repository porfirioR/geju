using AutoMapper;
using GeJu.Api.Main.Models.Brands;
using Contract.Brands;

namespace GeJu.Api.Main.Mapping
{
    public class BrandProfile : Profile
    {
        public BrandProfile()
        {
            CreateMap<CreateBrandApiRequest, CreateBrand>();
            
            CreateMap<UpdateBrandApiRequest, UpdateBrand>();

            CreateMap<Brand, BrandApi>();
        }
    }
}
