using System.Collections.Generic;
using System.Threading.Tasks;

namespace Resources.Contract.Brands
{
    public interface IBrandManager
    {
        Task<BrandResponse> Create(CreateBrand userDTO);
        Task<BrandResponse> Update(UpdateBrand userDTO);
        Task<BrandResponse> GetById(string id);
        Task<IEnumerable<BrandResponse>> GetAll();
        Task<BrandResponse> Delete(string id);
    }
}
