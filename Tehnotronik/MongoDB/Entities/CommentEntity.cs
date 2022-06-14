using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tehnotronik.Domain.Models;

namespace Tehnotronik.MongoDB.Entities
{
    public class CommentEntity : BaseEntity
    {
        public Guid UserId { get; set; }
        public string Text { get; set; }
        public Comment ToComment()
            => new Comment(this.Id, this.UserId, this.Text);
        public static CommentEntity ToCommentEntity(Comment comment)
        {
            return new CommentEntity
            {
                Id = comment.Id,
                UserId = comment.UserId,
                Text = comment.Text
            };
        }
    }
}
