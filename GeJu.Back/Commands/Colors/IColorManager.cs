using System.Collections.Generic;
using System.Threading.Tasks;

namespace Resources.Contract.Colors
{
    public interface IColorManager
    {
        Task<ColorResponse> Create(CreateColor createColor);
        Task<ColorResponse> Update(UpdateColor updateColor);
        Task<ColorResponse> GetById(string id);
        Task<IEnumerable<ColorResponse>> GetAll();
        Task<ColorResponse> Delete(string id);
    }
}
