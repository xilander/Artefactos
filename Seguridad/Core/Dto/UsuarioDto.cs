using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Seguridad.Dto
{
    public class UsuarioDto
    {
        public string Id { get; set; }
        public string Nombre { get; set; }
        public int CondominioId { get; set; }
        public int ViviendaId { get; set; }
        public string Conjunto { get; set; }
        public string Token { get; set; }
    }
}
