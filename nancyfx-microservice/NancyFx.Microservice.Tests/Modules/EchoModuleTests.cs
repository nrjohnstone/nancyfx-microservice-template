using System.Linq;
using System.Threading;
using FluentAssertions;
using NancyFx.Microservice.Modules;
using Xunit;

namespace NancyFx.Microservice.Tests.Modules
{
    public class EchoModuleTests
    {
        [Fact]
        public void Should_reply_with_parameter_as_string()
        {
            var sut = CreateSut();
            string expectedEchoResponse = "SomeRandomText";
            
            // act           
            var response = sut.GetEchoWithParameter(expectedEchoResponse);

            // assert
            response.ToString().Should().Be(expectedEchoResponse);
        }

        [Fact]
        public void Should()
        {
            var sut = CreateSut();
            

            // act
            var route = sut.Routes.Where(x => x.Description.Equals("GET")).FirstOrDefault();

            // assert
        }
        private EchoModule CreateSut()
        {
            return new EchoModule();
        }
    }
}