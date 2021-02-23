using Application.Dto;
using Application.Interface;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers.V2
{
    [ApiExplorerSettings(IgnoreApi = false)]
    [ApiVersion("2.0")]
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
        public async Task<IActionResult> GetAll()
        {
            var posts = await _postService.GetAllPostAsync();
            return Ok(new { Post = posts, Count = posts.Count() });
        }

        [SwaggerOperation(Summary = "Return a post with the specified id.")]
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var post = await _postService.GetPostByIdAsync(id);
            if (post != null)
            {
                return Ok(post);
            }
            return NotFound();
        }

        [SwaggerOperation(Summary = "Search post by title.")]
        [HttpGet]
        [Route("Search/{title}")]
        public async Task<IActionResult> Search(string title)
        {
            var posts = await _postService.SearchAsync(title);
            return Ok(posts);
        }

        [SwaggerOperation(Summary = "Create new post.")]
        [HttpPost]
        public async Task<IActionResult> Post(CreatePostDto newPost)
        {
            var post = await  _postService.AddNewPostAsync(newPost);
            return Created($"api/posts/{post.Id}", post);
        }

        [SwaggerOperation(Summary = "Update existing post.")]
        [HttpPut]
        public async Task<IActionResult> Put(UpdatePostDto updatePost)
        {
            await _postService.UpdatePostAsync(updatePost);
            return NoContent();
        }

        [SwaggerOperation(Summary = "Delete existing post.")]
        [HttpDelete]
        public async  Task<IActionResult> Delete(int id)
        {
            await _postService.DeletePostAsync(id);
            return NoContent();
        }
    }
}
