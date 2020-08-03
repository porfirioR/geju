using GeJu.Api.Main.DTO.Users;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GeJu.Api.Main.Workflow.Interfaces
{
    public interface IUsersWorkflow
    {
        Task<bool> CreateAsync(CreateUserDTO userDTO);
        Task<bool> UpdateAsync(UpdateUserDTO userDTO);
        IEnumerable<UpdateUserDTO> GetAll();
        UpdateUserDTO GetById(string id);
        void Delete(string id);
    }
}
