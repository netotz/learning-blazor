using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using LearningBlazor.Data;
using LearningBlazor.Models;

using Microsoft.AspNetCore.Components;

namespace LearningBlazor.Pages {

    public partial class Todo {

        [Inject]
        private TodoContext TodoContext { get; set; }
        //private TodoContext TodoContext => new TodoContext();

        private Author CurrentAuthor { get; set; }

        private List<TodoItem> LocalItems { get; set; }

        private TodoItem NewItem { get; set; }

        private Category NewCategory { get; set; }

        private int Incompleted => LocalItems.Count(i => !i.IsDone);

        protected override async Task OnInitializedAsync() {
            //using var context = TodoContext;

            //await TodoContext.SeedCategoriesAsync();

            //await TodoContext.InsertAuthorAsync(new Author {
            //    Name = "He"
            //});

            CurrentAuthor = await TodoContext.GetAuthorAsync(2);
            //LocalItems = CurrentAuthor.TodoItems ?? new List<TodoItem>();
            LocalItems = await TodoContext.GetAllTodoItemsAsync();

            ResetNewItem();

            await base.OnInitializedAsync();
        }

        private void ResetNewItem() {
            NewItem = new TodoItem {
                Title = "",
                IsDone = false,
                Author = CurrentAuthor
            };
            NewCategory = new Category();
        }

        private async Task AddItemAsync() {
            if (!string.IsNullOrWhiteSpace(NewItem.Title)) {
                //using var context = TodoContext;

                NewCategory = await TodoContext.GetCategoryByIdAsync(NewCategory.Id);
                //NewCategory = Category.DefaultCategories[NewCategory.Id - 1];
                NewItem.Category = NewCategory;
                //NewItem.Category = Category.DefaultCategories[NewCategory.Id - 1];

                //var item = new TodoItem {
                //    Title = NewItem.Title,
                //    IsDone = false,
                //    Author = CurrentAuthor,
                //    Category = NewCategory
                //};
                await TodoContext.InsertTodoItemAsync(NewItem);
                LocalItems.Add(NewItem);

                ResetNewItem();
            }
        }

        private async Task DeleteItemAsync(int itemId) {
            //var item = CurrentAuthor.TodoItems.Find(i => i.Id == itemId);
            var item = LocalItems.Find(i => i.Id == itemId);
            
            //using var context = TodoContext;
            await TodoContext.DeleteTodoItemAsync(item);
            LocalItems.Remove(item);
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