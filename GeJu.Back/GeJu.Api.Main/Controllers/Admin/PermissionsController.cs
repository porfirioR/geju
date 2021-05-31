using AutoMapper;
using GeJu.Api.Main.Models.Permissions;
using Microsoft.AspNetCore.Mvc;
using Resources.Contract.Permissions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GeJu.Api.Main.Controllers.Admin
{
    [Route("api/[controller]")]
    [ApiController]
    public class PermissionsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IPermissionManager _permissionManager;
        public PermissionsController(IMapper mapper, IPermissionManager permissionManager)
        {
            _mapper = mapper;
            _permissionManager = permissionManager;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PermissionApi>>> GetAll()
        {
            var permissions = await _permissionManager.GetAll();
            var response = _mapper.Map<IEnumerable<PermissionApi>>(permissions);
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PermissionApi>> GetById(string id)
        {
            var response = await _permissionManager.GetById(id);
            var responseApi = _mapper.Map<PermissionApi>(response);
            return Ok(responseApi);
        }

        [HttpPut]
        public async Task<ActionResult<PermissionApi>> Update(UpdatePermissionApiRequest request)
        {
            var model = _mapper.Map<UpdatePermission>(request);
            var response = await _permissionManager.Update(model);
            var modelApi = _mapper.Map<PermissionApi>(response);
            return Ok(modelApi);
        }

        [HttpPut("active/{id}")]
        public async Task<ActionResult<PermissionApi>> Activate([FromRoute] string id)
        {
            var response = await _permissionManager.Active(id);
            var modelApi = _mapper.Map<PermissionApi>(response);
            return Ok(modelApi);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<PermissionApi>> Delete(string id)
        {
            var model = await _permissionManager.Delete(id);
            return Ok(_mapper.Map<PermissionApi>(model));
        }
    }
}
