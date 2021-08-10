using Microsoft.AspNetCore.Identity;
using Seguridad.Entities;
using System.Linq;
using System.Threading.Tasks;

namespace Seguridad.Persistence
{
    public class SeguridadData
    {
        public static async Task InsertarUsuario(SeguridadContexto context, UserManager<Usuario> usuarioManger)
        {
            if (!usuarioManger.Users.Any())
            {
                var usuario = new Usuario
                {
                    Nombre = "Administrador",
                    CondominioId = 0,
                    ViviendaId = 0,
                    Email = "xilander@cosmox.mx",
                    UserName = "admin"
                };

                await usuarioManger.CreateAsync(usuario, "Password123$");
            }
        }
    }
}
