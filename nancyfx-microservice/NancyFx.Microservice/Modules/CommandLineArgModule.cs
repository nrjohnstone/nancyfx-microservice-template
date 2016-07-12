using Nancy;
using NancyFx.Microservice.Example;
using NancyFx.Microservice.Settings;

namespace NancyFx.Microservice.Modules
{
    public class CommandLineArgModule : NancyModule
    {
        private readonly IWebAppSettings _settings;

        public CommandLineArgModule(IWebAppSettings settings)
        {
            _settings = settings;
            Get["/settings/port"] = _ => GetSettingsPort();
        }

        private string GetSettingsPort()
        {
            return _settings.Port.ToString();
        }
    }
}