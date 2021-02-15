using AutoMapper;
using DAL.Interfaces;
using GeJu.DALModels.Brands;
using GeJu.Api.Main.DTO.Brands;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace GeJu.Api.Main.Controllers.Admin
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandsController : ControllerBase
    {
        private readonly IBrandDAL _brandDAL;
        private readonly IMapper _mapper;
        public BrandsController(IBrandDAL brandDAL, IMapper mapper)
        {
            _brandDAL = brandDAL;
            _mapper = mapper;
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
            var model = _mapper.Map<CreateBrand>(brandDTO);
            var response = await _brandDAL.CreateAsync(model);
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateBrandAsync(UpdateBrandDTO brandDTO)
        {
            var model = _mapper.Map<UpdateBrand>(brandDTO);
            var response = await _brandDAL.UpdateAsync(model);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(string id)
        {
            return Ok(await _brandDAL.DeleteAsync(new Guid(id)));
        }
    }
}
