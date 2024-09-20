using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;
using YoutubeBlog.Entity.Dtos.Discussions;
using YoutubeBlog.Entity.Entities;
using YoutubeBlog.Service.Extensions;
using YoutubeBlog.Service.Services.Abstract;
using YoutubeBlog.Service.Services.Conrete;
using YoutubeBlog.Web.Consts;
using YoutubeBlog.Web.ResultMessages;

namespace YoutubeBlog.Web.Controllers
{
    public class DiscussionController : Controller
    {
        private readonly IDiscussionService discussionService;
        private readonly IMapper mapper;
        private readonly IValidator<Discussion> validator;
        private readonly IToastNotification toastNotification;

        public DiscussionController(IDiscussionService discussionService, IMapper mapper, IValidator<Discussion> validator, IToastNotification toastNotification)
        {
            this.discussionService = discussionService;
            this.mapper = mapper;
            this.validator = validator;
            this.toastNotification = toastNotification;
        }

        [HttpGet]
        public async Task<IActionResult> Index( int currentPage = 1, int pageSize = 4, bool isAscending = false)
        {
            var discussions = await discussionService.GetAllByPagingAsync(currentPage, pageSize, isAscending);
            return View(discussions);
        }

        [HttpGet]
        public async Task<IActionResult> Search(string keyword, int currentPage = 1, int pageSize = 4, bool isAscending = false)
        {
            var discussions = await discussionService.SearchAsync(keyword, currentPage, pageSize, isAscending);
            return View(discussions);
        }

        [HttpGet]
        public async Task<IActionResult> DiscussionDetail(Guid discussionId)
        {
            var discussion = await discussionService.GetDiscussionWithId(discussionId);

            ViewBag.disc = discussion;

            return View(new DiscussionForAddDto { DiscussionId = discussionId });
        }

        [Authorize(Roles = $"{RoleConsts.Superadmin},{RoleConsts.Admin},{RoleConsts.User}")]
        public async Task<IActionResult> HardDelete(Guid discussionId)
        {
            var discussion = await discussionService.HardDeleteDiscussionAsync(discussionId);
            toastNotification.AddSuccessToastMessage(Messages.Article.Delete(discussion.Title), new ToastrOptions { Title = "İşlem Başarılı" });

            return RedirectToAction("MyForum", "UserProfile");
        }

    }
}
