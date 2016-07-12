﻿using Autofac;
using FluentAssertions;
using Nancy.Testing;
using NancyFx.Microservice.Infrastructure;
using NancyFx.Microservice.Modules;
using NSubstitute;
using Ploeh.AutoFixture;
using Ploeh.AutoFixture.AutoNSubstitute;
using Xunit;

namespace NancyFx.Microservice.Integration.Tests
{
    public class NancyFxExampleIntegrationTests
    {
        private readonly Mocks _mocks;
        private readonly IFixture _fixture;

        private class Mocks
        {
            public IExternalDependency ExternalDependency { get; set; }
        }

        public NancyFxExampleIntegrationTests()
        {
            _fixture = new Fixture().Customize(new AutoNSubstituteCustomization());
            _mocks = _fixture.Create<Mocks>();
        }

        private class TestBootstrapper : ApplicationNancyBootstrapper
        {
            private readonly Mocks _mocks;

            public TestBootstrapper(Mocks mocks)
            {
                _mocks = mocks;
            }

            protected override void ConfigureApplicationContainer(ILifetimeScope existingContainer)
            {
                base.ConfigureApplicationContainer(existingContainer);

                var builder = new ContainerBuilder();

                builder.RegisterInstance(_mocks.ExternalDependency).As<IExternalDependency>();

                builder.Update(existingContainer.ComponentRegistry);                
            }
        }

        [Fact]
        public void Example_of_testing_a_route()
        {
            var bootstrapper = new ApplicationNancyBootstrapper();            
            var browser = new Browser(bootstrapper);
            
            // act
            var result = browser.Get("/echo", with => { with.HttpRequest(); });

            // assert
            result.Body.AsString().Should().Be("EchoResponse");
        }

        [Fact]
        public void Example_of_how_to_inject_mocks_into_application_bootstrapper_by_overriding_bootstrapper_class()
        {
            var bootstrapper = new TestBootstrapper(_mocks);
            var browser = new Browser(bootstrapper);

            _mocks.ExternalDependency.DoStuff().Returns("DoStuffMockCalled");

            // act
            var result = browser.Get("/externalDependency", with => { with.HttpRequest(); });

            // assert
            result.Body.AsString().Should().Be("DoStuffMockCalled");
        }
    }
}