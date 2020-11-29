using GeJu.Common.DTO.Users;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IUserDAL
    {
        Task<UserApi> CreateAsync(CreateUserDTO userDTO);
        Task<UserApi> UpdateAsync(UpdateUserDTO userDTO);
        IEnumerable<UserApi> GetAll();
        UserApi GetById(Guid id);
        Task<bool> DeleteAsync(Guid id);
    }
}
