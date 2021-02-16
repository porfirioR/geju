using AutoMapper;
using GeJu.DALModels.Users;
using GeJu.Services.Admin.Interfaces;
using GeJu.Sql;
using GeJu.Sql.Entities;
using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace GeJu.Services.Admin.Implementations
{
    internal class UserService : IUserService
    {
        private readonly IMapper _mapper;
        private readonly DataContext _context;
        public UserService(IMapper mapper, DataContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<Usuario> CreateAsync(CreateUser model)
        {
            var user = _mapper.Map<Usuario>(model);
            await _context.AddAsync(user);
            return await _context.SaveChangesAsync() > 0 ? user : null;
        }

        public Usuario GetById(string id)
        {
            return _context.Set<Usuario>().SingleOrDefault(x => x.Id == new Guid(id));
        }

        public IQueryable<Usuario> GetAll()
        {
            return _context.Set<Usuario>().Where(u => u.Activo).AsQueryable();
        }

        public async Task<Usuario> UpdateAsync(UpdateUser updateUser)
        {
            var entity = GetById(updateUser.Id);
            var user = _mapper.Map(updateUser, entity);
            return await _context.SaveChangesAsync() > 0 ? user : null;
        }

        public async Task<bool> DeleteAsync(string id)
        {
            var userToDelete = _context.Set<Usuario>().SingleOrDefault(x => x.Id == new Guid(id));
            userToDelete.Activo = false;
            _context.Update(userToDelete);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<Usuario> RegisterAsync(CreateUser createUser)
        {
            var entity = _mapper.Map<Usuario>(createUser);
            using var hmac = new HMACSHA512();
            entity.ContraseñaHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(createUser.Password));
            entity.ContraseñaSalt = hmac.Key;
            await _context.AddAsync(entity);
            return await _context.SaveChangesAsync() > 0 ? entity : null;
        }
    }
}
