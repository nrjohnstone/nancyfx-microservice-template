using System;
using Microsoft.Owin.Hosting;
using NancyFx.Microservice.Infrastructure;

namespace NancyFx.Microservice
{
    class Program
    {
        static void Main(string[] args)
        {
            var uri = new Uri("http://localhost:5101");
            
            using (WebApp.Start<RestService>(uri.ToString()))
            {
                Console.ReadLine();
            }
        }
    }
}
