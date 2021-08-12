using AutoMapper;
using Seguridad.Entities;

namespace Seguridad.Dto
{
    // Mapeo de las clases Usuario -> UsuarioDTO con la utilería Automapper. No olvidar definir el servicio en Startup
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            CreateMap<Usuario, UsuarioDto>();
        }
    }
}
