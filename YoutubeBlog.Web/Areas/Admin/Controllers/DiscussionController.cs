using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;
using YoutubeBlog.Entity.Dtos.Articles;
using YoutubeBlog.Entity.Dtos.Discussions;
using YoutubeBlog.Entity.Entities;
using YoutubeBlog.Service.Extensions;
using YoutubeBlog.Service.Services.Abstract;
using YoutubeBlog.Service.Services.Conrete;
using YoutubeBlog.Web.Consts;
using YoutubeBlog.Web.ResultMessages;
using static YoutubeBlog.Web.ResultMessages.Messages;

namespace YoutubeBlog.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
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
        [Authorize(Roles = $"{RoleConsts.Superadmin},{RoleConsts.Admin}, {RoleConsts.User}")]
        public async Task<IActionResult> Index()
        {
            var discussions = await discussionService.GetAllNonDeletedDiscussions();
            return View(discussions);
        }
        [HttpGet]
        [Authorize(Roles = $"{RoleConsts.Superadmin},{RoleConsts.Admin}, {RoleConsts.User}")]
        public async Task<IActionResult> DeletedDiscussions()
        {
            var discussions = await discussionService.GetAllDeletedDiscussions();
            return View(discussions);
        }

        [HttpGet]
        [Authorize(Roles = $"{RoleConsts.Superadmin},{RoleConsts.Admin}")]
        public async Task<IActionResult> Add()
        {
            return View();
        }
        [HttpPost]
        [Authorize(Roles = $"{RoleConsts.Superadmin},{RoleConsts.Admin}")]
        public async Task<IActionResult> Add(DiscussionAddDto discussionAddDto)
        {
            var map = mapper.Map<Discussion>(discussionAddDto);
            var result = await validator.ValidateAsync(map);

            if (result.IsValid)
            {
                await discussionService.CreateDiscussionAsnyc(discussionAddDto);
                toastNotification.AddSuccessToastMessage(Messages.Article.Add(discussionAddDto.Title), new ToastrOptions { Title = "Başarılı!" });
                return RedirectToAction("Index", "Discussion", new { Area = "Admin" });
            }
            else
            {
                result.AddToModelState(this.ModelState);
                return View();
            }
        }
        [HttpGet]
        [Authorize(Roles = $"{RoleConsts.Superadmin},{RoleConsts.Admin}")]
        public async Task<IActionResult> Update(Guid discussionId)
        {
            var discussion = await discussionService.GetDiscussionWithId(discussionId);

            var discussionUpdateDto = mapper.Map<DiscussionUpdateDto>(discussion);

            return View(discussionUpdateDto);
        }
        [HttpPost]
        [Authorize(Roles = $"{RoleConsts.Superadmin},{RoleConsts.Admin}")]
        public async Task<IActionResult> Update(DiscussionUpdateDto discussionUpdateDto)
        {
            var map = mapper.Map<Discussion>(discussionUpdateDto);
            var result = await validator.ValidateAsync(map);

            if (result.IsValid)
            {
                var title = await discussionService.UpdateDiscussionAsync(discussionUpdateDto);
                toastNotification.AddSuccessToastMessage(Messages.Article.Update(title), new ToastrOptions { Title = "İşlem Başarılı" });
                return RedirectToAction("Index", "Discussion", new { Area = "Admin" });
            }
            else
            {
                result.AddToModelState(this.ModelState);
            }
            return View(discussionUpdateDto);
        }

        [Authorize(Roles = $"{RoleConsts.Superadmin},{RoleConsts.Admin}")]
        public async Task<IActionResult> Delete(Guid discussionId)
        {
            var title = await discussionService.SafeDeleteDiscussionAsync(discussionId);
            toastNotification.AddSuccessToastMessage(Messages.Article.Delete(title), new ToastrOptions { Title = "İşlem Başarılı" });

            return RedirectToAction("Index", "Discussion", new { Area = "Admin" });
        }
        [Authorize(Roles = $"{RoleConsts.Superadmin}")]
        public async Task<IActionResult> HardDelete(Guid discussionId)
        {
            var discussion = await discussionService.HardDeleteDiscussionAsync(discussionId);
            toastNotification.AddSuccessToastMessage(Messages.Article.Delete(discussion.Title), new ToastrOptions { Title = "İşlem Başarılı" });

            return RedirectToAction("Index", "Discussion", new { Area = "Admin" });
        }

        [Authorize(Roles = $"{RoleConsts.Superadmin},{RoleConsts.Admin}")]
        public async Task<IActionResult> UndoDelete(Guid discussionId)
        {
            var title = await discussionService.UndoDeleteDiscussionAsync(discussionId);
            toastNotification.AddSuccessToastMessage(Messages.Article.UndoDelete(title), new ToastrOptions { Title = "İşlem Başarılı" });

            return RedirectToAction("DeletedDiscussions", "Discussion", new { Area = "Admin" });
        }
        [HttpGet]
        [Authorize(Roles = $"{RoleConsts.Superadmin},{RoleConsts.Admin}, {RoleConsts.User}")]
        public async Task<IActionResult> DiscussionDetail(Guid discussionId)
        {            
            var discussion = await discussionService.GetDiscussionWithId(discussionId);
            return View(discussion);
        }
    }
}
