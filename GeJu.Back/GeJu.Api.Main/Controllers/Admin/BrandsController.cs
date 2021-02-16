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
            var brand = _brandDAL.GetById(id);
            return Ok(brand);
        }

        [HttpPost]
        public async Task<ActionResult<BrandApi>> CreateBrand(CreateBrandDTO brandDTO)
        {
            var model = _mapper.Map<CreateBrand>(brandDTO);
            var response = await _brandDAL.Create(model);
            var modelApi = _mapper.Map<BrandApi>(response);
            return Ok(modelApi);
        }

        [HttpPut]
        public async Task<ActionResult<BrandApi>> UpdateBrand(UpdateBrandDTO brandDTO)
        {
            var model = _mapper.Map<UpdateBrand>(brandDTO);
            var response = await _brandDAL.Update(model);
            var modelApi = _mapper.Map<BrandApi>(response);
            return Ok(modelApi);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> Delete(string id)
        {
            return Ok(await _brandDAL.Delete(id));
        }
    }
}
