using GeJu.AccessServicesModel.Users;
using GeJu.Sql.Entities;

namespace GeJu.Services.Admin.Interfaces
{
    public interface IUsersServices
    {
        Usuario GetById(Guid id);
        IQueryable<Usuario> GetAll();
        Task<Usuario> CreateAsync(CreateUser command);
        Task<Usuario> UpdateAsync(UpdateUser command);
        Task<bool> DeleteAsync(Guid id);
    }
}
