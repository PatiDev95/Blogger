using Domain.Entity;
using Domain.Interface;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Infrastructure.Repository
{
    public class PostRepository : IPostRepository
    {
        public static readonly ISet<Post> _posts = new HashSet<Post> 
        { 
            new Post(1, "Title1", "Content1"),
            new Post(2, "Title2", "Content2"),
            new Post(3, "Title3", "Content3")
        };

        public IEnumerable<Post> GetAll()
        {
            return _posts; 
        }

        public Post GetById(int id)
        {
            return _posts.SingleOrDefault(x => x.Id == id);
        }

        public Post Add(Post post)
        {
            post.Id = 1 + _posts.Count;
            post.CreatedAt = DateTime.UtcNow;
           _posts.Add(post);
            return post;
        }

        public void Update(Post post)
        {
            post.LastModified = DateTime.UtcNow;
        }

        public void Delete(Post post)
        {
            _posts.Remove(post);
        } 
    }
}
