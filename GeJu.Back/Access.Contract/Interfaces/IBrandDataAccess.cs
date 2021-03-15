using Access.Contract.Request;
using Access.Contract.Response;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Admin.Interfaces
{
    public interface IBrandDataAccess
    {
        Task<BrandAccessResponse> CreateAsync(BrandAccess model);
        Task<IEnumerable<BrandAccessResponse>> GetAllAsync();
        Task<BrandAccessResponse> GetByIdAsync(string id);
        Task<BrandAccessResponse> UpdateAsync(BrandAccess model);
        Task<BrandAccessResponse> DeleteAsync(string id);
    }
}
