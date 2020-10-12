using System.Collections.Generic;
using System.Linq;

using LearningBlazor.Data;

namespace LearningBlazor.Pages {

    public partial class Todo {
        private IList<TodoItem> Items { get; set; } = new List<TodoItem>();
        private string NewTitle { get; set; }
        private int Incompleted => Items.Count(i => !i.IsDone);

        private void AddItem() {
            if (!string.IsNullOrWhiteSpace(NewTitle)) {
                Items.Add(new TodoItem {
                    Title = NewTitle
                });
                NewTitle = string.Empty;
            }
        }
    }
}