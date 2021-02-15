using AutoMapper;
using DAL.Interfaces;
using GeJu.DALModels.Sizes;
using GeJu.Services.Admin.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DAL
{
    internal class SizeDAL : ISizeDAL
    {
        private readonly IMapper _mapper;
        private readonly ISizeService _sizesServices;
        public SizeDAL(IMapper mapper, ISizeService sizesServices)
        {
            _mapper = mapper;
            _sizesServices = sizesServices;
        }

        public async Task<Size> Create(CreateSize request)
        {
            var entity = await _sizesServices.CreateAsync(request);
            var model = _mapper.Map<Size>(entity);
            return model;
        }

        public async Task<bool> Delete(Guid id)
        {
            return await _sizesServices.DeleteAsync(id);
        }

        public IEnumerable<Size> GetAll()
        {
            var sizeList = _sizesServices.GetAll();
            var sizeResponseList = _mapper.Map<IEnumerable<Size>>(sizeList);
            return sizeResponseList;
        }

        public Size GetById(Guid id)
        {
            var model = _sizesServices.GetById(id);
            var modelResponse = _mapper.Map<Size>(model);
            return modelResponse;
        }

        public async Task<Size> UpdateAsync(UpdateSize request)
        {
            var model = await _sizesServices.UpdateAsync(request);
            var response = _mapper.Map<Size>(model);
            return response;
        }
    }
}
