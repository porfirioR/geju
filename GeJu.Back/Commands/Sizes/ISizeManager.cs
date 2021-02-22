using Resources.Contract.Sizes;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Resources.Contract.Sizes
{
    public interface ISizeManager
    {
        Task<SizeResponse> Create(CreateSize request);
        Task<IEnumerable<SizeResponse>> GetAll();
        Task<SizeResponse> GetById(string id);
        Task<SizeResponse> Update(UpdateSize request);
        Task<SizeResponse> Delete(string id);
    }
}
