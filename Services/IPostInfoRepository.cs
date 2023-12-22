using NassimWebAPI.Entities;

namespace NassimWebAPI.Services
{
    public interface IPostInfoRepository
    {
        Task<IEnumerable<Post>> GetPostsAsync();

        Task<Post?> GetPostAsync(int postId);

        Task<IEnumerable<Category>> GetCategoriesAsync();

        Task<IEnumerable<Post>> AddPostsAsync(string title, string contents, string categoryId);

        Task<bool> SaveChangesAsync();
    }
}
