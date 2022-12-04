using Microsoft.AspNetCore.Mvc.Testing;

namespace LabsAndCoursesManagement.API.IntegrationTests.Setup
{
    public class BaseIntegrationTests:
        IClassFixture<CustomWebApplicationFactory<Program>>
    {
        public HttpClient HttpClient { get; private set; }
        public BaseIntegrationTests(CustomWebApplicationFactory<Program> factory)
        {
            HttpClient = factory.CreateClient(new WebApplicationFactoryClientOptions
            {
                AllowAutoRedirect = true
            });
        }
    }
}
