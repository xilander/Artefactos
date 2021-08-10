using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Seguridad
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
            //var hostserver = CreateHostBuilder(args).Build();
            //using (var contexto = hostserver.Services.CreateScope())
            //{
            //    var services = contexto.ServiceProvider;
            //    try
            //    {
            //        var userManager = services.GetRequiredService<UserManager<Usuario>>();
            //        var contextoEF = services.GetRequiredService<SeguridadContexto>();

            //        SeguridadData.InsertarUsuario(contextoEF, userManager).Wait();
            //    }
            //    catch (Exception e)
            //    {

            //        var logging = services.GetRequiredService<ILogger<Program>>();
            //        logging.LogError(e, "Error al registrar usuario");
            //    }
            //}

            //hostserver.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
