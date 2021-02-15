using AutoMapper;
using DAL.Interfaces;
using GeJu.Common.DTO.Users;
using GeJu.DALModels.Users;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace GeJu.Api.Main.Controllers.Admin
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserDAL _userDAL;
        private readonly IMapper _mapper;
        public UsersController(IUserDAL usersDAL, IMapper mapper)
        {
            _userDAL = usersDAL;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var users = _userDAL.GetAll();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public IActionResult GetUser(string id)
        {
            var user = _userDAL.GetById(new Guid(id));
            return Ok(user);
        }

        [HttpPost]
        public async Task<ActionResult<UserApi>> CreateUserAsync([FromBody] CreateUserDTO userDTO)
        {
            var user = _mapper.Map<CreateUser>(userDTO);
            var model = await _userDAL.Create(user);
            var modelApi = _mapper.Map<UserApi>(model);
            return Ok(modelApi);
        }

        [HttpPut]
        public async Task<ActionResult<UserApi>> UpdateUser(UpdateUserDTO userDTO)
        {
            var user = _mapper.Map<UpdateUser>(userDTO);
            var model = await _userDAL.Update(user);
            var modelApi = _mapper.Map<UserApi>(model);
            return Ok(modelApi);
        }

        //[HttpPatch("id")]
        //public IActionResult ActiveUser(string id, [FromBody] UpdateUserDTO userDTO)
        //{
        //    var response = _usersWorkflow.UpdateAsync(userDTO);
        //    return Ok(response);
        //}

        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> Delete(string id)
        {
            return Ok(await _userDAL.Delete(new Guid(id)));
        }
    }
}
