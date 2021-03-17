using Application.Dto;
using Domain.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Interface
{
    public interface IPostService
    {
        IQueryable<PostDto> GetAllPosts();
        Task<IEnumerable<PostDto>> GetAllPostAsync(int pageNumber, int pageSize, string sortField, bool ascending, string filterBy);
        Task<int> GetAllPostsCountAsync(string filterBy);
        Task<PostDto> GetPostByIdAsync(int id);
        Task<IEnumerable<PostDto>> SearchAsync(string title, int pageNumber, int pageSize, string sortField, bool ascending, string filterBy);
        Task<PostDto> AddNewPostAsync(CreatePostDto newPost, string userId);
        Task UpdatePostAsync(UpdatePostDto updatePost);
        Task DeletePostAsync(int id);
        Task<bool> UserOwnsPostAsync(int postId, string userId);
    }
}
