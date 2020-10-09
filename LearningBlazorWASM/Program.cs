using LearningBlazorWASM.Services;

using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;

using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace LearningBlazorWASM {
    public class Program {
        public static async Task Main(string[] args) {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("app");

            builder.Services.AddSingleton<WeatherForecastService>();
            builder.Services.AddScoped(sp =>
                new HttpClient {
                    BaseAddress = new Uri(builder.HostEnvironment.BaseAddress)
                });

            var host = builder.Build();

            //var forecastService = host.Services.GetRequiredService<WeatherForecastService>();
            //await forecastService.GetRandomForecastAsync(DateTime.Now, 100);

            await host.RunAsync();
        }
    }
}
