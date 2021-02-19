using Admin.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Contract.Authentication;
using Contract.Users;
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
        private readonly IUserService _userService;
        private readonly ITokenService _tokenService;

        public UserManager(IUserService userService, IMapper mapper, ITokenService tokenService)
        {
            _userService = userService;
            _mapper = mapper;
            _tokenService = tokenService;
        }

        public async Task<User> Create(CreateUser request)
        {
            var user = await _userService.CreateAsync(request);
            return _mapper.Map<User>(user);
        }

        public async Task<bool> Delete(string id)
        {
            return await _userService.DeleteAsync(id);
        }

        public IEnumerable<User> GetAll()
        {
            var users = _userService.GetAll();
            var user = users.ProjectTo<User>(_mapper.ConfigurationProvider);
            return user;
        }

        public User GetById(string id)
        {
            var user = _userService.GetById(id);
            return _mapper.Map<User>(user);
        }

        public async Task<User> Update(UpdateUser request)
        {
            var user = await _userService.UpdateAsync(request);
            return _mapper.Map<User>(user);
        }

        public async Task<UserAuth> Register(CreateUser createUser)
        {
            if (CheckUserExists(createUser))
            {
                new Exception("Ya existe un usuario con ese mismo documento.");
            }
            var user = await _userService.RegisterAsync(createUser);
            var userApi = _mapper.Map<UserAuth>(user);
            userApi.Token = _tokenService.CreateToken(user);
            return userApi;
        }

        public UserAuth Login(Login login)
        {
            var users = _userService.GetAll();
            var user = users.Where(x => x.Correo == login.Email).FirstOrDefault();
            if (user is null)
            {
                return null;
            }

            using var hmac = new HMACSHA512(user.ContraseñaSalt);
            var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(login.Password));

            for (int i = 0; i < computedHash.Length; i++)
            {
                if (computedHash[i] != user.ContraseñaHash[i])
                {
                    return null;
                }
            }

            var userApi = _mapper.Map<UserAuth>(user);
            userApi.Token = _tokenService.CreateToken(user);
            return userApi;
        }

        private bool CheckUserExists(CreateUser createUser)
        {
            var users = _userService.GetAll()
                .Where(x => x.Documento == createUser.Document || x.Correo == createUser.Email);
            return users.Any();
        }
    }
}
