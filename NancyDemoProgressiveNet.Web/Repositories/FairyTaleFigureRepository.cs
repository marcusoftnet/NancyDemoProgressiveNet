using NancyDemoProgressiveNet.Web.Models;
using Simple.Data;

namespace NancyDemoProgressiveNet.Web.Repositories
{
    public interface IFairyTaleFigureRepository
    {
        FairyTaleFigure GetFigureByName(string name);
    }

    // SECRECT IMPLEMENTATION
    public class FairyTaleFigureRepository : IFairyTaleFigureRepository
    {
        public FairyTaleFigure GetFigureByName(string name)
        {
            var db = Database.Open();
            return db.FairyTaleFigure.FindByName(name);
        }
    }
}