﻿using AutoMapper;
using Contract.Users;
using GeJu.Api.Main.Models.Users;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GeJu.Api.Main.Controllers.Admin
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserManager _userDAL;
        private readonly IMapper _mapper;
        public UsersController(IUserManager usersDAL, IMapper mapper)
        {
            _userDAL = usersDAL;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<ActionResult<UserApi>> Create([FromBody] CreateUserApiRequest request)
        {
            var user = _mapper.Map<CreateUser>(request);
            var model = await _userDAL.Create(user);
            var modelApi = _mapper.Map<UserApi>(model);
            return Ok(modelApi);
        }

        [HttpPut]
        public async Task<ActionResult<UserApi>> Update(UpdateUserApiRequest userDTO)
        {
            var user = _mapper.Map<UpdateUser>(userDTO);
            var model = await _userDAL.Update(user);
            var modelApi = _mapper.Map<UserApi>(model);
            return Ok(modelApi);
        }

        [HttpGet]
        public ActionResult<IEnumerable<UserApi>> GetAll()
        {
            var model = _userDAL.GetAll();
            var modelApi = _mapper.Map<IEnumerable<UserApi>>(model);
            return Ok(modelApi);
        }

        [HttpGet("{id}")]
        public ActionResult<UserApi> GetById(string id)
        {
            var user = _userDAL.GetById(id);
            var modelApi = _mapper.Map<UserApi>(user);
            return Ok(modelApi);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> Delete(string id)
        {
            return Ok(await _userDAL.Delete(id));
        }
    }
}
