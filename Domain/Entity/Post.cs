using Domain.Common;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entity
{
    [Table("Posts")]
    public class Post : AuditableEntity
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(25)]
        public string Title { get; set; }
        [Required]
        [MaxLength(100)]
        public string Content { get; set; }
        [Required]
        [MaxLength(450)]
        public string UserId { get; set; }

        public Post() 
        {
            CreatedAt = DateTime.UtcNow;
        }

        public Post(int id, string title, string content)
        {

            Id = id;
            Title = title;
            Content = content;
        }
    }
}
