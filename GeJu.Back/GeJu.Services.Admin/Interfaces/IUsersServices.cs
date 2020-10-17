using GeJu.Sql.Entities;
using Intermedio.Users;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace GeJu.Services.Admin.Interfaces
{
    public interface IUsersServices
    {
        Usuario GetById(Guid id);
        IQueryable<Usuario> GetAll();
        Task CreateAsync(CreateUser command);
        Task<bool> UpdateAsync(UpdateUser command);
        void Delete(Guid id);
    }
}
