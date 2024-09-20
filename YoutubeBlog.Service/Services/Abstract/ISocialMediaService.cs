using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YoutubeBlog.Entity.Dtos.Categories;
using YoutubeBlog.Entity.Dtos.SocialMedias;

namespace YoutubeBlog.Service.Services.Abstract
{
    public interface ISocialMediaService
    {
        Task CreateSocialMediaAsync(SocialMediaAddDto socialMediaAddDto);
        Task<List<SocialMediaDto>> GetAllSocialMediasNonDeleted();
        Task<string> UpdateSocialMediaAsync(SocialMediaUpdateDto socialMediaUpdateDto);
    }
}
