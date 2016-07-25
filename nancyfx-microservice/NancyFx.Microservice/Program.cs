using System;
using Microsoft.Owin.Hosting;
using NancyFx.Microservice.Infrastructure;
using NancyFx.Microservice.Infrastructure.Logging;
using NancyFx.Microservice.Settings;
using Serilog;

namespace NancyFx.Microservice
{
    class Program
    {
        private static AmbientSerilogService Logger { get; } = new AmbientSerilogService();

        static void Main(string[] args)
        {
            AmbientSerilogService.Create = () =>
            {
                Log.Logger = new LoggerConfiguration()
                    .ReadFrom.AppSettings()
                    .Enrich.With(new ApplicationDetailsEnricher())
                    .CreateLogger();

                return Log.Logger;
            };

            var settings = new WebAppSettings(new ArgumentParser(), new EnvironmentWrapper());
            var uri = new Uri($"http://localhost:{settings.Port}");
            Logger.Debug("Webservice started");
            using (WebApp.Start<RestService>(uri.ToString()))
            {
                Logger.Verbose("Application started");
                Console.ReadLine();
            }
        }
    }
}
