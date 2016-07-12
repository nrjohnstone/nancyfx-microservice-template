using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NancyFx.Microservice.Settings
{
    public class WebAppSettings : IWebAppSettings
    {
        private readonly IArgumentParser _argumentParser;
        private readonly IEnvironment _environment;

        private CommandLineArgs _commandLineArguments => _lazyCommandLineArguments.Value;
        private readonly Lazy<CommandLineArgs> _lazyCommandLineArguments;

        public const int DEFAULT_PORT = 5101;

        public WebAppSettings(IArgumentParser argumentParser, IEnvironment environment)
        {
            _argumentParser = argumentParser;
            _environment = environment;
            _lazyCommandLineArguments = new Lazy<CommandLineArgs>(() =>  
            {
                string[] args = _environment.GetCommandLineArgs();
                return _argumentParser.Parse(args);
            });
        }

        public int Port
        {
            get
            {   
                if (_commandLineArguments.Port == 0)
                    return DEFAULT_PORT;
                return _commandLineArguments.Port;
            }
        }
    }
}
