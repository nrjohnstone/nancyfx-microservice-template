using FluentAssertions;
using NancyFx.Microservice.Settings;
using NSubstitute;
using Ploeh.AutoFixture;
using Ploeh.AutoFixture.AutoNSubstitute;
using Xunit;

namespace NancyFx.Microservice.Tests.Settings
{
    public class WebAppSettingsTests
    {
        private readonly IFixture _fixture;
        private readonly Mocks _mocks;

        private class Mocks
        {
            public IArgumentParser ArgumentParser { get; set; }
            public IEnvironment Environment { get; set; }
        }

        public WebAppSettingsTests()
        {
            _fixture = new Fixture().Customize(new AutoNSubstituteCustomization());
            _mocks = _fixture.Create<Mocks>();
        }

        private WebAppSettings CreateSut()
        {
            return new WebAppSettings(_mocks.ArgumentParser, _mocks.Environment);
        }
        
        [Fact]
        public void When_no_commandline_argument_is_given_for_port_should_return_default()
        {
            var sut = CreateSut();
            _mocks.ArgumentParser.Parse(Arg.Any<string[]>()).Returns(new CommandLineArgs());

            // act
            int settingsValueForPort = sut.Port;

            // assert
            settingsValueForPort.Should().Be(WebAppSettings.DEFAULT_PORT);
        }

        [Fact]
        public void When_commandline_argument_is_given_for_port_should_return_default()
        {
            var sut = CreateSut();
            var commandLineArgs = new CommandLineArgs() { Port = 1000};
            _mocks.ArgumentParser.Parse(Arg.Any<string[]>()).Returns(commandLineArgs);

            // act
            int settingsValueForPort = sut.Port;

            // assert
            settingsValueForPort.Should().Be(commandLineArgs.Port);
        }

        [Fact]
        public void CommandLineArguments_should_come_from_Environment_dependency()
        {
            var sut = CreateSut();
            string[] expectedCommandLineArgs = new string[] {"-p", "10"};
            int commandLinePort = 1000;
            _mocks.Environment.GetCommandLineArgs().Returns(expectedCommandLineArgs);
            _mocks.ArgumentParser.Parse(Arg.Any<string[]>()).Returns(new CommandLineArgs() { Port = commandLinePort });

            // act
            int settingsValueForPort = sut.Port;

            // assert            
            _mocks.ArgumentParser.Received(1).Parse(expectedCommandLineArgs);
        }
    }
}