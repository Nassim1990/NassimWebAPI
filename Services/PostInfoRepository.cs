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

        public async Task AddPostAsync(string title, string contents, int categoryId)
        {
            Post post = new Post(title, contents, categoryId);
            post.TimeStamp = DateTime.UtcNow;

            await _context.Posts.AddAsync(post);
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
