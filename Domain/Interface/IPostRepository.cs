using Domain.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Interface
{
    public interface IPostRepository
    {
        Task<IEnumerable<Post>> GetAllAsync(int pageNumber, int pageSize);
        Task<int> GetAllCountAsync();
        Task<Post> GetByIdAsync(int id);
        Task<Post> AddAsync(Post post);
        Task UpdateAsync(Post post);
        Task DeleteAsync(Post post);
    }
}
