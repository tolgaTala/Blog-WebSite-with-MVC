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

namespace YoutubeBlog.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DiscussionForController : Controller
    {
        private readonly IDiscussionForService discussionForService;
        private readonly IMapper mapper;
        private readonly IValidator<DiscussionFor> validator;
        private readonly IToastNotification toastNotification;

        public DiscussionForController(IDiscussionForService discussionForService, IMapper mapper, IValidator<DiscussionFor> validator, IToastNotification toastNotification)
        {
            this.discussionForService = discussionForService;
            this.mapper = mapper;
            this.validator = validator;
            this.toastNotification = toastNotification;
        }
        [HttpGet]
        [Authorize(Roles = $"{RoleConsts.Superadmin},{RoleConsts.Admin}, {RoleConsts.User}")]
        public async Task<IActionResult> Index()
        {
            var discuss = await discussionForService.GetAllNonDeletedDiscussionFors();
            var sortedList = discuss.OrderBy(item => item.CreatedDate).ToList();
            return View(sortedList);
        }
        [HttpGet]
        [Authorize(Roles = $"{RoleConsts.Superadmin},{RoleConsts.Admin}, {RoleConsts.User}")]
        public async Task<IActionResult> DeletedDiscussionFors()
        {
            var discussions = await discussionForService.GetAllDeletedDiscussionFors();

            return View(discussions);
        }

        [HttpGet]
        [Authorize(Roles = $"{RoleConsts.Superadmin},{RoleConsts.Admin}")]
        public async Task<IActionResult> Add(Guid discussionId)
        {           
            return View(new DiscussionForAddDto { DiscussionId = discussionId});           
        }
        [HttpPost]
        [Authorize(Roles = $"{RoleConsts.Superadmin},{RoleConsts.Admin}")]
        public async Task<IActionResult> Add(DiscussionForAddDto discussionAddDto)
        {
            var map = mapper.Map<DiscussionFor>(discussionAddDto);
            var result = await validator.ValidateAsync(map);

            if (result.IsValid)
            {
                await discussionForService.CreateDiscussionForAsnyc(discussionAddDto);
                toastNotification.AddSuccessToastMessage("Yorumunuz", new ToastrOptions { Title = "Başarılı!" });
                return RedirectToAction("DiscussionDetail", "Discussion", new { Area = "Admin" , DiscussionId = discussionAddDto.DiscussionId});
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
            var discussion = await discussionForService.GetDiscussionForWithId(discussionId);

            var discussionUpdateDto = mapper.Map<DiscussionForUpdateDto>(discussion);

            return View(discussionUpdateDto);
        }
        [HttpPost]
        [Authorize(Roles = $"{RoleConsts.Superadmin},{RoleConsts.Admin}")]
        public async Task<IActionResult> Update(DiscussionForUpdateDto discussionUpdateDto)
        {
            var map = mapper.Map<DiscussionFor>(discussionUpdateDto);
            var result = await validator.ValidateAsync(map);

            if (result.IsValid)
            {
                var discus = await discussionForService.UpdateDiscussionForAsync(discussionUpdateDto);
                toastNotification.AddSuccessToastMessage(Messages.Article.Update(discus.Content), new ToastrOptions { Title = "İşlem Başarılı" });
                return RedirectToAction("DiscussionDetail", "Discussion", new { Area = "Admin", DiscussionId = discus.DiscussionId });
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
            var discussionFor = await discussionForService.SafeDeleteDiscussionForAsync(discussionId);
            toastNotification.AddSuccessToastMessage(Messages.Article.Delete(discussionFor.Content), new ToastrOptions { Title = "İşlem Başarılı" });

            return RedirectToAction("DiscussionDetail", "Discussion", new { Area = "Admin", DiscussionId = discussionFor.DiscussionId });
        }

        [Authorize(Roles = $"{RoleConsts.Superadmin},{RoleConsts.Admin}")]
        public async Task<IActionResult> UndoDelete(Guid discussionId)
        {
            var discussion = await discussionForService.UndoDeleteDiscussionForAsync(discussionId);
            toastNotification.AddSuccessToastMessage(Messages.Article.UndoDelete(discussion.Content), new ToastrOptions { Title = "İşlem Başarılı" });

            return RedirectToAction("DiscussionDetail", "Discussion", new { Area = "Admin", DiscussionId = discussion.DiscussionId });
        }
    }
}
