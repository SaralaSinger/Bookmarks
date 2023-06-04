using Bookmarks.Data;
using Bookmarks.Web.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Bookmarks.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookmarkController : ControllerBase
    {
        private readonly string _connectionString;

        public BookmarkController(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("ConStr");
        }
        [HttpPost]
        [Route("add")]
        public void Add(Bookmark bookmark)
        {
            var userRepo = new UserRepository(_connectionString);
            var user = userRepo.GetByEmail(User.Identity.Name);
            bookmark.UserId = user.Id;
            var bookmarkRepo = new BookmarkRepository(_connectionString);
            bookmarkRepo.AddBookmark(bookmark);
        }
        [HttpPost]
        [Route("delete")]
        public void Delete(Bookmark bookmark)
        {
            var bookmarkRepo = new BookmarkRepository(_connectionString);
            bookmarkRepo.Delete(bookmark);
        }
        [HttpPost]
        [Route("update")]
        public void Update(Bookmark bookmark)
        {
            var bookmarkRepo = new BookmarkRepository(_connectionString);
            bookmarkRepo.Update(bookmark.Id, bookmark.Title);
        }
        [HttpGet]
        [Route("getall")]
        public List<Bookmark> GetAll()
        {
            var userRepo = new UserRepository(_connectionString);
            var user = userRepo.GetByEmail(User.Identity.Name);
            var bookmarkRepo = new BookmarkRepository(_connectionString);
            return bookmarkRepo.GetAll(user);
        }
        [HttpGet]
        [Route("getpopularlinks")]
        public List<Link> GetPopularLinks()
        {
            var bookmarkRepo = new BookmarkRepository(_connectionString);
            return bookmarkRepo.GetPopularLinks();
        }
    }
}
