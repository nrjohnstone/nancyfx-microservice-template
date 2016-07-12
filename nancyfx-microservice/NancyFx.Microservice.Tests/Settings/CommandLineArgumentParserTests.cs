using System;
using FluentAssertions;
using NancyFx.Microservice.Settings;
using Xunit;

namespace NancyFx.Microservice.Tests.Settings
{
    public class CommandLineArgumentParserTests
    {
        private ArgumentParser CreateSut()
        {
            return new ArgumentParser();
        }

        [Fact]
        public void When_commandline_argument_for_port_is_supplied_should_parse_value()
        {
            var sut = CreateSut();
            string[] args = new[] {"-p", "8080"};

            // act
            CommandLineArgs parsedArgs = sut.Parse(args);

            // assert
            parsedArgs.Port.Should().Be(8080);
        }

        [Fact]
        public void When_long_form_of_port_is_supplied_should_parse_value()
        {
            var sut = CreateSut();
            string[] args = new[] { "--port", "8080" };

            // act
            CommandLineArgs parsedArgs = sut.Parse(args);

            // assert
            parsedArgs.Port.Should().Be(8080);
        }

        [Fact]
        public void When_commandline_argument_for_port_is_not_valid_number_should_throw_ArgumentException()
        {
            var sut = CreateSut();
            string[] args = new[] { "--port", "NAN" };

            // act
            Action parseArgsWithNonNumericPort = () => sut.Parse(args);

            // assert
            parseArgsWithNonNumericPort.ShouldThrow<ArgumentException>();
        }
    }
}