using GeJu.DALModels.Brands;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IBrandDAL
    {
        Task<Brand> Create(CreateBrand userDTO);
        Task<Brand> Update(UpdateBrand userDTO);
        Brand GetById(string id);
        IEnumerable<Brand> GetAll();
        Task<bool> Delete(string id);
    }
}
