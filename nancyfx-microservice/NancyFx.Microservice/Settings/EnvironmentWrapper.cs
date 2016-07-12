using System;

namespace NancyFx.Microservice.Settings
{
    class EnvironmentWrapper : IEnvironment
    {
        public string[] GetCommandLineArgs()
        {
            return Environment.GetCommandLineArgs();
        }
    }
}