using System;
using Microsoft.Owin.Hosting;
using NancyFx.Microservice.Infrastructure;
using NancyFx.Microservice.Settings;

namespace NancyFx.Microservice
{
    class Program
    {
        static void Main(string[] args)
        {
            var settings = new WebAppSettings(new ArgumentParser(), new EnvironmentWrapper());
            var uri = new Uri($"http://localhost:{settings.Port}");
            
            using (WebApp.Start<RestService>(uri.ToString()))
            {
                Console.ReadLine();
            }
        }
    }
}
