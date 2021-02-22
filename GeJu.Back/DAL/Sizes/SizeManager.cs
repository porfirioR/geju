using Access.Contract.Request;
using Admin.Interfaces;
using AutoMapper;
using Resources.Contract.Sizes;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Manager.Admin.Sizes
{
    internal class SizeManager : ISizeManager
    {
        private readonly IMapper _mapper;
        private readonly ISizeDataAccess _sizeDataAccess;
        public SizeManager(IMapper mapper, ISizeDataAccess sizeDataAccess)
        {
            _mapper = mapper;
            _sizeDataAccess = sizeDataAccess;
        }

        public async Task<SizeResponse> Create(CreateSize request)
        {
            var sizeAccess = _mapper.Map<SizeAccess>(request);
            var model = await _sizeDataAccess.CreateAsync(sizeAccess);
            var modelResponse = _mapper.Map<SizeResponse>(model);
            return modelResponse;
        }

        public async Task<IEnumerable<SizeResponse>> GetAll()
        {
            var model = await _sizeDataAccess.GetAllAsync();
            var response = _mapper.Map<IEnumerable<SizeResponse>>(model);
            return response;
        }

        public async Task<SizeResponse> GetById(string id)
        {
            var model = await _sizeDataAccess.GetByIdAsync(id);
            var modelResponse = _mapper.Map<SizeResponse>(model);
            return modelResponse;
        }

        public async Task<SizeResponse> Update(UpdateSize request)
        {
            var requestAccess = _mapper.Map<SizeAccess>(request);
            var model = await _sizeDataAccess.UpdateAsync(requestAccess);
            var response = _mapper.Map<SizeResponse>(model);
            return response;
        }

        public async Task<SizeResponse> Delete(string id)
        {
            var response = await _sizeDataAccess.DeleteAsync(id);
            return _mapper.Map<SizeResponse>(response);
        }
    }
}
