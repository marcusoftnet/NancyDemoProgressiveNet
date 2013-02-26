﻿using Nancy;
using Nancy.Responses;
using Nancy.Testing;
using Xunit;

namespace NancyDemoProgressiveNet.Response
{
    public class AA_RedirectionTests
    {
        [Fact]
        public void should_test_have_redirected()
        {
            // Arrange
            var browser = new Browser(with => with.Module<RedirectModule>());

            // Act
            var response = browser.Get("/redirectMe");

            // Assert
            response.ShouldHaveRedirectedTo("/redirection");
        }

        public class RedirectModule : NancyModule
        {
            public RedirectModule()
            {
                Get["/redirectMe"] = p => { return new RedirectResponse("/redirection"); };
            }
        }
    }
}
