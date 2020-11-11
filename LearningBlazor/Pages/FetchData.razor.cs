using System;
using System.Threading.Tasks;

using LearningBlazor.Data;
using LearningBlazor.Models;

using Microsoft.AspNetCore.Components;

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