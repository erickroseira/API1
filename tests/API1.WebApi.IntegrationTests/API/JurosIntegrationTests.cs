using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.AspNetCore.TestHost;
using Microsoft.AspNetCore.Hosting;
using NUnit.Framework;
using Serilog;

namespace API1.WebApi.IntegrationTests.API
{
    public class JurosIntegrationTests
    {
        private readonly HttpClient _httpClient;

        public JurosIntegrationTests()
        {
            var server = new TestServer(new WebHostBuilder()
                .UseEnvironment("Development")
                .UseSerilog((hostingContext, loggerConfig) =>
                    loggerConfig.ReadFrom.Configuration(hostingContext.Configuration)
                )
                .UseStartup<Startup>());

            _httpClient = server.CreateClient();
        }

        [Test]
        public async Task GetTaxaDeJuros_Deve_Successful()
        {
            //Arrange
            var request = new HttpRequestMessage(new HttpMethod("GET"), "/api/juros/taxaJuros" );

            //Act
            var response = await _httpClient.SendAsync(request);

            //Assert
            response.EnsureSuccessStatusCode();
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }
    }
}
