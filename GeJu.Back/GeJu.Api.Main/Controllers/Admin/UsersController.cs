using GeJu.Api.Main.DTO.Users;
using GeJu.Api.Main.Workflow.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GeJu.Api.Main.Controllers.Admin
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUsersWorkflow _usersWorkflow;
        public UsersController(IUsersWorkflow usersWorkflow)
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
            var user = _usersWorkflow.GetById(id);
            return Ok(user);
        }

        [HttpPost]
        public IActionResult CreateUser([FromBody] CreateUserDTO userDTO)
        {
            var response = _usersWorkflow.CreateAsync(userDTO);
            return Ok(response);
        }

        [HttpPut]
        public IActionResult UpdateUser([FromBody] UpdateUserDTO userDTO)
        {
            var response = _usersWorkflow.UpdateAsync(userDTO);
            return Ok(response);
        }
        [HttpPatch("id")]
        public IActionResult ActiveUser(string id, [FromBody] UpdateUserDTO userDTO)
        {
            var response = _usersWorkflow.UpdateAsync(userDTO);
            return Ok(response);
        }
    }
}
