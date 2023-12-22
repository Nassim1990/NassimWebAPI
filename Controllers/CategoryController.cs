using Microsoft.AspNetCore.Mvc;
using NassimWebAPI.Entities;
using NassimWebAPI.Services;

namespace NassimWebAPI.Controllers
{
    [ApiController]
    [Route("categories")]
    public class CategoryController : ControllerBase
    {

        private readonly ILogger<PostController> _logger;
        private readonly IPostInfoRepository _postInfoRepository;

        public CategoryController(ILogger<PostController> logger, IPostInfoRepository postInfoRepo)
        {
            _logger = logger;
            _postInfoRepository = postInfoRepo;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Category>>> GetAllPosts()
        {
            var res = await _postInfoRepository.GetCategoriesAsync();

            return Ok(res);
        }
    }
}
