using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using YoutubeBlog.Data.UnitOfWorks;
using YoutubeBlog.Entity.Dtos.Users;
using YoutubeBlog.Entity.Entities;

namespace YoutubeBlog.Web.ViewComponents
{
    public class UserProfileViewComponent : ViewComponent
    {
        private readonly UserManager<AppUser> userManager;
        private readonly IMapper mapper;
        private readonly IUnitOfWork unitOfWork;

        public UserProfileViewComponent(UserManager<AppUser> userManager, IMapper mapper,IUnitOfWork unitOfWork)
        {
            this.userManager = userManager;
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var loggedInUser = await userManager.GetUserAsync(HttpContext.User);
            var map = mapper.Map<UserDto>(loggedInUser);
            if (loggedInUser!=null)
            {
                var role = string.Join("", await userManager.GetRolesAsync(loggedInUser));
                var image = await unitOfWork.GetRepository<Image>().GetAsync(x => x.Id == loggedInUser.ImageId);
                map.Role = role;
                map.Image = image;
            }            
            
            return View(map);
        }
    }
}
