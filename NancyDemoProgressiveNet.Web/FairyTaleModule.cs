using Nancy;
using NancyDemoProgressiveNet.Web.Repositories;

namespace NancyDemoProgressiveNet.Web
{
    public class FairyTaleModule : NancyModule
    {
        private readonly IFairyTaleFigureRepository _repository;

        public FairyTaleModule(IFairyTaleFigureRepository repository)
        {
            _repository = repository;

            Get["/figure/{name}/View"] = p =>
            {
                return View["FairyTaleFigure",
                    _repository.GetFigureByName(p.Name)];
            };
        }
















        // Fix to not crash my tests
        public FairyTaleModule()
        {
            _repository = null;
        }
    }
}