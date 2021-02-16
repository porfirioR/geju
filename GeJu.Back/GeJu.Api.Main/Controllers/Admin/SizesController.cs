using AutoMapper;
using DAL.Interfaces;
using GeJu.Api.Main.DTO.Sizes;
using GeJu.DALModels.Sizes;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GeJu.Api.Main.Controllers.Admin
{
    [Route("api/[controller]")]
    [ApiController]
    public class SizesController : Controller
    {
        private readonly ISizeDAL _sizeDAL;
        private readonly IMapper _mapper;
        public SizesController(ISizeDAL sizeDAL, IMapper mapper)
        {
            _sizeDAL = sizeDAL;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<SizeApi>> GetAll()
        {
            var model = _sizeDAL.GetAll();
            var apiModel = _mapper.Map<IEnumerable<SizeApi>>(model);
            return Ok(apiModel);
        }
        
        [HttpGet("{id}")]
        public ActionResult<SizeApi> GetById(string id)
        {
            var model = _sizeDAL.GetById(new Guid(id));
            var modelApi = _mapper.Map<SizeApi>(model);
            return Ok(modelApi);
        }

        [HttpPost]
        public async Task<ActionResult<SizeApi>> CreateAsync(CreateSizeDTO sizeDTO)
        {
            var request = _mapper.Map<CreateSize>(sizeDTO);
            var model = await _sizeDAL.Create(request);
            var modelApi = _mapper.Map<SizeApi>(model);
            return Ok(modelApi);
        }

        [HttpPut]
        public async Task<ActionResult<SizeApi>> UpdateAsync(UpdateSizeDTO sizeDTO)
        {
            var request = _mapper.Map<UpdateSize>(sizeDTO);
            var model = await _sizeDAL.UpdateAsync(request);
            var modelApi = _mapper.Map<SizeApi>(model);
            return Ok(modelApi);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> UpdateAsync(string id)
        {
            var model = await _sizeDAL.Delete(new Guid(id));
            return Ok(model);
        }
    }
}
