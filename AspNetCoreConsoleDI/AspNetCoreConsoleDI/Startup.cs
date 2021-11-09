using AspNetCoreConsoleDI.Interface;
using AspNetCoreConsoleDI.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System.IO;

namespace AspNetCoreConsoleDI
{
    public static class Startup
    {
        public static IServiceCollection ConfigureServices()
        {
            var services = new ServiceCollection();

            var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile(@"Configuraction\appsettings.json", optional: true, reloadOnChange: false)
            .AddJsonFile(@"Configuraction\logging.json", optional: true, reloadOnChange: false);
            IConfiguration configuration = builder.Build();
            services.AddSingleton(configuration);

            services.AddLogging(builder =>
            {
                builder.AddConfiguration(configuration.GetSection("Logging"));
                builder.AddConsole();
            });

            services.AddSingleton<IQuadraticService, QuadraticService>();
            services.AddTransient<EntryPoint>();

            return services;
        }
    }
}
