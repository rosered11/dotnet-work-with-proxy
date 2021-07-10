using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using System;
using System.IO;

namespace Client.With.Proxy.Demo
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var port = Environment.GetEnvironmentVariable("PORT");
            var configuration =
            new ConfigurationBuilder()
                .AddEnvironmentVariables("MY_ASPNETCORE_")
                .AddCommandLine(args)
                .Build();

            var host =
                new WebHostBuilder()
                    .UseConfiguration(configuration)
                    .UseKestrel()
                    .UseContentRoot(Directory.GetCurrentDirectory())
                    .UseIISIntegration()
                    .UseStartup<Startup>()
                    .UseUrls($"http://*:{port}")
                    .Build();
            host.Run();
        }
    }
}
