using System.Collections.Generic;
using Nancy;
using Nancy.ModelBinding;

namespace NancyDemoProgressiveNet._03Request
{
    public class JsonModelBindingModule : NancyModule
    {
        public JsonModelBindingModule()
        {
            Post["/jsonlist"] = _ =>
            {
                var model = this.Bind<List<MyModel>>();

                return (model.Count == 3) ?
                    HttpStatusCode.OK :
                    HttpStatusCode.InternalServerError;
            };
        }
    }

    public class MyModel
    {
        public string key1 { get; set; }
        public string key2 { get; set; }
    }
}
