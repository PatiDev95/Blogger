using Application.Dto;
using AutoMapper;
using Domain.Entity;

namespace Application.Mappings
{
    public static class AutoMapperConfig
    {
        public static IMapper Inicialize() =>

         new MapperConfiguration(cfg =>
         {
             cfg.CreateMap<Post, PostDto>();
             cfg.CreateMap<CreatePostDto, Post>();
         })
            .CreateMapper();
    }
}
