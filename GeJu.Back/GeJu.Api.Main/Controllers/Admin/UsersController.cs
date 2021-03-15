using AutoMapper;
using GeJu.Api.Main.Models.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Resources.Contract.Users;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GeJu.Api.Main.Controllers.Admin
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserManager _userManager;
        private readonly IMapper _mapper;
        public UsersController(IUserManager userManager, IMapper mapper)
        {
            _userManager = userManager;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<ActionResult<UserApi>> Create([FromBody] CreateUserApiRequest request)
        {
            var user = _mapper.Map<CreateUser>(request);
            var model = await _userManager.Create(user);
            var modelApi = _mapper.Map<UserApi>(model);
            return Ok(modelApi);
        }

        [HttpPut]
        public async Task<ActionResult<UserApi>> Update(UpdateUserApiRequest userDTO)
        {
            var user = _mapper.Map<UpdateUser>(userDTO);
            var model = await _userManager.Update(user);
            var modelApi = _mapper.Map<UserApi>(model);
            return Ok(modelApi);
        }

        [Authorize]
        [HttpGet]
        public ActionResult<IEnumerable<UserApi>> GetAll()
        {
            var model = _userManager.GetAll();
            var modelApi = _mapper.Map<IEnumerable<UserApi>>(model);
            return Ok(modelApi);
        }

        [AllowAnonymous]
        [HttpGet("{id}")]
        public ActionResult<UserApi> GetById(string id)
        {
            var user = _userManager.GetById(id);
            var modelApi = _mapper.Map<UserApi>(user);
            return Ok(modelApi);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> Delete(string id)
        {
            return Ok(await _userManager.Delete(id));
        }
    }
}
