using AutoMapper;
using GeJu.Api.Main.Models.Authentication;
using GeJu.Api.Main.Models.Users;
using Microsoft.AspNetCore.Mvc;
using Resources.Contract.Authentication;
using Resources.Contract.Users;
using System;
using System.Threading.Tasks;

namespace GeJu.Api.Main.Controllers.Admin
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IUserManager _userManager;
        public AuthenticationController(IMapper mapper, IUserManager userDAL)
        {
            _mapper = mapper;
            _userManager = userDAL;
        }

        [HttpPost("register")]
        public async Task<ActionResult<UserAuth>> Register([FromBody] CreateUserApiRequest request)
        {
            var registerUser = _mapper.Map<CreateUser>(request);
            var model = await _userManager.Register(registerUser);
            return model;
        }

        [HttpPost("login")]
        public async Task<ActionResult<UserAuth>> Login([FromBody] LoginApiRequest loginRequest)
        {
            try
            {
                var login = _mapper.Map<Login>(loginRequest);
                var model = await _userManager.Login(login);
                return model;
            }
            catch (Exception ex)
            {
                return Unauthorized(ex.Message);
            }
        }
    }
}
