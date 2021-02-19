using Contract.Sizes;
using GeJu.Sql.Entities;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Admin.Interfaces
{
    public interface ISizeService
    {
        Tamaño GetById(Guid id);
        IQueryable<Tamaño> GetAll();
        Task<Tamaño> CreateAsync(CreateSize model);
        Task<Tamaño> UpdateAsync(UpdateSize model);
        Task<bool> DeleteAsync(Guid id);
    }
}
