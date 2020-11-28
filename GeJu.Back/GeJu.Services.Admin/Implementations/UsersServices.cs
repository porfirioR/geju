using AccessServicesModel.Users;
using AutoMapper;
using GeJu.Services.Admin.Interfaces;
using GeJu.Sql;
using GeJu.Sql.Entities;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace GeJu.Services.Admin.Implementations
{
    internal class UsersServices : IUsersServices
    {
        private readonly IMapper _mapper;
        private readonly DataContext _context;
        public UsersServices(IMapper mapper, DataContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<bool> CreateAsync(CreateUser model)
        {
            var user = _mapper.Map<Usuario>(model);
            await _context.AddAsync(user);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var userToDelete = _context.Set<Usuario>().SingleOrDefault(x => x.Id == id);
            userToDelete.Activo = false;
            _context.Update(userToDelete);
            return await _context.SaveChangesAsync() > 0;
        }

        public IQueryable<Usuario> GetAll()
        {
            return _context.Set<Usuario>().AsQueryable();
        }

        public Usuario GetById(Guid id)
        {
            return _context.Set<Usuario>().SingleOrDefault(x => x.Id == id);
        }

        public async Task<bool> UpdateAsync(UpdateUser command)
        {
            var user = _mapper.Map<Usuario>(command);
            _context.Update(user);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
