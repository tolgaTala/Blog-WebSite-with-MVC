using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YoutubeBlog.Entity.Dtos.Discussions
{
    public class DiscussionForAddDto
    {
        public string Content { get; set; }
        public Guid DiscussionId { get; set; }
    }
}
