using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LearningBlazorWASM.Pages {
    public partial class Counter {

        public static int CurrentCount { get; set; } = 0;

        private void IncrementCount() {
            CurrentCount++;
        }
    }
}
