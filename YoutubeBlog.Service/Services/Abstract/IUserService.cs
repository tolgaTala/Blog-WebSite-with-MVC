using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YoutubeBlog.Entity.Dtos.Articles;
using YoutubeBlog.Entity.Dtos.Discussions;
using YoutubeBlog.Entity.Dtos.Users;
using YoutubeBlog.Entity.Entities;

namespace YoutubeBlog.Service.Services.Abstract
{
    public interface IUserService
    {
        Task<List<UserDto>> GetlAllUsersWithRoleAsync();
        Task<List<AppRole>> GetlAllRolesAsync();
        Task<IdentityResult> CreateUserAsync(UserAddDto userAddDto);
        Task<IdentityResult> UpdateUserAsync(UserUpdateDto userUpdateDto);
        Task<(IdentityResult identityResult,string? email)> DeleteUserAsync(Guid userId);
        Task<AppUser> GetappUserByIdAsync(Guid userId);
        Task<AppUser> GetAppUserByEmailAsync(string email);
        Task<string> GetUserRoleAsync(AppUser appUser);
        Task<UserProfileDto> GetUserProfileAsync();
        Task<bool> UserProfileUpdateAsync(UserProfileDto userProfileDto);
        Task<List<ArticleDto>> GetUserArticles();
        Task<List<DiscussionDto>> GetUserForum();
        Task<List<DiscussionDto>> GetUserComments();
        Task<List<ArticleDto>> GetDeletedArticles();
        Task CreateArticleForUserAsnyc(ArticleAddDto articleAddDto);
    }
}
