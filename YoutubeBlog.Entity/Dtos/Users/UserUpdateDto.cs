﻿using YoutubeBlog.Entity.Entities;

namespace YoutubeBlog.Entity.Dtos.Users
{
    public class UserUpdateDto
    {
        public Guid Id { get; set; } 
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public Guid RoleId { get; set; }
        public List<AppRole> Roles { get; set; }
    }
}
