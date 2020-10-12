using System;
using System.Linq;
using System.Threading.Tasks;

using LearningBlazorWASM.Models;

namespace LearningBlazorWASM.Services {

    public class WeatherForecastService {

        private string[] Summaries => new[] {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        public async Task<WeatherForecast[]> GetRandomForecastsAsync(DateTime startDate, int amount) {
            var random = new Random();
            var forecasts = Enumerable.Range(1, amount)
                .Select(index =>
                    new WeatherForecast {
                        Date = startDate.AddDays(index),
                        CelsiusTemperature = random.Next(-20, 55),
                        Summary = Summaries[random.Next(Summaries.Length)]
                    });
            return await Task.Run(forecasts.ToArray);
        }
    }
}