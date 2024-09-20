using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YoutubeBlog.Entity.Dtos.Articles;
using YoutubeBlog.Entity.Dtos.Discussions;
using YoutubeBlog.Entity.Entities;

namespace YoutubeBlog.Service.AutoMapper.Discussions
{
    public class DiscussionProfile : Profile
    {
        public DiscussionProfile()
        {
            CreateMap<DiscussionDto, Discussion>().ReverseMap();
            CreateMap<DiscussionUpdateDto, Discussion>().ReverseMap();
            CreateMap<DiscussionUpdateDto, DiscussionDto>().ReverseMap();
            CreateMap<DiscussionAddDto, Discussion>().ReverseMap();
        }
    }
}
