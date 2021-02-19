using AutoMapper;
using Contract.Brands;
using GeJu.Api.Main.Models.Brands;
using Microsoft.AspNetCore.Mvc;
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

        [HttpGet]
        public IActionResult GetAll()
        {
            var brands = _brandManager.GetAll();
            return Ok(brands);
        }

        [HttpGet("{id}")]
        public IActionResult GetBrand(string id)
        {
            var brand = _brandManager.GetById(id);
            return Ok(brand);
        }

        [HttpPost]
        public async Task<ActionResult<BrandApi>> CreateBrand(CreateBrandApiRequest brandDTO)
        {
            var model = _mapper.Map<CreateBrand>(brandDTO);
            var response = await _brandManager.Create(model);
            var modelApi = _mapper.Map<BrandApi>(response);
            return Ok(modelApi);
        }

        [HttpPut]
        public async Task<ActionResult<BrandApi>> UpdateBrand(UpdateBrandApiRequest brandDTO)
        {
            var model = _mapper.Map<UpdateBrand>(brandDTO);
            var response = await _brandManager.Update(model);
            var modelApi = _mapper.Map<BrandApi>(response);
            return Ok(modelApi);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> Delete(string id)
        {
            return Ok(await _brandManager.Delete(id));
        }
    }
}
