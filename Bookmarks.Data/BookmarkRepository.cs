using Microsoft.EntityFrameworkCore;

namespace Bookmarks.Data
{
    public class BookmarkRepository
    {
        private readonly string _connectionString;

        public BookmarkRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void AddBookmark(Bookmark bookmark)
        {
            using var context = new BookmarksDbContext(_connectionString);
            context.Bookmarks.Add(bookmark);
            context.SaveChanges();
        }
        public void Delete(Bookmark bookmark)
        {
            using var context = new BookmarksDbContext(_connectionString);
            context.Bookmarks.Remove(bookmark);
            context.SaveChanges();
        }
        public void Update(int id, string title)
        {
            using var context = new BookmarksDbContext(_connectionString);
            var bookmark = context.Bookmarks.FirstOrDefault(b => b.Id == id);
            bookmark.Title = title;
            context.SaveChanges();
        }
        public List<Bookmark> GetAll(User user)
        {
            using var context = new BookmarksDbContext(_connectionString);
            return context.Bookmarks.Where(b => b.UserId == user.Id).ToList();
        }
        public List<Link> GetPopularLinks()
        {
            using var context = new BookmarksDbContext(_connectionString);
            return context.Bookmarks.GroupBy(b => b.Url).Select(row => new Link
            {
                Url = row.Key,
                Count = row.Count()
            }).OrderByDescending(row => row.Count)
                .Take(5).ToList();
        }

    }
    public class Link
    {
        public string Url { get; set; }
        public int Count { get; set; }
    }
}