using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using YoutubeBlog.Data.UnitOfWorks;
using YoutubeBlog.Entity.Dtos.Articles;
using YoutubeBlog.Entity.Dtos.Discussions;
using YoutubeBlog.Entity.Dtos.Users;
using YoutubeBlog.Entity.Entities;
using YoutubeBlog.Entity.Enums;
using YoutubeBlog.Service.Extensions;
using YoutubeBlog.Service.Helpers.Images;
using YoutubeBlog.Service.Services.Abstract;

namespace YoutubeBlog.Service.Services.Conrete
{
    public class UserService : IUserService
    {
        private readonly IMapper mapper;
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly IImageHelper imageHelper;
        private readonly IUnitOfWork unitOfWork;
        private readonly UserManager<AppUser> userManager;
        private readonly SignInManager<AppUser> signInManager;
        private readonly RoleManager<AppRole> roleManager;
        private readonly ClaimsPrincipal _user;

        public UserService(IMapper mapper, IHttpContextAccessor httpContextAccessor, IImageHelper imageHelper, IUnitOfWork unitOfWork,UserManager<AppUser> userManager,SignInManager<AppUser> signInManager,RoleManager<AppRole> roleManager) 
        {
            this.mapper = mapper;
            this.httpContextAccessor = httpContextAccessor;
            this.imageHelper = imageHelper;
            _user = httpContextAccessor.HttpContext.User;
            this.unitOfWork = unitOfWork;
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.roleManager = roleManager;
        }

        public async Task<IdentityResult> CreateUserAsync(UserAddDto userAddDto)
        {
            var map = mapper.Map<AppUser>(userAddDto);
            map.UserName = userAddDto.Email;
            var result = await userManager.CreateAsync(map, string.IsNullOrEmpty(userAddDto.Password) ? "" : userAddDto.Password);
            if (result.Succeeded)
            {
                var findRole = await roleManager.FindByIdAsync(userAddDto.RoleId.ToString());
                await userManager.AddToRoleAsync(map, findRole.ToString());
                return result;
            }
            else
                return result;

        }

        public async Task<(IdentityResult identityResult, string? email)> DeleteUserAsync(Guid userId)
        {
            var user = await GetappUserByIdAsync(userId);
            var result = await userManager.DeleteAsync(user);
            if (result.Succeeded)
                return (result,user.Email);
            else
                return (result, null);
        }

        public async Task<AppUser> GetappUserByIdAsync(Guid userId)
        {
            return await userManager.FindByIdAsync(userId.ToString());
        }

        public async Task<List<AppRole>> GetlAllRolesAsync()
        {
            return await roleManager.Roles.ToListAsync();
        }

        public async Task<List<UserDto>> GetlAllUsersWithRoleAsync()
        {
            var users = await userManager.Users.ToListAsync();
            var map = mapper.Map<List<UserDto>>(users);

            foreach (var user in map)
            {

                var findUser = await userManager.FindByIdAsync(user.Id.ToString());
                var role = string.Join("", await userManager.GetRolesAsync(findUser));

                user.Role = role;
            }
            return map;
        }

        public async Task<string> GetUserRoleAsync(AppUser appUser)
        {
            return string.Join("", await userManager.GetRolesAsync(appUser));
        }

        public async Task<IdentityResult> UpdateUserAsync(UserUpdateDto userUpdateDto)
        {
            var user = await GetappUserByIdAsync(userUpdateDto.Id);
            var userRole = await GetUserRoleAsync(user);

            var result = await userManager.UpdateAsync(user);
            if (result.Succeeded)
            {
                await userManager.RemoveFromRoleAsync(user, userRole);
                var findRole = await roleManager.FindByIdAsync(userUpdateDto.RoleId.ToString());
                await userManager.AddToRoleAsync(user, findRole.Name);
                return result;
            }
            else
                return result;
        }
        public async Task<UserProfileDto> GetUserProfileAsync()
        {
            var userId = _user.GetLoggedInUserId();
            var getUserWithImage = await unitOfWork.GetRepository<AppUser>().GetAsync(x => x.Id == userId, x => x.Image);
            var map = mapper.Map<UserProfileDto>(getUserWithImage);
            map.Image.FileName = getUserWithImage.Image.FileName;
            return map;
        }
        private async Task<Guid> UploadImageForUser (UserProfileDto userProfileDto) 
        {
            var userEmail = _user.GetLoggedInEmail();
            var imageUpload = await imageHelper.Upload($"{userProfileDto.FirstName}{userProfileDto.LastName}", userProfileDto.Photo, ImageType.User);
            Image image = new(imageUpload.FullName, userProfileDto.Photo.ContentType, userEmail);
            await unitOfWork.GetRepository<Image>().AddAsync(image);
            return image.Id;
        }
        public async Task<bool> UserProfileUpdateAsync(UserProfileDto userProfileDto)
        {
            var userId = _user.GetLoggedInUserId();
            var user = await GetappUserByIdAsync(userId);
            var isVerified = await userManager.CheckPasswordAsync(user, userProfileDto.CurrentPassword);
            if (isVerified && userProfileDto.NewPassword != null )
            {
                var result = await userManager.ChangePasswordAsync(user, userProfileDto.CurrentPassword, userProfileDto.NewPassword);
                if (result.Succeeded)
                {
                    await userManager.UpdateSecurityStampAsync(user);
                    await signInManager.SignOutAsync();
                    await signInManager.PasswordSignInAsync(user, userProfileDto.NewPassword, true, false);

                    var oldImageId = user.ImageId;
                    mapper.Map(userProfileDto, user);
                    if (userProfileDto.Photo != null)
                        user.ImageId = await UploadImageForUser(userProfileDto);
                    else
                        user.ImageId = oldImageId;

                    await userManager.UpdateAsync(user);

                    await unitOfWork.SaveAsync();

                    return true;
                }
                else
                {
                    return false;
                }
            }
            else if (isVerified)
            {
                await userManager.UpdateSecurityStampAsync(user);

                var oldImageId = user.ImageId;
                mapper.Map(userProfileDto, user);
                if (userProfileDto.Photo != null)
                    user.ImageId = await UploadImageForUser(userProfileDto);
                else
                    user.ImageId = oldImageId;

                await userManager.UpdateAsync(user);

                await unitOfWork.SaveAsync();

                return true;
            }

            else
            {
                return false;
            }
        }

        public async Task<AppUser> GetAppUserByEmailAsync(string email)
        {
            return await userManager.FindByEmailAsync(email);
        }

        public async Task<List<ArticleDto>> GetUserArticles()
        {
            var userId = _user.GetLoggedInUserId();
            var articles = await unitOfWork.GetRepository<Article>().GetAllAsync(x => !x.IsDeleted && x.UserId == userId, x => x.Category);
            var map = mapper.Map<List<ArticleDto>>(articles);
            return map;
        }

        public async Task CreateArticleForUserAsnyc(ArticleAddDto articleAddDto)
        {
            var userId = _user.GetLoggedInUserId();
            var userEmail = _user.GetLoggedInEmail();

            var imageUpload = await imageHelper.Upload(articleAddDto.Title, articleAddDto.Photo, ImageType.Post);
            Image image = new(imageUpload.FullName, articleAddDto.Photo.ContentType, userEmail);
            await unitOfWork.GetRepository<Image>().AddAsync(image);

            var article = new Article(articleAddDto.Title, articleAddDto.Content, userId, userEmail, articleAddDto.CategoryId, image.Id);

            await unitOfWork.GetRepository<Article>().AddAsync(article);
            await unitOfWork.SaveAsync();
        }

        public async Task<List<ArticleDto>> GetDeletedArticles()
        {
            var userId = _user.GetLoggedInUserId();
            var articles = await unitOfWork.GetRepository<Article>().GetAllAsync(x => x.IsDeleted && x.UserId == userId, x => x.Category);
            var map = mapper.Map<List<ArticleDto>>(articles);
            return map;
        }

        public async Task<List<DiscussionDto>> GetUserForum()
        {
            var userId = _user.GetLoggedInUserId();
            var forum = await unitOfWork.GetRepository<Discussion>().GetAllAsync(x=>!x.IsDeleted && x.UserId == userId ,d=>d.DiscussionFors, u=>u.User , i=>i.User.Image);
            var map = mapper.Map<List<DiscussionDto>>(forum);
            return map;
        }

		public async Task<List<DiscussionDto>> GetUserComments()
		{
			var userId = _user.GetLoggedInUserId();
			var forum = await unitOfWork.GetRepository<Discussion>().GetAllAsync(x => !x.IsDeleted, d => d.DiscussionFors, u => u.User, i => i.User.Image);
			foreach (var discussion in forum.ToList())
			{
				foreach (var item in discussion.DiscussionFors)
				{
					var item2 = await unitOfWork.GetRepository<DiscussionFor>().GetAsync(x => x.Id == item.Id, u => u.User, i => i.User.Image);

					if (item2.User.Id == userId)
					{
						item.User = item2.User;
					}
					else
					{
						discussion.DiscussionFors.Remove(item);
					}
				}
				if (discussion.DiscussionFors.Count > 0)
                {
                    continue;
				}
                else { 
                    forum.Remove(discussion);
                }
			}
			var map = mapper.Map<List<DiscussionDto>>(forum);
			return map;
		}
	}
}
