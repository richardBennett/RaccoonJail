using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using Api;
using Database.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace IntegrationTests.Api
{
    public class TestApiFactory : WebApplicationFactory<Startup>
    {
        public HttpClient BuildClient(List<(Type InterfaceToMatch, object Implementation)> injectedServices)
        {
            var client = WithWebHostBuilder(builder =>
            {
                builder.ConfigureTestServices(services =>
                {
                    foreach (var injectedService in injectedServices)
                    {
                        var descriptor = services.SingleOrDefault(
                            d => d.ServiceType == injectedService.InterfaceToMatch);

                        if (descriptor != null)
                        {
                            services.Remove(descriptor);
                        }

                        services.AddScoped(injectedService.InterfaceToMatch, _ => injectedService.Implementation);
                    }
                });
            }).CreateClient();

            return client;
        }

        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureTestServices(services =>
            {
                var descriptor = services.SingleOrDefault(
                    d => d.ServiceType ==
                         typeof(DbContextOptions<RaccoonJailContext>));

                if (descriptor != null)
                {
                    services.Remove(descriptor);
                }
            });
        }
    }
}