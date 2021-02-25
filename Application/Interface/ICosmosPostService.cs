using Application.Dto.Cosmos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Interface
{
    public interface ICosmosPostService
    {
        Task<IEnumerable<CosmosPostDto>> GetAllPostAsync();
        Task<CosmosPostDto> GetPostByIdAsync(string id);
        Task<IEnumerable<CosmosPostDto>> SearchAsync(string title);
        Task<CosmosPostDto> AddNewPostAsync(CreateCosmosPostDto newPost);
        Task UpdatePostAsync(UpdateCosmosPostDto updatePost);
        Task DeletePostAsync(string id);
    }
}
