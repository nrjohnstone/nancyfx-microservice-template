using System;
using Fclp;

namespace NancyFx.Microservice.Settings
{
    public class ArgumentParser : IArgumentParser
    {
        public CommandLineArgs Parse(string[] args)
        {            
            var p = new FluentCommandLineParser<CommandLineArgs>();

            p.Setup(arg => arg.Port)
                .As('p', "port");

            var result = p.Parse(args);

            if (result.HasErrors)
            {
                throw new ArgumentException(result.ErrorText);
            }
            return p.Object;            
        }
    }

    public interface IArgumentParser
    {
        CommandLineArgs Parse(string[] args);
    }
}