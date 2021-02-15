using Application.Dto;
using System.Collections.Generic;

namespace Application.Interface
{
    public interface IPostService
    {
        IEnumerable<PostDto> GetAllPost();
        PostDto GetPostById(int id);
    }

    
}
