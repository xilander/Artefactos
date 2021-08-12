using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Seguridad.Persistence
{
    // 
    public class SeguridadContexto: IdentityDbContext<Entities.Usuario>
    {
        public SeguridadContexto(DbContextOptions options): base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
