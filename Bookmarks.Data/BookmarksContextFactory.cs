using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;

namespace Bookmarks.Data
{
    public class BookmarksContextFactory : IDesignTimeDbContextFactory<BookmarksDbContext>
    {
        public BookmarksDbContext CreateDbContext(string[] args)
        {
            var config = new ConfigurationBuilder()
               .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), $"..{Path.DirectorySeparatorChar}Bookmarks.Web"))
               .AddJsonFile("appsettings.json")
               .AddJsonFile("appsettings.local.json", optional: true, reloadOnChange: true).Build();

            return new BookmarksDbContext(config.GetConnectionString("ConStr"));
        }
    }
}