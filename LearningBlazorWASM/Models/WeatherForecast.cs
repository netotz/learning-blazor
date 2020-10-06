using System;

namespace LearningBlazorWASM.Models {
    public class WeatherForecast {

        public DateTime Date { get; set; }

        public string Summary { get; set; }

        public int CelsiusTemperature { get; set; }

        public int FahrenheitTemperature =>  (int)(CelsiusTemperature * (9.0 / 5.0)) + 32;
    }
}
