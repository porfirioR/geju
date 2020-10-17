using GeJu.Common.DTO.User;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GeJu.Api.Main.Workflow.Interfaces
{
    public interface IUsersWorkflow
    {
        Task<bool> CreateAsync(CreateUserDTO userDTO);
        Task<bool> UpdateAsync(UpdateUserDTO userDTO);
        IEnumerable<UpdateUserDTO> GetAll();
        UpdateUserDTO GetById(Guid id);
        void Delete(Guid id);
    }
}
