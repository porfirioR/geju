using AutoMapper;
using AutoMapper.QueryableExtensions;
using DAL.Interfaces;
using GeJu.DALModels.Authentication;
using GeJu.DALModels.Users;
using GeJu.Services.Admin.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    internal class UserDAL : IUserDAL
    {
        private readonly IMapper _mapper;
        private readonly IUserService _userService;
        private readonly ITokenService _tokenService;

        public UserDAL(IUserService userService, IMapper mapper, ITokenService tokenService)
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

        public async Task<bool> Delete(Guid id)
        {
            return await _userService.DeleteAsync(id);
        }

        public IEnumerable<User> GetAll()
        {
            var users = _userService.GetAll();
            var usersCommands = users.ProjectTo<User>(_mapper.ConfigurationProvider);
            return usersCommands;
        }

        public User GetById(Guid id)
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
