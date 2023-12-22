using NassimWebAPI.Entities;

namespace NassimWebAPI.Services
{
    public interface IPostInfoRepository
    {
        Task<IEnumerable<Post>> GetPostsAsync();

        Task<Post?> GetPostAsync(int postId);

        Task<IEnumerable<Category>> GetCategoriesAsync();

        Task AddPostAsync(string title, string contents, int categoryId);

        Task<bool> SaveChangesAsync();
    }
}
