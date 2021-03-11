using Domain.Entity;
using Domain.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using System.Threading.Tasks;
using Dapper.Contrib.Extensions;

namespace Infrastructure.Repository
{
    public class DapperPostRepository : IDapperPostRepository
    {
        private readonly IDbConnection _connection;

        public DapperPostRepository(IDbConnection conection)
        {
            _connection = conection;
        }

        public IQueryable<Post> GetAll()
        {
            return _connection.Query<Post>("SELECT * FROM [BloggerDB].[dbo].[Posts]").AsQueryable();
        }

        public async Task<IEnumerable<Post>> GetAllAsync(int pageNumber, int pageSize, string sortField, bool ascending, string filterBy)
        {
            var skip = (pageNumber - 1) * pageSize;
            var take = pageSize;
            var ascQuery = ascending ? "ASC" : "DESC";
            var queryString = $@"
                SELECT * FROM [BloggerDB].[dbo].[Posts] 

                WHERE LOWER(Title) Like @filterBy OR LOWER(Content) Like @filterBy

                ORDER BY {sortField} {ascQuery}
                OFFSET {skip} ROWS
                FETCH NEXT {take} ROWS ONLY
            ";

            return (await _connection.QueryAsync<Post>(queryString, new { filterBy = "%" + filterBy + "%" })).AsQueryable();
        }

        public async Task<Post> GetByIdAsync(int id)
        {
            return await _connection.QueryFirstAsync<Post>($"SELECT * FROM [BloggerDB].[dbo].[Posts] WHERE Id = @Id", new { Id = id });
        }

        public async Task<int> GetAllCountAsync(string filterBy)
        {
            string query = @"SELECT COUNT(*) FROM [BloggerDB].[dbo].[Posts]
                WHERE LOWER(Title) Like @filterBy OR LOWER(Content) Like @filterBy";

            return await _connection.QuerySingleAsync<int>(query, new { filterBy = "%" + filterBy + "%" });
        }

        public async Task<Post> AddAsync(Post post)
        {
            await _connection.InsertAsync(post);
            return post;
        }

        public async Task UpdateAsync(Post post)
        {
            await _connection.UpdateAsync(post);
        }

        public async Task DeleteAsync(Post post)
        {
            await _connection.DeleteAsync(post);
        }
    }
}
