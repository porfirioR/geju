using Access.Contract.Request;
using Access.Contract.Response;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Admin.Interfaces
{
    public interface ISizeDataAccess
    {
        Task<SizeAccessResponse> CreateAsync(SizeAccess model);
        Task<IEnumerable<SizeAccessResponse>> GetAllAsync();
        Task<SizeAccessResponse> GetByIdAsync(string id);
        Task<SizeAccessResponse> UpdateAsync(SizeAccess model);
        Task<SizeAccessResponse> DeleteAsync(string id);
    }
}
