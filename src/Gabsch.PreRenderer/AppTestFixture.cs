using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Net.Http;

namespace Gabsch.PreRenderer
{
    public class AppTestFixture : WebApplicationFactory<AsthetikPersonal.Server.Program>
    {
        protected override IHostBuilder CreateHostBuilder()
        {
            var builder = base.CreateHostBuilder();
            builder.UseEnvironment(Environments.Production);

            builder.ConfigureWebHost(
                webHostBuilder =>
                {
                    webHostBuilder.UseStaticWebAssets();
                    webHostBuilder.ConfigureTestServices(services =>
                    {
                        services.Remove(new ServiceDescriptor(typeof(HttpClient), typeof(HttpClient), ServiceLifetime.Singleton));
                        services.AddSingleton(_ => CreateDefaultClient());
                    });
                });

            return builder;
        }
    }
}
