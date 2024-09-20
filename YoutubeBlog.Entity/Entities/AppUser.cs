using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YoutubeBlog.Core.Entities;

namespace YoutubeBlog.Entity.Entities
{
    public class AppUser : IdentityUser<Guid> , IEntityBase
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public Guid ImageId { get; set; } = Guid.Parse("a65c4e1f-eb26-4c71-b315-3fc93fe27645");
        public Image Image { get; set; }

        public ICollection<Article> Articles { get; set; }
        public ICollection<Discussion> Discussions { get; set; }
        public ICollection<DiscussionFor> DiscussionFors { get; set; }
    }
}
