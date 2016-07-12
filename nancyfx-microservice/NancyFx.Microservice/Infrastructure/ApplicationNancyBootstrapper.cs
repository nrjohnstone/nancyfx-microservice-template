using Autofac;
using Nancy.Bootstrapper;
using Nancy.Bootstrappers.Autofac;
using Nancy.Session;
using NancyFx.Microservice.Example;
using NancyFx.Microservice.Modules;
using NancyFx.Microservice.Settings;

namespace NancyFx.Microservice.Infrastructure
{
    public class ApplicationNancyBootstrapper : AutofacNancyBootstrapper
    {
        protected override void ConfigureApplicationContainer(ILifetimeScope existingContainer)
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<ExternalDependency>().As<IExternalDependency>()
                   .SingleInstance();

            builder.RegisterType<WebAppSettings>().As<IWebAppSettings>();
            builder.RegisterType<ArgumentParser>().As<IArgumentParser>();
            builder.RegisterType<EnvironmentWrapper>().As<IEnvironment>();

            builder.Update(existingContainer.ComponentRegistry);
        }

        protected override void ApplicationStartup(ILifetimeScope container, IPipelines pipelines)
        {
            base.ApplicationStartup(container, pipelines);
            CookieBasedSessions.Enable(pipelines);
        }
    }
}