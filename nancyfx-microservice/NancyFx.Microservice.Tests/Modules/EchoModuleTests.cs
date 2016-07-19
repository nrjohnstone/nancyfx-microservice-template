using System.Linq;
using System.Threading;
using FluentAssertions;
using Nancy;
using Nancy.Routing;
using Nancy.Routing.Trie;
using NancyFx.Microservice.Modules;
using NancyFx.Microservice.Tests.Extensions;
using Xunit;

namespace NancyFx.Microservice.Tests.Modules
{
    public class EchoModuleTests
    {
        private EchoModule CreateSut()
        {
            return new EchoModule();
        }

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
        public void Example_of_unit_testing_a_route_without_http_requests()
        {
            var sut = CreateSut();
            var route = sut.Routes
                .WithDescription("GET", @"/echo/{Text}").First();
            var expectedResponseText = "SomeTestText";
            DynamicDictionary parameters = new DynamicDictionary()
            {
                { "Text", expectedResponseText }
            };

            // act
            string routeResponse = route.Invoke(parameters, new CancellationToken()).Result;
                        
            // assert
            routeResponse.As<string>().Should().Be(expectedResponseText);
        }

    }
}