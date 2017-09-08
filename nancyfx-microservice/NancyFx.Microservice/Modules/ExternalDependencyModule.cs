using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nancy;
using NancyFx.Microservice.Example;

namespace NancyFx.Microservice.Modules
{
    public class ExternalDependencyModule : NancyModule
    {
        private readonly IExternalDependency _externalDependency;

        public ExternalDependencyModule(IExternalDependency externalDependency)
        {
            _externalDependency = externalDependency;
            Get["/externalDependency"] = _ => GetExternalDependency();
        }

        public string GetExternalDependency()
        {
            return _externalDependency.DoStuff();
        }
    }
}
