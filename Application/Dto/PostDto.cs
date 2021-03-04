using Application.Mappings;
using AutoMapper;
using Domain.Entity;
using System;

namespace Application.Dto
{
    public class PostDto : IMap
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime CreationData { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Post, PostDto>().ForMember(dest => dest.CreationData, opt => opt.MapFrom(str => str.CreatedAt));
        }
    }
}
