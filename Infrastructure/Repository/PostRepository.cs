using Domain.Entity;
using Domain.Interface;
using Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Infrastructure.Repository
{
    public class PostRepository : IPostRepository
    {
        private readonly BloggerContext _context;

        public PostRepository(BloggerContext context)
        {
            _context = context;
        }

        public IEnumerable<Post> GetAll()
        {
            return _context.Posts; 
        }

        public Post GetById(int id)
        {
            return _context.Posts.SingleOrDefault(x => x.Id == id);
        }

        public Post Add(Post post)
        {
            post.CreatedAt = DateTime.UtcNow;
            _context.Posts.Add(post);
            _context.SaveChanges();
            return post;
        }

        public void Update(Post post)
        {
            post.LastModified = DateTime.UtcNow;
            _context.Posts.Update(post);
            _context.SaveChanges();
        }

        public void Delete(Post post)
        {
            _context.Posts.Remove(post);
            _context.SaveChanges();
        }
    }
}
