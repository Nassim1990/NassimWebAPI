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

        public async Task AddPostAsync(Post post)
        {
            await _context.Posts.AddAsync(post);
        }

        public void DeletePost(int postId)
        {
            _context.Posts.Remove(_context.Posts.Where(p=> p.Id == postId).FirstOrDefault());
        }

        public void DeleteAllPost()
        {
            _context.Posts.RemoveRange(_context.Posts);
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
