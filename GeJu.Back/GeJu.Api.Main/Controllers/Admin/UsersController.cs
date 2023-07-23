using DAL.Interfaces;
using GeJu.Common.DTO.Users;
using Microsoft.AspNetCore.Mvc;

namespace GeJu.Api.Main.Controllers.Admin
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserDAL _usersDAL;
        public UsersController(IUserDAL usersDAL)
        {
            _usersDAL = usersDAL;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var users = _usersDAL.GetAll();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public IActionResult GetUser(string id)
        {
            var user = _usersDAL.GetById(new Guid(id));
            return Ok(user);
        }

        [HttpPost]
        public async Task<ActionResult<UserApi>> CreateUserAsync([FromBody] CreateUserDTO userDTO)
        {
            var response = await _usersDAL.CreateAsync(userDTO);
            return Ok(response);
        }

        [HttpPut]
        public async Task<ActionResult<UserApi>> UpdateUserAsync(UpdateUserDTO userDTO)
        {
            var response = await _usersDAL.UpdateAsync(userDTO);
            return Ok(response);
        }

        //[HttpPatch("id")]
        //public IActionResult ActiveUser(string id, [FromBody] UpdateUserDTO userDTO)
        //{
        //    var response = _usersWorkflow.UpdateAsync(userDTO);
        //    return Ok(response);
        //}

        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> DeleteAsync(string id)
        {
            return Ok(await _usersDAL.DeleteAsync(new Guid(id)));
        }
    }
}
