using AutoMapper;
using GeJu.Api.Main.Models.Authentication;
using GeJu.Api.Main.Models.Users;
using Microsoft.AspNetCore.Mvc;
using Resources.Contract.Authentication;
using Resources.Contract.Users;
using System.Collections.Generic;
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
        public async Task<ActionResult<UserAuthApi>> Register([FromBody] CreateUserApiRequest request)
        {
            var registerUser = _mapper.Map<CreateUser>(request);
            var model = await _userManager.Register(registerUser);
            var modelApi = _mapper.Map<UserAuthApi>(model);
            return modelApi;
        }

        [HttpPost("login")]
        public ActionResult<UserAuthApi> Login([FromBody] LoginApiRequest loginRequest)
        {
            var login = _mapper.Map<Login>(loginRequest);
            var model = _userManager.Login(login);
            if (model is null)
            {
                new KeyNotFoundException("Correo o contraseña es incorrecto");
            }
            var modelApi = _mapper.Map<UserAuthApi>(model);
            return Ok(modelApi);
        }
    }
}
