namespace NancyFx.Microservice.Modules
{
    class ExternalDependency : IExternalDependency
    {
        public string DoStuff()
        {
            return "ExternalDependencyDoStuff";
        }
    }
}