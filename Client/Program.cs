using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace HostedBlazor.Client
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");

            builder.Services.AddHttpClient("CleanBudgetServerClient",
                    client => client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress))
                .AddHttpMessageHandler<BaseAddressAuthorizationMessageHandler>();
            builder.Services.AddScoped(sp =>
                sp.GetRequiredService<IHttpClientFactory>().CreateClient("CleanBudgetServerClient"));

            builder.Services.AddApiAuthorization();

            await builder.Build().RunAsync();
        }
    }
}