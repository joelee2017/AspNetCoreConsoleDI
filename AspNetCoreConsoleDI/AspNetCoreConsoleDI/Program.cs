using Microsoft.Extensions.DependencyInjection;
using System;

namespace AspNetCoreConsoleDI
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var services = Startup.ConfigureServices();
            var serviceProvider = services.BuildServiceProvider();

            //serviceProvider.GetService<EntryPoint>().Run(new string[] { "1" , "2", "1" });
            serviceProvider.GetService<EntryPoint>().Run(args);

            Console.ReadLine();
        }
    }
}
