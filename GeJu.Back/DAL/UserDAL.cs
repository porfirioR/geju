using AutoMapper;
using AutoMapper.QueryableExtensions;
using DAL.Interfaces;
using GeJu.AccessServicesModel.Users;
using GeJu.Common.DTO.Users;
using GeJu.Services.Admin.Interfaces;

namespace DAL
{
    internal class UserDAL : IUserDAL
    {
        private readonly IMapper _mapper;
        private readonly IUsersServices _usersServices;

        public UserDAL(IUsersServices usersServices, IMapper mapper)
        {
            _usersServices = usersServices;
            _mapper = mapper;
        }

        public async Task<UserApi> CreateAsync(CreateUserDTO userDTO)
        {
            var userDAM = _mapper.Map<CreateUser>(userDTO);
            var user = await _usersServices.CreateAsync(userDAM);
            return _mapper.Map<UserApi>(user);
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            return await _usersServices.DeleteAsync(id);
        }

        public IEnumerable<UserApi> GetAll()
        {
            var users = _usersServices.GetAll();
            var usersCommands = users.ProjectTo<UserApi>(_mapper.ConfigurationProvider);
            return usersCommands;
        }

        public UserApi GetById(Guid id)
        {
            var user = _usersServices.GetById(id);
            return _mapper.Map<UserApi>(user);
        }

        public async Task<UserApi> UpdateAsync(UpdateUserDTO userDTO)
        {
            var userUpdate = _mapper.Map<UpdateUser>(userDTO);
            var user = await _usersServices.UpdateAsync(userUpdate);
            return _mapper.Map<UserApi>(user);
        }
    }
}
