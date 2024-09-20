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
    public class CategoryMap : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasData(new Category
            {
                Id = Guid.Parse("5875664C-4A6F-463D-8032-230A83BDB5BB"),
                Name = "Visual Studio 2022",
                CreatedBy = "Admin Test",
                CreatedDate = DateTime.Now,
                IsDeleted = false
            },
            new Category
            {
                Id = Guid.Parse("EAAD017E-8F3A-4453-8000-F2C7C09B20A3"),
                Name = "ASP.Net Core",
                CreatedBy = "Admin Test",
                CreatedDate = DateTime.Now,
                IsDeleted = false
            });
        }
    }
}
