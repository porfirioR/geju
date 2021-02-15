using GeJu.Sql.Entities;

namespace GeJu.Services.Admin.Interfaces
{
    public interface ITokenService
    {
        string CreateToken(Usuario usuario);
    }
}
