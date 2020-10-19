using GeJu.Common.DTO.User;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GeJu.Api.Main.Middle.Interfaces
{
    public interface IUsersMiddle
    {
        Task<bool> CreateAsync(CreateUserDTO userDTO);
        Task<bool> UpdateAsync(UpdateUserDTO userDTO);
        IEnumerable<UpdateUserDTO> GetAll();
        UpdateUserDTO GetById(Guid id);
        Task<bool> DeleteAsync(Guid id);
    }
}
