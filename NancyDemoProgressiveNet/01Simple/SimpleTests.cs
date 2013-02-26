using Nancy;
using Nancy.Testing;
using NancyDemoProgressiveNet.Models;
using NancyDemoProgressiveNet.Web;
using Xunit;

namespace NancyDemoProgressiveNet.Simple
{
    public class SimpleTests
    {
        [Fact]
        public void should_return_http200()
        {
            // Arrange
            var browser = new Browser(new DefaultNancyBootstrapper());

            // Act
            var response = browser.Get("/");

            // Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public void should_return_helloworld_String()
        {
            // Arrange
            var browser = new Browser(new DefaultNancyBootstrapper());

            // Act
            var response = browser.Get("/Hello");

            // Assert
            Assert.Equal("Hello progressive dudes!", response.Body.AsString());
        }

        [Fact]
        public void should_return_json_model()
        {
            // Arrange
            var browser = new Browser(new DefaultNancyBootstrapper());

            // Act
            var response = browser.Get("/Model.json");

            // Assert
            var p = response.Body.DeserializeJson<Person>();
            Assert.Equal(p.Name, "Marcus");
            Assert.Equal(p.Age, 40);
        }
    }
}
