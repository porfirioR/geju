using GeJu.DALModels.Users;
using GeJu.Sql.Entities;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace GeJu.Services.Admin.Interfaces
{
    public interface IUserService
    {
        Usuario GetById(Guid id);
        IQueryable<Usuario> GetAll();
        Task<Usuario> CreateAsync(CreateUser command);
        Task<Usuario> UpdateAsync(UpdateUser command);
        Task<bool> DeleteAsync(Guid id);
        Task<Usuario> RegisterAsync(CreateUser createUser);
    }
}
