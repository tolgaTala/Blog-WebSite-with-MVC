using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YoutubeBlog.Entity.Entities;

namespace YoutubeBlog.Entity.Dtos.Discussions
{
    public class DiscussionForDto
    {
        public Guid Id { get; set; }
        public string Content { get; set; }
        public DateTime CreatedDate { get; set; }
        public Guid UserId { get; set; }
        public AppUser User { get; set; }
        public Guid DiscussionId { get; set; }
        public Discussion Discussion{ get; set; }
        public string CreatedBy { get; set; }
        public bool IsDeleted { get; set; }
    }
}
