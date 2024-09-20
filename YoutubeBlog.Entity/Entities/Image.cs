using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YoutubeBlog.Core.Entities;
using YoutubeBlog.Entity.Enums;

namespace YoutubeBlog.Entity.Entities
{
    public class Image: EntityBase
    {
        public Image()
        {
            
        }
        public Image(string fileName, string filetype, string createdBy)
        {
            FileName = fileName;
            FileType = filetype;
            CreatedBy = createdBy;
        }
        public string FileName { get; set; }
        public string FileType { get; set; }
        public ICollection<Article> Articles { get; set; }
        public ICollection<AppUser> Users { get; set; }
    }
}
