namespace LearningBlazor.Models {

    public class TodoItem {

        public int Id { get; set; }

        public string Title { get; set; }

        public bool IsDone { get; set; }

        public Author Author { get; set; }
    }
}