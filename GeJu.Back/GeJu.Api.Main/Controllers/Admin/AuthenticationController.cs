using AutoMapper;
using DAL.Interfaces;
using GeJu.Common.DTO.Authentication;
using GeJu.Common.DTO.Users;
using GeJu.DALModels.Authentication;
using GeJu.DALModels.Users;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GeJu.Api.Main.Controllers.Admin
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IUserDAL _userDAL;
        public AuthenticationController(IMapper mapper, IUserDAL userDAL)
        {
            _mapper = mapper;
            _userDAL = userDAL;
        }

        [HttpPost("register")]
        public async Task<ActionResult<UserAuthApi>> Register([FromBody] CreateUserDTO createUserDTO)
        {
            var registerUser = _mapper.Map<CreateUser>(createUserDTO);
            var model = await _userDAL.Register(registerUser);
            var modelApi = _mapper.Map<UserAuthApi>(model);
            return modelApi;
        }

        [HttpPost("login")]
        public ActionResult<UserAuthApi> Login([FromBody] LoginDTO loginDTO)
        {
            var login = _mapper.Map<Login>(loginDTO);
            var model = _userDAL.Login(login);
            if (model is null)
            {
                new KeyNotFoundException("Correo o contraseña es incorrecto");
            }
            var modelApi = _mapper.Map<UserAuthApi>(model);
            return Ok(modelApi);
        }
    }
}
