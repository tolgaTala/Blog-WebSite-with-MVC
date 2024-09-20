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
    public class DiscussionForController : Controller
    {
        private readonly IDiscussionForService discussionForService;
        private readonly IMapper mapper;
        private readonly IValidator<DiscussionFor> validator;
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly IToastNotification toastNotification;

        public DiscussionForController(IDiscussionForService discussionForService, IMapper mapper, IValidator<DiscussionFor> validator, IHttpContextAccessor httpContextAccessor, IToastNotification toastNotification)
        {
            this.discussionForService = discussionForService;
            this.mapper = mapper;
            this.validator = validator;
            this.httpContextAccessor = httpContextAccessor;
            this.toastNotification = toastNotification;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Comment(DiscussionForAddDto discussionAddDto)
        {
            var map = mapper.Map<DiscussionFor>(discussionAddDto);
            var result = await validator.ValidateAsync(map);

            if (result.IsValid)
            {
                await discussionForService.CreateDiscussionForAsnyc(discussionAddDto);
                toastNotification.AddSuccessToastMessage(Messages.Article.Add(discussionAddDto.Content), new ToastrOptions { Title = "Başarılı!" });
                return RedirectToAction("DiscussionDetail", "Discussion", new { DiscussionId = discussionAddDto.DiscussionId });
            }
            else
            {
                result.AddToModelState(this.ModelState);
                return View();
            }
            
        }

        public async Task<IActionResult> HardDelete(Guid discussionId)
        {
            var discussion = await discussionForService.HardDeleteDiscussionAsync(discussionId);
            toastNotification.AddSuccessToastMessage(Messages.Article.Delete(discussion.Content), new ToastrOptions { Title = "İşlem Başarılı" });

            return RedirectToAction("MyComments", "UserProfile");
        }
    }
}
