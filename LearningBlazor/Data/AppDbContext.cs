
using LearningBlazor.Models;

using Microsoft.EntityFrameworkCore;

namespace LearningBlazor.Data {
    /// <summary>
    /// Main database context. Only contains entities (tables) definitions.
    /// </summary>
    public class AppDbContext : DbContext {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected AppDbContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.Entity<TodoItem>(entity => {
                entity.ToTable(typeof(TodoItem).Name);
                //entity.HasKey(item => item.Id);
                entity.Property(item => item.Title)
                    .HasMaxLength(255)
                    .IsRequired();
                //entity.HasOne(item => item.Author)
                //    .WithMany(author => author.TodoItems);
                //entity.OwnsOne(item => item.Category);
            });

            modelBuilder.Entity<Category>(entity => {
                entity.ToTable(typeof(Category).Name);
                entity.Property(c => c.Name)
                    .HasMaxLength(50)
                    .IsRequired();
            });

            modelBuilder.Entity<Author>(entity => {
                entity.ToTable(typeof(Author).Name);
                //entity.HasKey(author => author.Id);
                entity.Property(author => author.Name)
                    .HasMaxLength(255)
                    .IsRequired();
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}
