using CadastroCliente.WebApi;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Net.Http;

namespace CadastroCliente.Test
{
    public class TestContext : DbContext
    {
        public HttpClient Client { get; set; }
        private TestServer _server;
        public TestContext()
        {
            SetupClient();
        }       
        private void SetupClient()
        {
            _server = new TestServer(new WebHostBuilder()
                .ConfigureAppConfiguration((hostingContext, config) =>
                {
                    config
                    .AddJsonFile("appsettings.json", optional: true);
                    config.AddEnvironmentVariables();
                })
                .UseStartup<Startup>());
            Client = _server.CreateClient();
        }
    }
}
