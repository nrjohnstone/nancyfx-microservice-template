using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Nancy.Routing;

namespace NancyFx.Microservice.Tests.Extensions
{
    public static class RouteExtensions
    {
        public static IEnumerable<Route> WithDescription(this IEnumerable<Route> instance, string method, string path)
        {
            var routes = instance.Where(
                 x => x.Description.Method.Equals(method) &&
                 x.Description.Path.Equals(path));
            return routes;
        }    
    }
}