using Nancy.Testing;
using NancyDemoProgressiveNet._03Request;
using Xunit;

namespace NancyDemoProgressiveNet.Request
{
    public class FormPostingTests
    {
        [Fact]
        public void should_be_able_to_post_a_form()
        {
            // Arrange
            var browser = new Browser(with => with.Module<FormTestModule>());

            // Act
            var response = browser.Post("/areYouOld", with =>
            {
                with.HttpRequest();
                with.FormValue("Name", "Marcus");
                with.FormValue("Age", "40");
            });

            // Assert
            Assert.Equal("Wow, you're an old guy, Marcus!", response.Body.AsString());
        }
    }
}
