using Seguridad.Entities;

namespace Seguridad.Core.JwtLogic
{
    public interface IJwtGenerator
    {
        string CreateToken(Usuario usuario);
    }
}
