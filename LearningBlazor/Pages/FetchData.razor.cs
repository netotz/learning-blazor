using LearningBlazor.Data;

using Microsoft.AspNetCore.Components;

using System;
using System.Threading.Tasks;

namespace LearningBlazor.Pages {
    public partial class FetchData {
        [Inject]
        public WeatherForecastService ForecastService { get; set; }
        private WeatherForecast[] Forecasts { get; set; }

        protected override async Task OnInitializedAsync() {
            Forecasts = await ForecastService.GetForecastAsync(DateTime.Now);
        }
    }
}
