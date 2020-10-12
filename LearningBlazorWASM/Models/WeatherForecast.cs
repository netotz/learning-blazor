using System;
using System.ComponentModel.DataAnnotations;

namespace LearningBlazorWASM.Models {

    public class WeatherForecast {

        [Required]
        public DateTime Date { get; set; }

        public string Summary { get; set; }

        [Required]
        [Range(-100, 100, ErrorMessage = "Temperature exceeds limit.")]
        public int CelsiusTemperature { get; set; }

        public int FahrenheitTemperature => (int)(CelsiusTemperature * (9.0 / 5.0)) + 32;
    }
}