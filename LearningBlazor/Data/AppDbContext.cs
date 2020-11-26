
using System;

using LearningBlazor.Models;

using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

using Pomelo.EntityFrameworkCore.MySql.Infrastructure;

namespace LearningBlazor.Data {
    /// <summary>
    /// Main database context. Only contains entities (tables) definitions.
    /// </summary>
    public class AppDbContext : DbContext {

        //[Inject]
        //private IConfiguration Configuration { get; set; }
        //public static string ConnectionString { get; set; }

        public AppDbContext() { }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected AppDbContext(DbContextOptions options) : base(options) { }

        //protected override void OnConfiguring(DbContextOptionsBuilder options) {
        //    options.UseMySql(
        //        //ConnectionString,
        //        Configuration.GetConnectionString("DummyEFDb"),
        //        mySqlOptions => mySqlOptions
        //        .ServerVersion(new Version(5, 7, 31), ServerType.MySql)
        //        .CharSetBehavior(CharSetBehavior.NeverAppend));
        //    options.EnableSensitiveDataLogging(true);

        //    base.OnConfiguring(options);
        //}

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
