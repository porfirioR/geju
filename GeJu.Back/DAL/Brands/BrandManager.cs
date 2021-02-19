using Admin.Interfaces;
using AutoMapper;
using Contract.Brands;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Manager.Admin.Brands
{
    internal class BrandManager : IBrandManager
    {
        private readonly IMapper _mapper;
        private readonly IBrandService _brandsServices;
        public BrandManager(IMapper mapper, IBrandService BrandsServices)
        {
            _brandsServices = BrandsServices;
            _mapper = mapper;
        }

        public async Task<Brand> Create(CreateBrand request)
        {
            var entity = await _brandsServices.CreateAsync(request);
            var model = _mapper.Map<Brand>(entity);
            return model;
        }

        public async Task<Brand> Update(UpdateBrand request)
        {
            var entity = await _brandsServices.UpdateAsync(request);
            var brandApi = _mapper.Map<Brand>(entity);
            return brandApi;
        }

        public Brand GetById(string id)
        {
            var brand = _brandsServices.GetById(id);
            var brandApi = _mapper.Map<Brand>(brand);
            return brandApi;
        }
        
        public IEnumerable<Brand> GetAll()
        {
            var brands = _brandsServices.GetAll();
            var brandApi = _mapper.Map<IEnumerable<Brand>>(brands);
            return brandApi;
        }
        
        public async Task<bool> Delete(string id)
        {
            return await _brandsServices.DeleteAsync(id);
        }
    }
}
