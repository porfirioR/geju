using GeJu.Sql.Entities;

namespace Admin.Interfaces
{
    public interface ITokenService
    {
        string CreateToken(Usuario usuario);
    }
}
