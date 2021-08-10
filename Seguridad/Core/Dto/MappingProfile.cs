using AutoMapper;
using Seguridad.Entities;

namespace Seguridad.Dto
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            CreateMap<Usuario, UsuarioDto>();
        }
    }
}
