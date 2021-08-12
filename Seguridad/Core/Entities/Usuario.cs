using Microsoft.AspNetCore.Identity;

namespace Seguridad.Entities
{
    // Campos adicionales a los generados por el Identity   
    public class Usuario: IdentityUser
    {
        public string Nombre { get; set; }
        public int CondominioId { get; set; }
        public int ViviendaId { get; set; }
        public string Conjunto { get; set; }
    }
}
