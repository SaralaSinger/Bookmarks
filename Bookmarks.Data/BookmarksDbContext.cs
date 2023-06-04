using Microsoft.EntityFrameworkCore;

namespace Bookmarks.Data
{
    public class BookmarksDbContext : DbContext
    {
        private string _connectionString;

        public BookmarksDbContext(string connectionString)
        {
            _connectionString = connectionString;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Bookmark> Bookmarks { get; set; }
    }
}