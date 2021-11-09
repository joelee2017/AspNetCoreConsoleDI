using AspNetCoreConsoleDI.Interface;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;

namespace AspNetCoreConsoleDI
{
    public class EntryPoint
    {
        private readonly IQuadraticService _quadraticService;
        private readonly IConfiguration _configuration;
        private readonly ILogger<EntryPoint> _logger;


        public EntryPoint(IQuadraticService quadraticService, IConfiguration configuration, ILogger<EntryPoint> logger)
        {
            this._quadraticService = quadraticService;
            this._configuration = configuration;
            this._logger = logger;
        }
        public void Run(String[] args)
        {
            //var a = Double.Parse(args[0]);
            //var b = Double.Parse(args[1]);
            //var c = Double.Parse(args[2]);

            var a = Double.Parse(this._configuration["PolynomialCoefficients:A"]);
            var b = Double.Parse(this._configuration["PolynomialCoefficients:B"]);
            var c = Double.Parse(this._configuration["PolynomialCoefficients:C"]);

            this._logger.LogDebug("來段log 吧!!");

            var quadraticRoots = this._quadraticService.CalculateRoots(a, b, c);

            Console.WriteLine($"Polynomial: {a}x^2 + {b}x + {c}");
            if (quadraticRoots == null)
            {
                Console.WriteLine("The roots are not reals");
            }
            else if (quadraticRoots.FirstRoot == quadraticRoots.SecondRoot)
            {
                Console.WriteLine($"The double root is {quadraticRoots.FirstRoot}");
            }
            else
            {
                Console.WriteLine($"The roots are: {quadraticRoots.FirstRoot} and {quadraticRoots.SecondRoot}");
            }
        }
    }
}
