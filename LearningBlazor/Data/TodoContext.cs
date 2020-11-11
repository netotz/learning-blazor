
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using LearningBlazor.Models;

using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

using Pomelo.EntityFrameworkCore.MySql.Infrastructure;

namespace LearningBlazor.Data {
    public class TodoContext : DbContext {

        //[Inject]
        //private IConfiguration Configuration { get; set; }

        //public static string ConnectionString { get; set; }

        public DbSet<Author> Author { get; set; }

        public DbSet<TodoItem> TodoItem { get; set; }

        public TodoContext(DbContextOptions<TodoContext> options) : base(options) { }
        //public TodoContext() {
        //    ConnectionString = Configuration.GetConnectionString("DummyEFDb");
        //}

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
        //    //if (!optionsBuilder.IsConfigured) {
        //        optionsBuilder.UseMySql(
        //            ConnectionString,
        //            //Configuration.GetConnectionString("DummyEFDb"),
        //            mySqlOptions => mySqlOptions
        //                .ServerVersion(new Version(5, 7, 31), ServerType.MySql)
        //                .CharSetBehavior(CharSetBehavior.NeverAppend));
        //    //}
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.Entity<TodoItem>(entity => {
                entity.HasKey(item => item.Id);
                entity.Property(item => item.Title)
                    .HasMaxLength(255)
                    .IsRequired();
                entity.HasOne(item => item.Author)
                    .WithMany(author => author.TodoItems);
            });

            modelBuilder.Entity<Author>(entity => {
                entity.HasKey(author => author.Id);
                entity.Property(author => author.Name)
                    .HasMaxLength(255)
                    .IsRequired();
            });
        }

        public async Task<Author> GetAuthorAsync(int id) {
            return await Author
                .Include(a => a.TodoItems)
                .SingleAsync(a => a.Id == id);
        }

        public async Task InsertAuthorAsync(Author author) {
            await Author.AddAsync(author);
            await SaveChangesAsync();
        }

        public async Task<List<TodoItem>> GetTodoItemsByAuthorIdAsync(int authorId) {
            var items = await TodoItem.Where(i => i.Author.Id == authorId).ToListAsync();
            return items ?? new List<TodoItem>();
        }

        public async Task<List<TodoItem>> GetAllTodoItemsAsync() {
            return await TodoItem
                .Include(i => i.Author)
                .ToListAsync();
        }

        public async Task InsertTodoItemAsync(TodoItem todoItem) {
            await TodoItem.AddAsync(todoItem);
            await SaveChangesAsync();
        }

        public async Task UpdateTodoItemAsync(TodoItem todoItem) {
            Entry(todoItem).State = EntityState.Modified;
            await SaveChangesAsync();
        }

        public async Task DeleteTodoItemAsync(TodoItem todoItem) {
            Entry(todoItem).State = EntityState.Deleted;
            await SaveChangesAsync();
        }
    }
}
