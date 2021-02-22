using Access.Contract.Request;
using Admin.Interfaces;
using AutoMapper;
using Resources.Contract.Authentication;
using Resources.Contract.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Manager.Admin.Users
{
    internal class UserManager : IUserManager
    {
        private readonly IMapper _mapper;
        private readonly IUserDataAccess _userDataAccess;
        private readonly IAuthDataAccess _tokenDataAccess;

        public UserManager(IUserDataAccess userDataAccess, IMapper mapper, IAuthDataAccess tokenDataAccess)
        {
            _userDataAccess = userDataAccess;
            _mapper = mapper;
            _tokenDataAccess = tokenDataAccess;
        }

        public async Task<UserResponse> Create(CreateUser request)
        {
            var requestAccess = _mapper.Map<UserAccess>(request);
            var user = await _userDataAccess.CreateAsync(requestAccess);
            return _mapper.Map<UserResponse>(user);
        }

        public async Task<UserResponse> Update(UpdateUser request)
        {
            var requestManager = _mapper.Map<UserAccess>(request);
            var user = await _userDataAccess.UpdateAsync(requestManager);
            return _mapper.Map<UserResponse>(user);
        }

        public async Task<IEnumerable<UserResponse>> GetAll()
        {
            var users = await _userDataAccess.GetAllAsync();
            var userResponse = _mapper.Map<IEnumerable<UserResponse>>(users);
            return userResponse;
        }

        public async Task<UserResponse> GetById(string id)
        {
            var user = await _userDataAccess.GetByIdAsync(id);
            return _mapper.Map<UserResponse>(user);
        }

        public async Task<UserResponse> Delete(string id)
        {
            var user = await _userDataAccess.DeleteAsync(id);
            return _mapper.Map<UserResponse>(user);
        }

        public async Task<UserAuth> Register(CreateUser request)
        {
            if (await CheckUserExistsAsync(request))
            {
                new Exception("Ya existe un usuario con ese mismo documento.");
            }
            var requestAccess = _mapper.Map<UserAccess>(request);
            var user = await _userDataAccess.RegisterAsync(requestAccess);
            var userApi = _mapper.Map<UserAuth>(user);
            userApi.Token = _tokenDataAccess.CreateToken(requestAccess);
            return userApi;
        }

        public async Task<UserAuth> LoginAsync(Login login)
        {
            var loginAccess = _mapper.Map<LoginAccess>(login);
            var auth = await _tokenDataAccess.Login(loginAccess);
            var userApi = _mapper.Map<UserAuth>(auth);
            return userApi;
        }

        private async Task<bool> CheckUserExistsAsync(CreateUser createUser)
        {
            var users = await _userDataAccess.GetAllAsync();
            var result = users.Where(x => x.Document == createUser.Document || x.Email == createUser.Email);
            return users.Any();
        }
    }
}
