using Application.Interface;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Controllers.V2;

namespace WebAPI.Controllers.V4
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ApiVersion("4.0")]
    [Route("v4/api/[controller]")]
    [ApiController]
    public class DapperPostsController : PostsController
    {
        public DapperPostsController(IDapperPostService postService) : base(postService)
        {
        }
    }
}
