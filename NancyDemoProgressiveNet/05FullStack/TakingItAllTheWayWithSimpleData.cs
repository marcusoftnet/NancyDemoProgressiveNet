using Nancy.Testing;
using NancyDemoProgressiveNet.Web;
using NancyDemoProgressiveNet.Web.Models;
using NancyDemoProgressiveNet.Web.Repositories;
using Simple.Data;
using Xunit;

namespace NancyDemoProgressiveNet.FullStack
{
    public class TakingItAllTheWayWithSimpleData
    {
        private static dynamic _db;

        public TakingItAllTheWayWithSimpleData()
        {
            // Configure the simple data InMemoryTest database
            // to have the properties we need to test it
            var adapter = new InMemoryAdapter();
            adapter.SetAutoIncrementKeyColumn("FairyTaleFigure", "ID");
            adapter.Join
                .Master("FairyTaleFigure", "ID")
                .Detail("FairyTaleFigure", "Hangarounds");

            Database.UseMockAdapter(adapter);
            _db = Database.Open();
        }

        [Fact]
        public void full_stack_testing_with_module_in_web_project_with_razor_view()
        {
            // Arrange
            // Store some data to retrieve
            var name = "SnowWhite";
            var snowWhite = TestData.CreateSnowWhite();
            _db.FairyTaleFigure.Insert(snowWhite);

            // Configure the NancyBrowser to use our module
            var browser = new Browser(with =>
            {
                with.Module<FairyTaleModule>();

                // Let's configure Nancy.Testing to use our
                // production repository. 
                // Why not? See if I care. 
                // Simple.Data let's us - and still not hit
                // the database.
                var instance = new FairyTaleFigureRepository();
                with.Dependency<IFairyTaleFigureRepository>(instance);
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
