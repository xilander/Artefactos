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
    }
}
