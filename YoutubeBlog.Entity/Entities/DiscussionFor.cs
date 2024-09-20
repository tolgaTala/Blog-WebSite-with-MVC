using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YoutubeBlog.Core.Entities;

namespace YoutubeBlog.Entity.Entities
{
    public class DiscussionFor :EntityBase
    {
        public DiscussionFor()
        {
            
        }
        public DiscussionFor( string content, Guid discussionId, Guid userId, string createdBy)
        {
            Content = content;
            DiscussionId = discussionId;
            UserId = userId;
            CreatedBy = createdBy;
        }
        public string Content { get; set; }

        public Guid DiscussionId { get; set; }
        public Discussion Discussion { get; set; }

        public Guid UserId { get; set; }
        public AppUser User { get; set; }
    }
}
