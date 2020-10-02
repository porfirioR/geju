using GeJu.Api.Main.DTO.Users;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GeJu.Api.Main.Workflow.Interfaces
{
    public interface IUsersWorkflow
    {
        Task<bool> CreateAsync(CrearUsuarioDTO userDTO);
        Task<bool> UpdateAsync(ActualizarUsuarioDTO userDTO);
        IEnumerable<ActualizarUsuarioDTO> GetAll();
        ActualizarUsuarioDTO GetById(string id);
        void Delete(string id);
    }
}
