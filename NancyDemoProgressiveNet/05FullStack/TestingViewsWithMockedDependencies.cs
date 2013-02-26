using Nancy.Testing;
using NancyDemoProgressiveNet.Web;
using NancyDemoProgressiveNet.Web.Repositories;
using NSubstitute;
using Xunit;

namespace NancyDemoProgressiveNet.FullStack
{
    public class TestingViewsWithMockedDependencies
    {
        
        [Fact]
        public void full_stack_testing_with_module_in_web_project_with_razor_view()
        {
            // Arrange
            // Store some data to retrieve
            var name = "SnowWhite";
            var snowWhite = TestData.CreateSnowWhite();
            var mockRepo = Substitute.For<IFairyTaleFigureRepository>();
            mockRepo.GetFigureByName(name).Returns(snowWhite);

            // Configure the NancyBrowser to use our module
            var browser = new Browser(with =>
            {
                with.Module<FairyTaleModule>();
                with.Dependency<IFairyTaleFigureRepository>(mockRepo);
            });

            // Act
            var path = string.Format("/figure/{0}/View/", name);
            var response = browser.Get(path);

            // Assert
            response.Body[".fairyTaleFigure"]
                .ShouldExistOnce()
                .And.ShouldContain(name);

            response.Body[".hangaround"]
                .ShouldExistExactly(7);
        }
    }

}
