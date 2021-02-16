using Application.Dto;
using Application.Interface;
using AutoMapper;
using Domain.Interface;
using System.Collections.Generic;

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

        public IEnumerable<PostDto> GetAllPost()
        {
            var posts = _postRepository.GetAll();
            return _mapper.Map<IEnumerable<PostDto>>(posts);
        }

        public PostDto GetPostById(int id)
        {
            var post = _postRepository.GetById(id);
            return _mapper.Map<PostDto>(post);
        }
    }
}
