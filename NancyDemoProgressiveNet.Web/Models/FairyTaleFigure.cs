using System.Collections.Generic;

namespace NancyDemoProgressiveNet.Web.Models
{
    public class FairyTaleFigure
    {
        public string Name { get; set; }
        public bool Evil { get; set; }
        public IList<FairyTaleFigure> Hangarounds { get; set; }
    }
}