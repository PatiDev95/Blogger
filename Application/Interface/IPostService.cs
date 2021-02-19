using Application.Dto;
using System.Collections.Generic;

namespace Application.Interface
{
    public interface IPostService
    {
        IEnumerable<PostDto> GetAllPost();
        PostDto GetPostById(int id);
        IEnumerable<PostDto> Search(string title);
        PostDto AddNewPost(CreatePostDto newPost);
        void UpdatePost(UpdatePostDto updatePost);
        void DeletePost(int id);
    }
}
