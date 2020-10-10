using LearningBlazorWASM.Models;

using System.IO;

using Xunit;

namespace LearningBlazor.Tests {
    public class WeatherTest {

        /// <summary>
        /// It's a fact that 0 °C = 32 °F.
        /// </summary>
        [Fact]
        public void GetFahrenheit_FromCelsius_SuccessfulConversion() {
            var weatherForecast = new WeatherForecast {
                CelsiusTemperature = 0
            };
            var fahrenheit = weatherForecast.FahrenheitTemperature;
            Assert.Equal(32, fahrenheit);
        }
    }
}
