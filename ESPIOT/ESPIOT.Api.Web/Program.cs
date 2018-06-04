using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace ESPIOTNS.Api.Web
{
    public class Program
    {
         public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .UseIISIntegration();
   
    }
}