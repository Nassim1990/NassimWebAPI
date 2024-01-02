using Microsoft.AspNetCore.Mvc;
using NassimWebAPI.Entities;
using NassimWebAPI.Services;

namespace NassimWebAPI.Controllers
{
    [ApiController]
    [Route("posts")]
    public class PostController : ControllerBase
    {

        private readonly ILogger<PostController> _logger;
        private readonly IPostInfoRepository _postInfoRepository;

        public PostController(ILogger<PostController> logger, IPostInfoRepository postInfoRepo)
        {
            _logger = logger;
            _postInfoRepository = postInfoRepo;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<Post>>> GetAllPosts()
        {
            var res = await _postInfoRepository.GetPostsAsync();

            return Ok(res);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Post>> GetPost(int id)
        {
            var res = await _postInfoRepository.GetPostAsync(id);

            return Ok(res);
        }

        [HttpPost]
        public async Task<ActionResult> AddPost(string title, string contents, int categoryId)
        {
            Post post = new Post(title, contents, categoryId);
            post.TimeStamp = DateTime.UtcNow;
            await _postInfoRepository.AddPostAsync(post);
            await _postInfoRepository.SaveChangesAsync();
            return Ok(post); 
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdatePost(int id, string title, string contents, int categoryId)
        {
            Post post =  await _postInfoRepository.GetPostAsync(id);
            post.TimeStamp = DateTime.UtcNow;
            post.Title = title;
            post.Contents = contents;
            post.CateGoryId = categoryId;
            
            await _postInfoRepository.SaveChangesAsync();
            return Ok(post); 
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeletePost(int id)
        {
            _postInfoRepository.DeletePost(id);
            await _postInfoRepository.SaveChangesAsync();
            return Ok(); 
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteAllPost()
        {
            _postInfoRepository.DeleteAllPost();
            await _postInfoRepository.SaveChangesAsync();
            return Ok();
        }
    }
}
