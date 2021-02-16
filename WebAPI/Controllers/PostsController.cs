using Application.Interface;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        public readonly IPostService _postService;

        public PostsController(IPostService postService)
        {
            _postService = postService;
        }

        [SwaggerOperation(Summary = "Returns all posts.")]
        [HttpGet]
        public IActionResult GetAll()
        {
            var posts = _postService.GetAllPost();
            return Ok(posts);
        }

        [SwaggerOperation(Summary = "Return a post with the specified id.")]
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var post = _postService.GetPostById(id);
            if(post != null)
            {
                return Ok(post);
            }
            return NotFound();
        }
        
    }
}
