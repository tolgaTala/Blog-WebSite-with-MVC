using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YoutubeBlog.Entity.Dtos.Categories;
using YoutubeBlog.Entity.Dtos.Roles;
using YoutubeBlog.Entity.Dtos.Users;
using YoutubeBlog.Entity.Entities;

namespace YoutubeBlog.Service.AutoMapper.Users
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<UserDto, AppUser>().ReverseMap();
            CreateMap<UserAddDto, AppUser>().ReverseMap();
            CreateMap<UserUpdateDto, AppUser>().ReverseMap();
            CreateMap<UserProfileDto, AppUser>().ReverseMap();
        }
    }
    
}
