using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YoutubeBlog.Entity.Entities;

namespace YoutubeBlog.Data.Mappings
{
    public class ImageMap : IEntityTypeConfiguration<Image>
    {
        public void Configure(EntityTypeBuilder<Image> builder)
        {
            builder.HasData(new Image
            {
                Id = Guid.Parse("CB2150F3-A4F9-4316-B1C1-A4FE1693FC7E"),
                FileName = "images/vstest",
                FileType = "png",
                CreatedBy = "Admin Test",
                CreatedDate = DateTime.Now,
                IsDeleted = false
            },
            new Image
            {
                Id = Guid.Parse("30E70875-A0A8-466D-937B-8B325E11B5BB"),
                FileName = "images/testImage",
                FileType = "jpg",
                CreatedBy = "Admin Test",
                CreatedDate = DateTime.Now,
                IsDeleted = false
            });
        }
    }
}
