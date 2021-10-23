using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Zcreenshot.Api.Rabbitmq;

namespace Zcreenshot.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var x = new RabbitmqConnection();
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder => { webBuilder.UseStartup<Startup>(); });
    }
}