using GeJu.Common.DTO.Brands;

namespace DAL.Interfaces
{
    public interface IBrandDAL
    {
        Task<BrandApi> CreateAsync(CreateBrandDTO userDTO);
        Task<BrandApi> UpdateAsync(UpdateBrandDTO userDTO);
        IEnumerable<BrandApi> GetAll();
        BrandApi GetById(Guid id);
        Task<bool> DeleteAsync(Guid id);
    }
}
