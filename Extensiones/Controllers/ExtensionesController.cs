using Extensiones.Clases;
using Extensiones.Models;
using Extensiones.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Extensiones.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ExtensionesController : ControllerBase
    {
        private readonly IMailService mailService;
        public ExtensionesController(IMailService mailService)
        {
            this.mailService = mailService;
        }

        [HttpPost("send")]
        public async Task<IActionResult> SendMail([FromForm] MailRequest request)
        {
            try
            {
                await mailService.SendEmailAsync(request);
                return Ok();
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost("cifrar")]
        public IActionResult CifrarCadena(string cadena, string clave = "dr3nkEPjF0aTKX4z2L21qQ%3d%3d")
        {
            string cadenaCifrada = Cifrado.Cifrar(cadena, clave);

            return Ok(cadenaCifrada);
        }

        [HttpPost("descifrar")]
        public IActionResult DescifrarCadena(string cifrado, string clave = "dr3nkEPjF0aTKX4z2L21qQ%3d%3d")
        {
            string cadenaDescifrada = Cifrado.Descifrar(cifrado, clave);

            if (cadenaDescifrada == "La firma es erronea")
            {
                return StatusCode(401, cadenaDescifrada);
            }else
            {
                return Ok(cadenaDescifrada);
            }

            
        }
    }
}
