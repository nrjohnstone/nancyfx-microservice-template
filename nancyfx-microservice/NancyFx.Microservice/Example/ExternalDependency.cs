using NancyFx.Microservice.Modules;

namespace NancyFx.Microservice.Example
{
    class ExternalDependency : IExternalDependency
    {
        public string DoStuff()
        {
            return "ExternalDependencyDoStuff";
        }
    }
}