using System.Threading.Tasks;

using LearningBlazor.Data;
using LearningBlazor.Models;

using Microsoft.AspNetCore.Components;

namespace LearningBlazor.Pages {
    public partial class Index {

        [Inject]
        private AuthorContext AuthorContext { get; set; }

        private Author CurrentAuthor { get; set; }

        protected override async Task OnInitializedAsync() {
            //await AuthorContext.InsertAuthorAsync(new Author {
            //    Name = "Me"
            //});

            CurrentAuthor = await AuthorContext.GetAuthorAsync(1);

            await base.OnInitializedAsync();
        }
    }
}
