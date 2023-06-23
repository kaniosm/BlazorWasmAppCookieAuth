using BlazorWasmAppCookieAuth.Client;
using BlazorWasmAppCookieAuth.Client.Handlers;
using BlazorWasmAppCookieAuth.Client.Providers;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

namespace BlazorWasmAppCookieAuth.Client
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            //builder.RootComponents.Add<App>("#app");
            //builder.RootComponents.Add<HeadOutlet>("head::after");

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
            builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthStateProvider>();
            builder.Services.AddScoped<CookieHandler>();

            builder.Services.AddHttpClient("BlazorWasmAppCookieAuth.ServerAPI", client => client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress))
               .AddHttpMessageHandler<CookieHandler>();

            builder.Services.AddOptions();
            builder.Services.AddAuthorizationCore();


            await builder.Build().RunAsync();
        }
    }
}