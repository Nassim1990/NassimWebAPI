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
    }
}
