using System.Collections.Generic;
using Nancy;

namespace NancyDemoProgressiveNet._02ConfigurableBootstrapper
{
    public class ConfigModule : NancyModule
    {
        public ConfigModule()
        {
            Get["/"] = p => { return "It worked!"; };
        }
    }

    public class DependencyModule : NancyModule
    {
        public DependencyModule(IRepository repository)
        {
            Get["/"] = p =>
            {
                var allUsernames = string.Join(", ", repository.GetAllUsernames());
                return allUsernames;
            };
        }
    }

    public interface IRepository
    {
        IEnumerable<string> GetAllUsernames();
    }
}
