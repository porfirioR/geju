﻿using AutoMapper;
using AutoMapper.QueryableExtensions;
using GeJu.Api.Main.Workflow.Interfaces;
using GeJu.Common.DTO.User;
using GeJu.Services.Admin.Interfaces;
using Intermedio.Users;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GeJu.Api.Main.Workflow
{
    public class UsersWorkflow : IUsersWorkflow
    {
        private readonly IMapper _mapper;
        private readonly IUsersServices _usersServices;
        public UsersWorkflow(IUsersServices usersServices, IMapper mapper)
        {
            _usersServices = usersServices;
            _mapper = mapper;
        }

        public async Task<bool> CreateAsync(CreateUserDTO userDTO)
        {
            var userCommand = _mapper.Map<CreateUser>(userDTO);
            await _usersServices.CreateAsync(userCommand);
            return await Task.FromResult(true);
        }

        public void Delete(Guid id)
        {
            _usersServices.Delete(id);
        }

        public IEnumerable<UpdateUserDTO> GetAll()
        {
            var users = _usersServices.GetAll();
            var usersCommands = users.ProjectTo<UpdateUser>(_mapper.ConfigurationProvider);
            var usersDto = _mapper.Map<IEnumerable<UpdateUserDTO>>(usersCommands);
            return usersDto;
        }

        public UpdateUserDTO GetById(Guid id)
        {
            var user = _usersServices.GetById(id);
            var userCommand = _mapper.Map<UpdateUser>(user);
            var userDto = _mapper.Map<UpdateUserDTO>(userCommand);
            return userDto;
        }

        public async Task<bool> UpdateAsync(UpdateUserDTO userDTO)
        {
            var userUpdate = _mapper.Map<UpdateUser>(userDTO);
            return await _usersServices.UpdateAsync(userUpdate);
        }
    }
}
