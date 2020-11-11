using System.Collections.Generic;

namespace LearningBlazor.Models {
    public class Author {

        public int Id { get; set; }

        public string Name { get; set; }

        public List<TodoItem> TodoItems { get; set; }
    }
}
