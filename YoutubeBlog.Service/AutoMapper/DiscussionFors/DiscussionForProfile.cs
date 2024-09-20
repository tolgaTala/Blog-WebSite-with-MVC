using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YoutubeBlog.Entity.Dtos.Discussions;
using YoutubeBlog.Entity.Entities;

namespace YoutubeBlog.Service.AutoMapper.DiscussionFors
{
    public class DiscussionForProfile : Profile
    {
        public DiscussionForProfile()
        {
            CreateMap<DiscussionForDto, DiscussionFor>().ReverseMap();
            CreateMap<DiscussionForUpdateDto, DiscussionFor>().ReverseMap();
            CreateMap<DiscussionForUpdateDto, DiscussionForDto>().ReverseMap();
            CreateMap<DiscussionForAddDto, DiscussionFor>().ReverseMap();
        }
    }
}
