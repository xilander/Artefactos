using Extensiones.Models;
using System.Threading.Tasks;

namespace Extensiones.Services
{
    public interface IMailService
    {
        Task SendEmailAsync(MailRequest mailRequest);
    }
}
