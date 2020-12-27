using AutoMapper;
using DAL.Interfaces;
using GeJu.AccessServicesModel.Sizes;
using GeJu.Common.DTO.Size;
using GeJu.Services.Admin.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DAL
{
    internal class SizeDAL : ISizeDAL
    {
        private readonly IMapper _mapper;
        private readonly ISizesServices _sizesServices;
        public SizeDAL(IMapper mapper, ISizesServices sizesServices)
        {
            _mapper = mapper;
            _sizesServices = sizesServices;
        }

        public async Task<SizeApi> CreateAsync(CreateSizeDTO sizeDTO)
        {
            var brandCreate = _mapper.Map<CreateSize>(sizeDTO);
            var entity = await _sizesServices.CreateAsync(brandCreate);
            var model = _mapper.Map<SizeApi>(entity);
            return model;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            return await _sizesServices.DeleteAsync(id);
        }

        public IEnumerable<SizeApi> GetAll()
        {
            var brands = _sizesServices.GetAll();
            var brandApi = _mapper.Map<IEnumerable<SizeApi>>(brands);
            return brandApi;
        }

        public SizeApi GetById(Guid id)
        {
            var brand = _sizesServices.GetById(id);
            var brandApi = _mapper.Map<SizeApi>(brand);
            return brandApi;
        }

        public async Task<SizeApi> UpdateAsync(UpdateSizeDTO sizeDTO)
        {
            var sizeUpdate = _mapper.Map<UpdateSize>(sizeDTO);
            var entity = await _sizesServices.UpdateAsync(sizeUpdate);
            var brandApi = _mapper.Map<SizeApi>(entity);
            return brandApi;
        }
    }
}
