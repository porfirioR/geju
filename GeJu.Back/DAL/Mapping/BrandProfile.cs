using Access.Contract.Request;
using AutoMapper;
using Resources.Contract.Brands;

namespace Manager.Admin.Mapping
{
    public class BrandProfile: Profile
    {
        public BrandProfile()
        {
            CreateMap<CreateBrand, BrandAccess>()
                .ForMember(dest => dest.Active, opt => opt.MapFrom(src => true));

            CreateMap<UpdateBrand, BrandAccess>()
                .ForMember(dest => dest.Active, opt => opt.MapFrom(src => true));
        }
    }
}
