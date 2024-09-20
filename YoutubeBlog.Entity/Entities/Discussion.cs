using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YoutubeBlog.Core.Entities;

namespace YoutubeBlog.Entity.Entities
{
    public class Discussion : EntityBase
    {
        public Discussion()
        {

        }
        public Discussion(string title, string content, Guid userId, string createdBy)
        {
            Title = title;
            Content = content;
            UserId = userId;
            CreatedBy = createdBy;
        }
        public string Title { get; set; }
        public string Content { get; set; }

        public Guid UserId { get; set; }
        public AppUser User { get; set; }

        public ICollection<DiscussionFor> DiscussionFors { get; set; }
    }
}
