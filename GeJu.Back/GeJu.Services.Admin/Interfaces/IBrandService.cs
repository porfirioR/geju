using GeJu.DALModels.Brands;
using GeJu.Sql.Entities;
using System.Linq;
using System.Threading.Tasks;

namespace GeJu.Services.Admin.Interfaces
{
    public interface IBrandService
    {
        Marca GetById(string id);
        IQueryable<Marca> GetAll();
        Task<Marca> CreateAsync(CreateBrand model);
        Task<Marca> UpdateAsync(UpdateBrand model);
        Task<bool> DeleteAsync(string id);
    }
}
