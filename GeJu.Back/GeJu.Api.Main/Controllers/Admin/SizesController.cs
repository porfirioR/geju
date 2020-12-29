using DAL.Interfaces;
using GeJu.Common.DTO.Size;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GeJu.Api.Main.Controllers.Admin
{
    [Route("api/[controller]")]
    [ApiController]
    public class SizesController : Controller
    {
        private readonly ISizeDAL _sizeDAL;
        public SizesController(ISizeDAL sizeDAL)
        {
            _sizeDAL = sizeDAL;
        }

        [HttpGet]
        public ActionResult<IEnumerable<SizeApi>> GetAll()
        {
            var result = _sizeDAL.GetAll();
            return Ok(result);
        }
    }
}
