using AutoMapper;
using AutoMapper.QueryableExtensions;
using Commands.Users;
using GeJu.Api.Main.DTO.Users;
using GeJu.Api.Main.Workflow.Interfaces;
using GeJu.Services.Admin.Interfaces;
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

        public Task<bool> CreateAsync(CreateUserDTO userDTO)
        {
            try
            {
                var userCommand = _mapper.Map<CreateUserCommand>(userDTO);
                _usersServices.CreateAsync(userCommand).Wait();
                return Task.FromResult(true);
            }
            catch (System.Exception ex)
            {
                throw;
            }
            
        }

        public void Delete(string id)
        {
            _usersServices.Delete(id);
        }

        public IEnumerable<UpdateUserDTO> GetAll()
        {
            var users = _usersServices.GetAll();
            var usersCommands = users.ProjectTo<UpdateUserCommand>(_mapper.ConfigurationProvider);
            var usersDto = _mapper.Map<IEnumerable<UpdateUserDTO>>(usersCommands);
            return usersDto;
        }

        public UpdateUserDTO GetById(string id)
        {
            var user = _usersServices.GetUserById(id);
            var userCommand = _mapper.Map<UpdateUserCommand>(user);
            var userDto = _mapper.Map<UpdateUserDTO>(userCommand);
            return userDto;
        }

        public Task<bool> UpdateAsync(UpdateUserDTO userDTO)
        {
            var userUpdate = _mapper.Map<UpdateUserCommand>(userDTO);
            _usersServices.UpdateAsync(userUpdate);
            return Task.FromResult(true);
        }
    }
}
