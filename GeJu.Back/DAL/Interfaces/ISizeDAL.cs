using GeJu.Common.DTO.Size;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface ISizeDAL
    {
        Task<SizeApi> CreateAsync(CreateSizeDTO sizeDTO);
        Task<SizeApi> UpdateAsync(UpdateSizeDTO sizeDTO);
        IEnumerable<SizeApi> GetAll();
        SizeApi GetById(Guid id);
        Task<bool> DeleteAsync(Guid id);
    }
}
