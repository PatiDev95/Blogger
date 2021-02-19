using Application.Dto;
using Application.Interface;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Linq;
using System.Runtime.InteropServices;

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
        public IActionResult GetAll()
        {
            var posts = _postService.GetAllPost();
            return Ok(new { Post = posts, Count = posts.Count() });
        }

        [SwaggerOperation(Summary = "Return a post with the specified id.")]
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var post = _postService.GetPostById(id);
            if (post != null)
            {
                return Ok(post);
            }
            return NotFound();
        }

        [SwaggerOperation(Summary = "Search post by title.")]
        [HttpGet]
        [Route("Search/{title}")]
        public IActionResult Search(string title)
        {
            var posts = _postService.Search(title);
            return Ok(posts);
        }

        [SwaggerOperation(Summary = "Create new post.")]
        [HttpPost]
        public IActionResult Post(CreatePostDto newPost)
        {
            var post = _postService.AddNewPost(newPost);
            return Created($"api/posts/{post.Id}", post);
        }

        [SwaggerOperation(Summary = "Update existing post.")]
        [HttpPut]
        public IActionResult Put(UpdatePostDto updatePost)
        {
            _postService.UpdatePost(updatePost);
            return NoContent();
        }

        [SwaggerOperation(Summary = "Delete existing post.")]
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            _postService.DeletePost(id);
            return NoContent();
        }
    }
}
