using Application.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Interface
{
    public interface IPostService
    {
        Task<IEnumerable<PostDto>> GetAllPostAsync(int pageNumber, int pageSize);
        Task<int> GetAllPostsCountAsync();
        Task<PostDto> GetPostByIdAsync(int id);
        Task<IEnumerable<PostDto>> SearchAsync(string title, int pageNumber, int pageSize);
        Task<PostDto> AddNewPostAsync(CreatePostDto newPost);
        Task UpdatePostAsync(UpdatePostDto updatePost);
        Task DeletePostAsync(int id);
    }
}
