using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YoutubeBlog.Core.Entities;

namespace YoutubeBlog.Entity.Entities
{
    public class SocialMedia : EntityBase
    {
        public SocialMedia() { }
        public SocialMedia(string name, string url)
        {
            Name = name;
            Url = url;
        }
        public string Name { get; set; }
        public string Url { get; set; }
    }
}
