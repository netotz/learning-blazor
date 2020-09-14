using Microsoft.AspNetCore.Components;

namespace LearningBlazor.Pages {
    public partial class Counter {
        private int CurrentCount { get; set; } = 0;
        [Parameter]
        public int Amount { get; set; } = 1;

        private void IncrementCount() {
            CurrentCount += Amount;
        }
    }
}
