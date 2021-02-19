using Contract.Sizes;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Contract.Users
{
    public interface ISizeManager
    {
        Task<Size> Create(CreateSize sizeDTO);
        Task<Size> UpdateAsync(UpdateSize sizeDTO);
        IEnumerable<Size> GetAll();
        Size GetById(Guid id);
        Task<bool> Delete(Guid id);
    }
}
