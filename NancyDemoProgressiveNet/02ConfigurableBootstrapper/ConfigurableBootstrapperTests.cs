using System.Collections.Generic;
using Nancy.Testing;
using NancyDemoProgressiveNet._02ConfigurableBootstrapper;
using Xunit;

namespace NancyDemoProgressiveNet.ConfigurableBootstrapper
{
    public class ConfigurableBootstrapperTests
    {
        [Fact]
        public void should_be_to_test_a_single_module()
        {
            // Arrange
            var browser = new Browser(with => with.Module<ConfigModule>());

            // Act
            var response = browser.Get("/");

            // Assert
            Assert.Equal("It worked!", response.Body.AsString());
        }

        [Fact]
        public void should_be_able_to_set_depenceny()
        {
            // Arrange
            var browser = new Browser(with =>
                    {
                        with.Module<DependencyModule>();
                        with.Dependency<IRepository>(typeof (MockRepository));
                    });

            // Act
            var response = browser.Get("/");

            // Assert
            Assert.Equal("Marcus, Calle, Agnes", response.Body.AsString());
        }

        public class MockRepository : IRepository
        {
            public IEnumerable<string> GetAllUsernames()
            {
                return new[] {"Marcus", "Calle", "Agnes"};
            }
        }
    }
}