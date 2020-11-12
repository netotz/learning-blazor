using System.Linq;

namespace LearningBlazor.Models {
    public class Category {

        public int Id { get; set; }

        public string Name { get; set; }

        /// <summary>
        /// This property wasn't mapped to the database.
        /// </summary>
        private static string[] DefaultCategoriesNames =>
            new[] {
                "Fake",
                "Test",
                "Dummy",
                "Real",
                "New"
            };

        /// <summary>
        /// This property wasn't mapped to the database.
        /// </summary>
        public static Category[] DefaultCategories =>
            DefaultCategoriesNames.Select((name, index) =>
                 new Category {
                     Id = index + 1,
                     Name = name
                 }).ToArray();
    }
}
