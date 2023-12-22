using Microsoft.EntityFrameworkCore;
using NassimWebAPI.DbContexts;
using NassimWebAPI.Entities;

namespace NassimWebAPI.Services
{
    public class PostInfoRepository : IPostInfoRepository
    {
        private readonly PostInfoContext _context;
        public PostInfoRepository (PostInfoContext context) {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public Task<IEnumerable<Post>> AddPostsAsync(string title, string contents, string categoryId)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Category>> GetCategoriesAsync()
        {
            return await _context.Categories.ToListAsync();
        }

        public async Task<Post?> GetPostAsync(int postId)
        {
            return await _context.Posts.Where(p => p.Id == postId).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Post>> GetPostsAsync()
        {
            return await _context.Posts.ToListAsync();
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync() >= 0);
        }
    }
}
