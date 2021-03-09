using JwelleryStoreServices;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace JwelleryStore.UnitTest
{
    public class TestHost
    {
        public HttpClient Client { get; }
        public IServiceProvider ServiceProvider { get; }

        public IWebHost _WebHost { get; }

        public TestHost()
        {
            var builder = Program.CreateHostBuilder(null)
                .ConfigureWebHost(webHost =>
                {
                    webHost.UseTestServer();
                    webHost.UseEnvironment("Test");
                });

            var webHost = WebHost.CreateDefaultBuilder()
                .UseStartup<Startup>()
                .Build();

            var host = builder.Start();
            ServiceProvider = host.Services;
            Client = host.GetTestClient();
            _WebHost = webHost;
           
        }

        public IWebHost GetWebHost()
        {
            var webHost = WebHost.CreateDefaultBuilder()
                          .UseStartup<Startup>()
                          .Build();
            return webHost;

        }


        public void Dispose()
        {
            Client.Dispose();
        }
    }
}
