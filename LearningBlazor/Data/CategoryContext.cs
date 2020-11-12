
using System.Threading.Tasks;

using LearningBlazor.Models;

using Microsoft.EntityFrameworkCore;

namespace LearningBlazor.Data {
    public class CategoryContext : AppDbContext {

        public DbSet<Category> CategoryTable { get; set; }

        public CategoryContext(DbContextOptions<CategoryContext> options) : base(options) { }

    }
}
