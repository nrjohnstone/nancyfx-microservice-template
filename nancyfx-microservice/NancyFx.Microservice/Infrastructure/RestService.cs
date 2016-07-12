using Owin;

namespace NancyFx.Microservice.Infrastructure
{
    public class RestService
    {
        public void Configuration(IAppBuilder appBuilder)
        {
            appBuilder.UseNancy();
        }
    }
}