using AutoMapper;
using DAL.Interfaces;
using GeJu.AccessServicesModel.Brands;
using GeJu.Common.DTO.Brands;
using GeJu.Services.Admin.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DAL
{
    internal class BrandDAL : IBrandDAL
    {
        private readonly IMapper _mapper;
        private readonly IBrandsServices _brandsServices;
        public BrandDAL(IMapper mapper, IBrandsServices BrandsServices)
        {
            _brandsServices = BrandsServices;
            _mapper = mapper;
        }

        public async Task<BrandApi> CreateAsync(CreateBrandDTO BrandDTO)
        {
            var brandCreate = _mapper.Map<CreateBrand>(BrandDTO);
            var entity = await _brandsServices.CreateAsync(brandCreate);
            var model = _mapper.Map<BrandApi>(entity);
            return model;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            return await _brandsServices.DeleteAsync(id);
        }

        public IEnumerable<BrandApi> GetAll()
        {
            var brands = _brandsServices.GetAll();
            var brandApi = _mapper.Map<IEnumerable<BrandApi>>(brands);
            return brandApi;
        }

        public BrandApi GetById(Guid id)
        {
            var brand = _brandsServices.GetById(id);
            var brandApi = _mapper.Map<BrandApi>(brand);
            return brandApi;
        }

        public async Task<BrandApi> UpdateAsync(UpdateBrandDTO brandDTO)
        {
            var brandUpdate = _mapper.Map<UpdateBrand>(brandDTO);
            var entity = await _brandsServices.UpdateAsync(brandUpdate);
            var brandApi = _mapper.Map<BrandApi>(entity);
            return brandApi;
        }
    }
}
