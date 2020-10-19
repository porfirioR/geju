using GeJu.Api.Main.Middle.Interfaces;
using GeJu.Common.DTO.User;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace GeJu.Api.Main.Controllers.Admin
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUsersMiddle _usersWorkflow;
        public UsersController(IUsersMiddle usersWorkflow)
        {
            _usersWorkflow = usersWorkflow;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var users = _usersWorkflow.GetAll();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public IActionResult GetUser(string id)
        {
            var user = _usersWorkflow.GetById(new Guid(id));
            return Ok(user);
        }

        [HttpPost]
        public async Task<IActionResult> CreateUserAsync([FromBody] CreateUserDTO userDTO)
        {
            var response = await _usersWorkflow.CreateAsync(userDTO);
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateUserAsync([FromBody] UpdateUserDTO userDTO)
        {
            var response = await _usersWorkflow.UpdateAsync(userDTO);
            return Ok(response);
        }

        //[HttpPatch("id")]
        //public IActionResult ActiveUser(string id, [FromBody] UpdateUserDTO userDTO)
        //{
        //    var response = _usersWorkflow.UpdateAsync(userDTO);
        //    return Ok(response);
        //}

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(string id)
        {
            return Ok(await _usersWorkflow.DeleteAsync(new Guid(id)));
        }
    }
}
