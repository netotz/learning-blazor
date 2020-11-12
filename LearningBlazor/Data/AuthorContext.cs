
using System.Threading.Tasks;

using LearningBlazor.Models;

using Microsoft.EntityFrameworkCore;

namespace LearningBlazor.Data {
    public class AuthorContext : AppDbContext {

        public DbSet<Author> AuthorTable { get; set; }

        public AuthorContext(DbContextOptions<AuthorContext> options) : base(options) { }

        public async Task<Author> GetAuthorAsync(int id) {
            return await AuthorTable
                .Include(a => a.TodoItems)
                .SingleOrDefaultAsync(a => a.Id == id);
        }

        public async Task InsertAuthorAsync(Author author) {
            await AuthorTable.AddAsync(author);
            await SaveChangesAsync();
        }
    }
}
