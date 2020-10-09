using LearningBlazorWASM.Models;
using LearningBlazorWASM.Services;

using Microsoft.AspNetCore.Components;

using System;
using System.Threading.Tasks;

namespace LearningBlazorWASM.Pages {
    public partial class FetchData {

        public string LoadingLabel { get; set; }

        public WeatherForecast[] Forecasts { get; set; }

        [Inject]
        public WeatherForecastService ForecastService { get; set; }

        protected override async Task OnInitializedAsync() {
            LoadingLabel = "Loading data...";
            await GetData();
        }

        private async Task GetData() {
            Forecasts = await ForecastService.GetRandomForecastsAsync(DateTime.Now, 1000);
            //Forecasts = await Task.Run(() => ForecastService.GetRandomForecasts(DateTime.Now, 1000));s
        }
    }
}
