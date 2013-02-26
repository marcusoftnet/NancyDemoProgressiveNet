using System.Collections.Generic;
using Nancy;
using Nancy.Testing;
using NancyDemoProgressiveNet._03Request;
using Xunit;

namespace NancyDemoProgressiveNet.Request
{
    public class JSonPostingTests
    {

        private const string _json = "[{ 'key1': 'value1' , 'key2': 'value2'},{ 'key1': 'value1' , 'key2': 'value2'}, { 'key1': 'value1' , 'key2': 'value2'}]";

        [Fact]
        public void should_be_able_to_post_a_raw_body()
        {
            // Given
            var browser = new Browser(with => with.Module<JsonModelBindingModule>());

            // When
            var result = browser.Post("/jsonlist", with =>
            {
                with.Body(_json);
                with.Header("content-type", "application/json");
            });

            // Then
            Assert.Equal(HttpStatusCode.OK, result.StatusCode);
        }
        
        [Fact]
        public void should_be_able_to_serialize_model_to_JSON_directly()
        {
            // Given
            var browser = new Browser(with => with.Module<JsonModelBindingModule>());
            IEnumerable<MyModel> model = new[]
                    {
                        new MyModel { key1 = "value 1", key2 = "value 2" },
                        new MyModel { key1 = "value 3", key2 = "value 4" },
                        new MyModel { key1 = "value 5", key2 = "value 6" },
                        new MyModel { key1 = "value 7", key2 = "value 8" }
                    };

            // When
            var result = browser.Post("/jsonlist", with => with.JsonBody(model));

            // Then
            Assert.Equal(HttpStatusCode.InternalServerError, result.StatusCode);
        }

        
    }
}
