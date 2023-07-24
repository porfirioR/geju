using DAL.Interfaces;
using GeJu.Common.DTO.Brands;
using Microsoft.AspNetCore.Mvc;

namespace GeJu.Api.Main.Controllers.Admin
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandsController : ControllerBase
    {
        private readonly IBrandDAL _brandDAL;
        public BrandsController(IBrandDAL brandDAL)
        {
            _brandDAL = brandDAL;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var brands = _brandDAL.GetAll();
            return Ok(brands);
        }

        [HttpGet("{id}")]
        public IActionResult GetBrand(string id)
        {
            var brand = _brandDAL.GetById(new Guid(id));
            return Ok(brand);
        }

        [HttpPost]
        public async Task<IActionResult> CreateBrandAsync(CreateBrandDTO brandDTO)
        {
            var response = await _brandDAL.CreateAsync(brandDTO);
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateBrandAsync(UpdateBrandDTO brandDTO)
        {
            var response = await _brandDAL.UpdateAsync(brandDTO);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(string id)
        {
            return Ok(await _brandDAL.DeleteAsync(new Guid(id)));
        }
    }
}
