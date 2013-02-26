using NancyDemoProgressiveNet.Web.Models;

namespace NancyDemoProgressiveNet.FullStack
{
    public class TestData
    {
        public static FairyTaleFigure CreateSnowWhite()
        {
            return new FairyTaleFigure
            {
                Evil = false,
                Name = "SnowWhite",
                Hangarounds = new[]
                                        {
                                            new FairyTaleFigure{Name = "Sleepy", Evil = false},
                                            new FairyTaleFigure{Name = "Doc", Evil = false},
                                            new FairyTaleFigure{Name = "Bashful", Evil = false},
                                            new FairyTaleFigure{Name = "Dopey", Evil = false},
                                            new FairyTaleFigure{Name = "Grumpy", Evil = true},
                                            new FairyTaleFigure{Name = "Happy", Evil = false},
                                            new FairyTaleFigure{Name = "Sneezy", Evil = false},
                                        }
            };
        }
    }
}
