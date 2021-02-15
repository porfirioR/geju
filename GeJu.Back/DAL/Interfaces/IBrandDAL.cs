using GeJu.DALModels.Brands;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IBrandDAL
    {
        Task<Brand> CreateAsync(CreateBrand userDTO);
        Task<Brand> UpdateAsync(UpdateBrand userDTO);
        IEnumerable<Brand> GetAll();
        Brand GetById(Guid id);
        Task<bool> DeleteAsync(Guid id);
    }
}
