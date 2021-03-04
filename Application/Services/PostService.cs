using Application.Dto;
using Application.Interface;
using AutoMapper;
using Domain.Entity;
using Domain.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Services
{
    public class PostService : IPostService
    {
        public readonly IPostRepository _postRepository;
        public readonly IMapper _mapper;

        public PostService(IPostRepository postRepository, IMapper mapper)
        {
            _postRepository = postRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<PostDto>> GetAllPostAsync(int pageNumber, int pageSize, string sortField, bool ascending)
        {
            var posts = await _postRepository.GetAllAsync(pageNumber, pageSize, sortField, ascending);
            return _mapper.Map<IEnumerable<PostDto>>(posts);
        }

        public async Task<int> GetAllPostsCountAsync()
        {
            return await _postRepository.GetAllCountAsync();
        }

        public async Task<PostDto> GetPostByIdAsync(int id)
        {
            var post = await _postRepository.GetByIdAsync(id);
            return _mapper.Map<PostDto>(post);
        }

        public async Task<IEnumerable<PostDto>> SearchAsync(string title, int pageNumber, int pageSize, string sortField, bool ascending)
        {
            var posts = await _postRepository.GetAllAsync(pageNumber, pageSize, sortField, ascending);

            if (string.IsNullOrWhiteSpace(title))
            {
                return _mapper.Map<IEnumerable<PostDto>>(posts);
            }

            var filterPost = posts.Where(x => x.Title.ToUpper().Contains(title.ToUpper()));

            return _mapper.Map<IEnumerable<PostDto>>(filterPost);
        }

        public async Task<PostDto> AddNewPostAsync(CreatePostDto newPost)
        {
            if (string.IsNullOrEmpty(newPost.Title))
            {
                throw new Exception("Title can not be empty.");
            }

            var post = _mapper.Map<Post>(newPost);
            var result = await _postRepository.AddAsync(post);
            return _mapper.Map<PostDto>(result);
        }

        public async Task UpdatePostAsync(UpdatePostDto updatePost)
        {
            var existingPost = await _postRepository.GetByIdAsync(updatePost.Id);
            var post = _mapper.Map(updatePost, existingPost);
            await _postRepository.UpdateAsync(post);
        }

        public async Task DeletePostAsync(int id)
        {
            var post = await _postRepository.GetByIdAsync(id);
            await _postRepository.DeleteAsync(post);
        }
    }
}
