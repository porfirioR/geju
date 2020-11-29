using AccessServicesModel.Users;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using GeJu.Api.Main.Middle.Interfaces;
using GeJu.Common.DTO.Users;
using GeJu.Services.Admin.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GeJu.Api.Main.Middle
{
    public class BrandDAL : IUsersMiddle
    {
        private readonly IMapper _mapper;
        private readonly IUsersServices _usersServices;
        public BrandDAL(IUsersServices usersServices, IMapper mapper)
        {
            _usersServices = usersServices;
            _mapper = mapper;
        }

        public async Task<bool> CreateAsync(CreateUserDTO userDTO)
        {
            var userCommand = _mapper.Map<CreateUser>(userDTO);
            return await Task.FromResult(await _usersServices.CreateAsync(userCommand));
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            return await _usersServices.DeleteAsync(id);
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
            return await Task.FromResult(await _usersServices.UpdateAsync(userUpdate));
        }
    }
}
