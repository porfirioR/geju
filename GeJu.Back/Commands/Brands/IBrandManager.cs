using System.Collections.Generic;
using System.Threading.Tasks;

namespace Contract.Brands
{
    public interface IBrandManager
    {
        Task<Brand> Create(CreateBrand userDTO);
        Task<Brand> Update(UpdateBrand userDTO);
        Brand GetById(string id);
        IEnumerable<Brand> GetAll();
        Task<bool> Delete(string id);
    }
}
