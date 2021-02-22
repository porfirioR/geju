using Access.Contract.Request;
using Admin.Interfaces;
using AutoMapper;
using Resources.Contract.Brands;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Manager.Admin.Brands
{
    internal class BrandManager : IBrandManager
    {
        private readonly IMapper _mapper;
        private readonly IBrandDataAccess _brandDataAccess;
        public BrandManager(IMapper mapper, IBrandDataAccess brandDataAccess)
        {
            _brandDataAccess = brandDataAccess;
            _mapper = mapper;
        }

        public async Task<BrandResponse> Create(CreateBrand request)
        {
            var requestDataAccess = _mapper.Map<BrandAccess>(request);
            var entity = await _brandDataAccess.CreateAsync(requestDataAccess);
            var model = _mapper.Map<BrandResponse>(entity);
            return model;
        }

        public async Task<BrandResponse> Update(UpdateBrand request)
        {
            var requestDataAccess = _mapper.Map<BrandAccess>(request);
            var entity = await _brandDataAccess.UpdateAsync(requestDataAccess);
            var brandResponse = _mapper.Map<BrandResponse>(entity);
            return brandResponse;
        }

        public async Task<BrandResponse> GetById(string id)
        {
            var brand = await _brandDataAccess.GetByIdAsync(id);
            var brandResponse = _mapper.Map<BrandResponse>(brand);
            return brandResponse;
        }
        
        public async Task<IEnumerable<BrandResponse>> GetAll()
        {
            var brands = await _brandDataAccess.GetAllAsync();
            var brandsResponse = _mapper.Map<IEnumerable<BrandResponse>>(brands);
            return brandsResponse;
        }
        
        public async Task<BrandResponse> Delete(string id)
        {
            var response = await _brandDataAccess.DeleteAsync(id);
            return _mapper.Map<BrandResponse>(response);
        }
    }
}
