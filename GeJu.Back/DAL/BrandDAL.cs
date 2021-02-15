using AutoMapper;
using DAL.Interfaces;
using GeJu.DALModels.Brands;
using GeJu.Services.Admin.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DAL
{
    internal class BrandDAL : IBrandDAL
    {
        private readonly IMapper _mapper;
        private readonly IBrandService _brandsServices;
        public BrandDAL(IMapper mapper, IBrandService BrandsServices)
        {
            _brandsServices = BrandsServices;
            _mapper = mapper;
        }

        public async Task<Brand> CreateAsync(CreateBrand request)
        {
            var entity = await _brandsServices.CreateAsync(request);
            var model = _mapper.Map<Brand>(entity);
            return model;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            return await _brandsServices.DeleteAsync(id);
        }

        public IEnumerable<Brand> GetAll()
        {
            var brands = _brandsServices.GetAll();
            var brandApi = _mapper.Map<IEnumerable<Brand>>(brands);
            return brandApi;
        }

        public Brand GetById(Guid id)
        {
            var brand = _brandsServices.GetById(id);
            var brandApi = _mapper.Map<Brand>(brand);
            return brandApi;
        }

        public async Task<Brand> UpdateAsync(UpdateBrand request)
        {
            var entity = await _brandsServices.UpdateAsync(request);
            var brandApi = _mapper.Map<Brand>(entity);
            return brandApi;
        }
    }
}
