
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
    public class TodoContext : AppDbContext {

        //[Inject]
        //private IConfiguration Configuration { get; set; }

        //public static string ConnectionString { get; set; }

        public DbSet<Author> AuthorTable { get; set; }

        public DbSet<TodoItem> TodoItemTable { get; set; }

        public DbSet<Category> CategoryTable { get; set; }

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

        public async Task SeedCategoriesAsync() {
            foreach (var category in Category.DefaultCategories) {
                //var category = new Category {
                //    Name = categoryName
                //};
                await CategoryTable.AddAsync(category);
            }
            await SaveChangesAsync();
        }

        public async Task<Author> GetAuthorAsync(int id) {
            return await AuthorTable
                .Include(a => a.TodoItems)
                .SingleAsync(a => a.Id == id);
        }

        public async Task<List<TodoItem>> GetTodoItemsByAuthorIdAsync(int authorId) {
            var items = await TodoItemTable
                .Where(i => i.Author.Id == authorId)
                .Include(i => i.Author)
                .Include(i => i.Category)
                .ToListAsync();
            return items ?? new List<TodoItem>();
        }

        public async Task<List<TodoItem>> GetAllTodoItemsAsync() {
            return await TodoItemTable
                .Include(i => i.Author)
                .Include(i => i.Category)
                .ToListAsync() ?? new List<TodoItem>();
        }

        public async Task InsertTodoItemAsync(TodoItem todoItem) {
            await TodoItemTable.AddAsync(todoItem);
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

        public async Task<Category> GetCategoryByIdAsync(int categoryId) {
            return await CategoryTable.SingleAsync(c => c.Id == categoryId);
        }
    }
}
