using AutoMapper;
using GeJu.Api.Main.Models.Brands;
using Microsoft.AspNetCore.Mvc;
using Resources.Contract.Brands;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GeJu.Api.Main.Controllers.Admin
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandsController : ControllerBase
    {
        private readonly IBrandManager _brandManager;
        private readonly IMapper _mapper;
        public BrandsController(IMapper mapper, IBrandManager brandManager)
        {
            _mapper = mapper;
            _brandManager = brandManager;
        }

        [HttpPost]
        public async Task<ActionResult<BrandApi>> Create(CreateBrandApiRequest request)
        {
            var model = _mapper.Map<CreateBrand>(request);
            var response = await _brandManager.Create(model);
            var modelApi = _mapper.Map<BrandApi>(response);
            return Ok(modelApi);
        }

        [HttpPut]
        public async Task<ActionResult<BrandApi>> Update(UpdateBrandApiRequest request)
        {
            var model = _mapper.Map<UpdateBrand>(request);
            var response = await _brandManager.Update(model);
            var modelApi = _mapper.Map<BrandApi>(response);
            return Ok(modelApi);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BrandApi>> GetById(string id)
        {
            var brand = await _brandManager.GetById(id);
            var brandApi = _mapper.Map<BrandApi>(brand);
            return Ok(brandApi);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<BrandApi>>> GetAll()
        {
            var brands = await _brandManager.GetAll();
            var response = _mapper.Map<IEnumerable<BrandApi>>(brands);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<BrandApi>> Delete(string id)
        {
            var brand = await _brandManager.Delete(id);
            return Ok(_mapper.Map<BrandApi>(brand));
        }
    }
}
