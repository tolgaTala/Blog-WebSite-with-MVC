using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YoutubeBlog.Entity.Dtos.Roles;
using YoutubeBlog.Entity.Entities;

namespace YoutubeBlog.Service.AutoMapper.Roles
{
    public class RoleProfile : Profile
    {
        public RoleProfile()
        {
            CreateMap<RoleDto, AppRole>().ReverseMap();
            CreateMap<RoleAddDto, AppRole>().ReverseMap();
            CreateMap<RoleUpdateDto, AppRole>().ReverseMap();
        }
    }
}
