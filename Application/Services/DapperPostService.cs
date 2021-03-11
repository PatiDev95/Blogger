using Application.Interface;
using AutoMapper;
using Domain.Interface;

namespace Application.Services
{
    public class DapperPostService : PostService, IDapperPostService
    {
        public DapperPostService(IDapperPostRepository postRepository, IMapper mapper) : base(postRepository, mapper)
        {
        }
    }
}
