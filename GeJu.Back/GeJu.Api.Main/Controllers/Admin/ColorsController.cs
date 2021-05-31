using AutoMapper;
using GeJu.Api.Main.Models.Colors;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Resources.Contract.Colors;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GeJu.Api.Main.Controllers.Admin
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class ColorsController : ControllerBase
    {
        private readonly IColorManager _colorManager;
        private readonly IMapper _mapper;
        public ColorsController(IMapper mapper, IColorManager colorManager)
        {
            _mapper = mapper;
            _colorManager = colorManager;
        }

        [HttpPost]
        public async Task<ActionResult<ColorApi>> Create(CreateColorApiRequest request)
        {
            var model = _mapper.Map<CreateColor>(request);
            var response = await _colorManager.Create(model);
            var modelApi = _mapper.Map<ColorApi>(response);
            return Ok(modelApi);
        }

        [HttpPut]
        public async Task<ActionResult<ColorApi>> Update(UpdateColorApiRequest request)
        {
            var model = _mapper.Map<UpdateColor>(request);
            var response = await _colorManager.Update(model);
            var modelApi = _mapper.Map<ColorApi>(response);
            return Ok(modelApi);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ColorApi>> GetById(string id)
        {
            var color = await _colorManager.GetById(id);
            var colorApi = _mapper.Map<ColorApi>(color);
            return Ok(colorApi);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ColorApi>>> GetAll()
        {
            var colors = await _colorManager.GetAll();
            var response = _mapper.Map<IEnumerable<ColorApi>>(colors);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ColorApi>> Delete(string id)
        {
            var model = await _colorManager.Delete(id);
            return Ok(_mapper.Map<ColorApi>(model));
        }
    }
}
