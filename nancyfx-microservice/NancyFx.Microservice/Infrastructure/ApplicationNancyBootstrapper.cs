using Autofac;
using Nancy.Bootstrapper;
using Nancy.Bootstrappers.Autofac;
using Nancy.Session;
using NancyFx.Microservice.Modules;

namespace NancyFx.Microservice.Infrastructure
{
    public class ApplicationNancyBootstrapper : AutofacNancyBootstrapper
    {
        protected override void ConfigureApplicationContainer(ILifetimeScope existingContainer)
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<ExternalDependency>().As<IExternalDependency>()
                   .SingleInstance();

            builder.Update(existingContainer.ComponentRegistry);
        }

        protected override void ApplicationStartup(ILifetimeScope container, IPipelines pipelines)
        {
            base.ApplicationStartup(container, pipelines);
            CookieBasedSessions.Enable(pipelines);
        }
    }
}