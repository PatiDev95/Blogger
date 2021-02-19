using Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Domain.Interface
{
    public interface IPostRepository
    {
        IEnumerable<Post> GetAll();
        Post GetById(int id);
        Post Add(Post post);
        void Update(Post post);
        void Delete(Post post);
    }
}
