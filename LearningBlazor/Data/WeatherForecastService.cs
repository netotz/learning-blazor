using System;
using System.Linq;
using System.Threading.Tasks;

using LearningBlazor.Models;

namespace LearningBlazor.Data {

    public class WeatherForecastService {

        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        public int Status { get; set; } = 0;

        public Task<WeatherForecast[]> GetForecastAsync(DateTime startDate) {
            var random = new Random();
            return Task.FromResult(Enumerable.Range(1, 5).Select(
                index => new WeatherForecast {
                    Date = startDate.AddDays(index),
                    TemperatureC = random.Next(-20, 55),
                    Summary = Summaries[random.Next(Summaries.Length)]
                }).ToArray());
        }
    }
}