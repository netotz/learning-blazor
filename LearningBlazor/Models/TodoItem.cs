namespace LearningBlazor.Models {

    public class TodoItem {

        public int Id { get; set; }

        public string Title { get; set; }

        public bool IsDone { get; set; }

        public virtual Author Author { get; set; }

        public virtual Category Category { get; set; }
    }
}