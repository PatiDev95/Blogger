using Domain.Entity.Cosmos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Interface
{
    public interface ICosmosPostRepository
    {
        Task<IEnumerable<CosmosPost>> GetAllAsync();
        Task<CosmosPost> GetByIdAsync(string id);
        Task<CosmosPost> AddAsync(CosmosPost post);
        Task UpdateAsync(CosmosPost post);
        Task DeleteAsync(CosmosPost post);
    }
}
