using Access.Contract.Interfaces;
using Access.Contract.Request;
using AutoMapper;
using Resources.Contract.Colors;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Manager.Admin.Colors
{
    internal class ColorManager : IColorManager
    {
        private readonly IMapper _mapper;
        private readonly IColorDataAccess _colorDataAccess;
        public ColorManager(IMapper mapper, IColorDataAccess colorDataAccess)
        {
            _colorDataAccess = colorDataAccess;
            _mapper = mapper;
        }

        public async Task<ColorResponse> Create(CreateColor request)
        {
            var requestDataAccess = _mapper.Map<ColorAccess>(request);
            var entity = await _colorDataAccess.CreateAsync(requestDataAccess);
            var model = _mapper.Map<ColorResponse>(entity);
            return model;
        }

        public async Task<ColorResponse> Update(UpdateColor request)
        {
            var requestDataAccess = _mapper.Map<ColorAccess>(request);
            var entity = await _colorDataAccess.UpdateAsync(requestDataAccess);
            var brandResponse = _mapper.Map<ColorResponse>(entity);
            return brandResponse;
        }

        public async Task<ColorResponse> GetById(string id)
        {
            var brand = await _colorDataAccess.GetByIdAsync(id);
            var brandResponse = _mapper.Map<ColorResponse>(brand);
            return brandResponse;
        }
        
        public async Task<IEnumerable<ColorResponse>> GetAll()
        {
            var brands = await _colorDataAccess.GetAllAsync();
            var brandsResponse = _mapper.Map<IEnumerable<ColorResponse>>(brands);
            return brandsResponse;
        }
        
        public async Task<ColorResponse> Delete(string id)
        {
            var response = await _colorDataAccess.DeleteAsync(id);
            return _mapper.Map<ColorResponse>(response);
        }
    }
}
