using System;
using System.Collections.Generic;
using System.Text;

namespace LearningBlazorWA.Shared {
    /// <summary>
    /// Class for 
    /// </summary>
    public class WeatherForecast {
        /// <summary>
        /// 
        /// </summary>
        public DateTime Date { get; set; }

        public int TemperatureC { get; set; }

        public string Summary { get; set; }

        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

        // Java
        int x;
        public int getX() {
            return x;
        }
    }
}
