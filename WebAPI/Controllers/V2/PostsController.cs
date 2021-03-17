using Application.Dto;
using Application.Interface;
using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Filters;
using WebAPI.Helpers;
using WebAPI.Wrappers;

namespace WebAPI.Controllers.V2
{
    [Authorize]
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

        [SwaggerOperation(Summary = "Retrives sort fields.")]
        [HttpGet("[action]")]
        public IActionResult GetSortFields()
        {
            return Ok(SortingHelper.GetSortFields().Select(x => x.Key));
        }

        [SwaggerOperation(Summary = "Returns all posts.")]
        [EnableQuery]
        [HttpGet("[action]")]
        public IQueryable<PostDto> GetAll()
        {
            return _postService.GetAllPosts();
        }

        [SwaggerOperation(Summary = "Returns paged posts.")]
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] PaginationFilter paginationFilter, [FromQuery] SortingFilter sortingFilter, [FromQuery] string filterBy = "")
        {
            var validPaginationFilter = new PaginationFilter(paginationFilter.PageNumber, paginationFilter.PageSize);
            var validSortingFilter = new SortingFilter(sortingFilter.SortField, sortingFilter.Ascending);

            var posts = await _postService.GetAllPostAsync(validPaginationFilter.PageNumber, validPaginationFilter.PageSize, validSortingFilter.SortField, validSortingFilter.Ascending, filterBy);
            var totalRecords = await _postService.GetAllPostsCountAsync(filterBy);

            return Ok(PaginationHelper.CreatePagedResponse(posts, validPaginationFilter, totalRecords));
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
        public async Task<IActionResult> Search([FromQuery] PaginationFilter paginationFilter, string title, [FromQuery] SortingFilter sortingFilter, [FromQuery] string filterBy)
        {
            var validPaginationFilter = new PaginationFilter(paginationFilter.PageNumber, paginationFilter.PageSize);
            var validSortingFilter = new SortingFilter(sortingFilter.SortField, sortingFilter.Ascending);

            var posts = await _postService.SearchAsync(title, validPaginationFilter.PageNumber, validPaginationFilter.PageSize, validSortingFilter.SortField, validSortingFilter.Ascending, filterBy);

            return Ok(new Response<IEnumerable<PostDto>>(posts));
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
