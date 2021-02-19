using Domain.Entity;
using Domain.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Infrastructure.Repository
{
    public class PostRepository : IPostRepository
    {
        public static  ISet<Post> _posts = new HashSet<Post> 
        { 
            new Post(1, "Jak zostać programistą", "..."),
            new Post(2, "Ile zarabia programista", "..."),
            new Post(3, "Dlaczego warto zostać programistą", "...")
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
