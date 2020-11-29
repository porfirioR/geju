using GeJu.AccessServicesModel.Brands;
using GeJu.Sql.Entities;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace GeJu.Services.Admin.Interfaces
{
    public interface IBrandsServices
    {
        Marca GetById(Guid id);
        IQueryable<Marca> GetAll();
        Task<Marca> CreateAsync(CreateBrand model);
        Task<Marca> UpdateAsync(UpdateBrand model);
        Task<bool> DeleteAsync(Guid id);
    }
}
