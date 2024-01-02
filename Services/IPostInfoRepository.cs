using NassimWebAPI.Entities;

namespace NassimWebAPI.Services
{
    public interface IPostInfoRepository
    {
        Task<IEnumerable<Post>> GetPostsAsync();

        Task<Post?> GetPostAsync(int postId);

        Task<IEnumerable<Category>> GetCategoriesAsync();

        Task AddPostAsync(Post post);

        void DeletePost(int postId);
        void DeleteAllPost();

        Task<bool> SaveChangesAsync();
    }
}
