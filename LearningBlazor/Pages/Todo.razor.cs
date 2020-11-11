using System.Linq;
using System.Threading.Tasks;

using LearningBlazor.Data;
using LearningBlazor.Models;

using Microsoft.AspNetCore.Components;

namespace LearningBlazor.Pages {

    public partial class Todo {

        [Inject]
        private TodoContext TodoContext { get; set; }

        private Author CurrentAuthor { get; set; }

        private string NewTitle { get; set; } = string.Empty;

        private int Incompleted => CurrentAuthor.TodoItems.Count(i => !i.IsDone);

        protected override async Task OnInitializedAsync() {
            //await TodoContext.InsertAuthorAsync(new Author {
            //    Name = "He"
            //});
            CurrentAuthor = await TodoContext.GetAuthorAsync(1);
        }

        private async Task AddItemAsync() {
            if (!string.IsNullOrWhiteSpace(NewTitle)) {
                var todoItem = new TodoItem {
                    Title = NewTitle,
                    IsDone = false,
                    Author = CurrentAuthor
                };

                await TodoContext.InsertTodoItemAsync(todoItem);

                NewTitle = string.Empty;
            }
        }

        private async Task DeleteItemAsync(int itemId) {
            var item = CurrentAuthor.TodoItems.Find(i => i.Id == itemId);
            await TodoContext.DeleteTodoItemAsync(item);
        }

        //private async Task UpdateItemAsync(ChangeEventArgs eventArgs) {
        //    var id = (int)eventArgs.Value;
        //    var item = Items.First(i => i.Id == id);
        //    item.IsDone = !item.IsDone;
        //    Items.First(i => i.Id == item.Id).IsDone = item.IsDone;
        //    await TodoContext.UpdateTodoItemAsync(item);
        //}
    }
}