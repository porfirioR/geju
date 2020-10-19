using GeJu.Sql.Entities;
using AccessServicesModel.Users;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace GeJu.Services.Admin.Interfaces
{
    public interface IUsersServices
    {
        Usuario GetById(Guid id);
        IQueryable<Usuario> GetAll();
        Task<bool> CreateAsync(CreateUser command);
        Task<bool> UpdateAsync(UpdateUser command);
        Task<bool> DeleteAsync(Guid id);
    }
}
