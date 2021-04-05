using Access.Contract.Request;
using Access.Contract.Response;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Access.Contract.Interfaces
{
    public interface IColorDataAccess
    {
        Task<ColorAccessResponse> CreateAsync(ColorAccess request);
        Task<IEnumerable<ColorAccessResponse>> GetAllAsync();
        Task<ColorAccessResponse> GetByIdAsync(string id);
        Task<ColorAccessResponse> UpdateAsync(ColorAccess request);
        Task<ColorAccessResponse> DeleteAsync(string id);
    }
}
