using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using YoutubeBlog.Entity.Entities;

namespace YoutubeBlog.Data.Mappings
{
    public class ArticleMap : IEntityTypeConfiguration<Article>
    {
        public void Configure(EntityTypeBuilder<Article> builder)
        {
            builder.HasData(new Article
            {
                Id = Guid.NewGuid(),
                Title = "Asp.Net Core Deneme Makalesi 1",
                Content = "Asp.Net Core Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
                ViewCount = 10,
                CategoryId = Guid.Parse("EAAD017E-8F3A-4453-8000-F2C7C09B20A3"),
                ImageId = Guid.Parse("30E70875-A0A8-466D-937B-8B325E11B5BB"),
                CreatedBy = "Musa",
                CreatedDate = DateTime.Now,
                UserId = Guid.Parse("D29D4237-D4E1-4FD9-94BA-0195AD4676ED")
            },
            new Article
            {
                Id = Guid.NewGuid(),
                Title = "Visual Studio Deneme Makalesi 1",
                Content = "Visual Studio Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
                ViewCount = 10,
                CategoryId = Guid.Parse("5875664C-4A6F-463D-8032-230A83BDB5BB"),
                ImageId = Guid.Parse("CB2150F3-A4F9-4316-B1C1-A4FE1693FC7E"),
                CreatedBy = "Musa",
                CreatedDate = DateTime.Now,
                UserId = Guid.Parse("D4FEB138-6AF3-4017-B511-FA9662F062F7")
            }
            );
        }
    }
}
