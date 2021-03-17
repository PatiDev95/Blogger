using Application.Services;
using Domain.Common;
using Domain.Entity;
using Infrastructure.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class BloggerContext : IdentityDbContext<ApplicationUser>
    {
        private readonly UserResolverService _userService;

        public BloggerContext(DbContextOptions<BloggerContext> options, UserResolverService userService) : base(options)
        {
            _userService = userService;
        }
        public DbSet<Post> Posts { get; set; }

        public async Task<int> SaveChangesAsync()
        {
            var entries = ChangeTracker.
                Entries().
                Where(e => e.Entity is AuditableEntity && (e.State == EntityState.Modified || e.State == EntityState.Added));

            foreach (var entityEntry in entries)
            {
                ((AuditableEntity)entityEntry.Entity).LastModified = DateTime.UtcNow;
                ((AuditableEntity)entityEntry.Entity).LastModifiedBy = _userService.GetUser();

                if (entityEntry.State == EntityState.Added)
                {
                    ((AuditableEntity)entityEntry.Entity).CreatedAt = DateTime.UtcNow;
                    ((AuditableEntity)entityEntry.Entity).CreatedBy = _userService.GetUser();
                }
            }
            return await base.SaveChangesAsync();
        }
    }
}
