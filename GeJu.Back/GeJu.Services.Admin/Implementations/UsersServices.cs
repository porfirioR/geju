using AutoMapper;
using Commands.Users;
using GeJu.Services.Admin.Interfaces;
using GeJu.Storage.Sql;
using GeJu.Storage.Sql.Entities;
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

        public async Task CreateAsync(CreateUserCommand command)
        {
            try
            {
                var user = _mapper.Map<Usuario>(command);
                user.Id = Guid.NewGuid().ToString();
                await _context.AddAsync(user);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            
        }

        public void Delete(string id)
        {
            var userToDelete = _context.Set<Usuario>().SingleOrDefault(x => x.Id == id);
            userToDelete.Active = false;
            _context.Update(userToDelete);
            _context.SaveChangesAsync();
        }

        public IQueryable<Usuario> GetAll()
        {
            return _context.Set<Usuario>().AsQueryable();
        }

        public Usuario GetUserById(string id)
        {
            return _context.Set<Usuario>().SingleOrDefault(x => x.Id == id);
        }

        public async Task UpdateAsync(UpdateUserCommand command)
        {
            var user = _mapper.Map<UpdateUserCommand>(command);
            _context.Update(user);
            await _context.SaveChangesAsync();
        }
    }
}
