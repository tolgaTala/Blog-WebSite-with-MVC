using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YoutubeBlog.Data.UnitOfWorks;
using YoutubeBlog.Entity.Dtos.SocialMedias;
using YoutubeBlog.Service.Services.Abstract;

namespace YoutubeBlog.Service.Services.Conrete
{
    public class SocialMediaService : ISocialMediaService
    {
        private readonly IUnitOfWork unitOfWork;

        public SocialMediaService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
        }
        public Task CreateSocialMediaAsync(SocialMediaAddDto socialMediaAddDto)
        {
            throw new NotImplementedException();
        }

        public Task<List<SocialMediaDto>> GetAllSocialMediasNonDeleted()
        {
            throw new NotImplementedException();
        }

        public Task<string> UpdateSocialMediaAsync(SocialMediaUpdateDto socialMediaUpdateDto)
        {
            throw new NotImplementedException();
        }
    }
}
