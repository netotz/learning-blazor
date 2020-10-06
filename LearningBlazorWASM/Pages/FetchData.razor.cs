using LearningBlazorWASM.Models;

using Microsoft.AspNetCore.Components;

using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace LearningBlazorWASM.Pages {
    public partial class FetchData {

        public WeatherForecast[] Forecasts { get; set; }

        [Inject]
        public HttpClient Http { get; set; }

        protected override async Task OnInitializedAsync() {
            Forecasts = await Http.GetFromJsonAsync<WeatherForecast[]>("sample-data/weather.json");
        }
    }
}
