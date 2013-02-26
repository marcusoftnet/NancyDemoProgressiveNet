using Nancy;
using NancyDemoProgressiveNet.Models;
using NancyDemoProgressiveNet.Web;

namespace NancyDemoProgressiveNet._01Simple
{
    public class SimpleModule : NancyModule
    {
        public SimpleModule()
        {
            Get["/"] = p => { return HttpStatusCode.OK; };
            Get["/Hello"] = p => { return "Hello progressive dudes!"; };
            Get["/Model"] = p => { return new Person { Name = "Marcus", Age = 40 }; };
        }
    }
}
