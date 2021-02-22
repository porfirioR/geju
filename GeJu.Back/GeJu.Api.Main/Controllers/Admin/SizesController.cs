using AutoMapper;
using GeJu.Api.Main.Models.Sizes;
using Microsoft.AspNetCore.Mvc;
using Resources.Contract.Sizes;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GeJu.Api.Main.Controllers.Admin
{
    [Route("api/[controller]")]
    [ApiController]
    public class SizesController : Controller
    {
        private readonly IMapper _mapper;
        private readonly ISizeManager _sizeManager;
        public SizesController(IMapper mapper, ISizeManager sizeManager)
        {
            _mapper = mapper;
            _sizeManager = sizeManager;
        }

        [HttpPost]
        public async Task<ActionResult<SizeApi>> Create(CreateSizeApiRequest request)
        {
            var requestManager = _mapper.Map<CreateSize>(request);
            var model = await _sizeManager.Create(requestManager);
            var modelApi = _mapper.Map<SizeApi>(model);
            return Ok(modelApi);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<SizeApi>>> GetAll()
        {
            var model = await _sizeManager.GetAll();
            var apiModel = _mapper.Map<IEnumerable<SizeApi>>(model);
            return Ok(apiModel);
        }
        
        [HttpGet("{id}")]
        public ActionResult<SizeApi> GetById(string id)
        {
            var model = _sizeManager.GetById(id);
            var modelApi = _mapper.Map<SizeApi>(model);
            return Ok(modelApi);
        }

        [HttpPut]
        public async Task<ActionResult<SizeApi>> Update(UpdateSizeApiRequest request)
        {
            var requestManager = _mapper.Map<UpdateSize>(request);
            var model = await _sizeManager.Update(requestManager);
            var modelApi = _mapper.Map<SizeApi>(model);
            return Ok(modelApi);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<SizeApi>> Delete(string id)
        {
            var model = await _sizeManager.Delete(id);
            var modelApi = _mapper.Map<SizeApi>(model);
            return Ok(modelApi);
        }
    }
}
