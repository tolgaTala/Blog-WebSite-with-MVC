using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;
using YoutubeBlog.Entity.Dtos.Articles;
using YoutubeBlog.Entity.Dtos.Discussions;
using YoutubeBlog.Entity.Dtos.Users;
using YoutubeBlog.Entity.Entities;
using YoutubeBlog.Service.Extensions;
using YoutubeBlog.Service.Services.Abstract;
using YoutubeBlog.Service.Services.Conrete;
using YoutubeBlog.Web.Consts;
using YoutubeBlog.Web.ResultMessages;


namespace YoutubeBlog.Web.Controllers
{
    public class UserProfileController : Controller
    {
        private readonly IUserService userService;
        private readonly IMapper mapper;
        private readonly IArticleService articleService;
        private readonly IDiscussionService discussionService;
        private readonly ICategoryService categoryService;
        private readonly IValidator<Discussion> discussionValidator;
        private readonly IValidator<AppUser> validator;
        private readonly IValidator<Article> articleValidator;
        private readonly IToastNotification toastNotification;
        private readonly SignInManager<AppUser> signInManager;

        public UserProfileController(IUserService userService, IMapper mapper, IArticleService articleService, IDiscussionService discussionService, ICategoryService categoryService, IValidator<Discussion> discussionValidator, IValidator<AppUser> validator, IValidator<Article> articleValidator, IToastNotification toastNotification, SignInManager<AppUser> signInManager)
        {
            this.userService = userService;
            this.mapper = mapper;
            this.articleService = articleService;
            this.discussionService = discussionService;
            this.categoryService = categoryService;
            this.discussionValidator = discussionValidator;
            this.validator = validator;
            this.articleValidator = articleValidator;
            this.toastNotification = toastNotification;
            this.signInManager = signInManager;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> UserProfile()
        {
            var profile = await userService.GetUserProfileAsync();
            return View(profile);
        }
        [HttpPost]
        public async Task<IActionResult> Profile(UserProfileDto userProfileDto)
        {
            if (ModelState.IsValid)
            {
                var result = await userService.UserProfileUpdateAsync(userProfileDto);
                if (result)
                {
                    toastNotification.AddSuccessToastMessage("Profil güncelleme işlemi tamamlandı", new ToastrOptions { Title = "İşlem Başarılı" });
                    return RedirectToAction("UserProfile", "UserProfile");
                }
                else
                {
                    var profile = await userService.GetUserProfileAsync();
                    toastNotification.AddErrorToastMessage("Profil güncelleme işlemi tamamlanamadı", new ToastrOptions { Title = "İşlem Başarısız" });
                    return View(profile);
                }
            }
            else
                return NotFound();
        }
        [HttpGet]
        public IActionResult UserSignIn()
        {            
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> UserSignIn(UserAddDto userAddDto)
        {
            userAddDto.RoleId = Guid.Parse("4e165977-367f-4cf1-9a4b-31304bbb2154");
            var map = mapper.Map<AppUser>(userAddDto);
            var validation = await validator.ValidateAsync(map);
            if (validation.IsValid)
            {
                var result = await userService.CreateUserAsync(userAddDto);
                if (result.Succeeded)
                {
                    var signInUser = await userService.GetAppUserByEmailAsync(map.Email);
                    await signInManager.SignInAsync(signInUser,false);
                    toastNotification.AddSuccessToastMessage(Messages.User.Add(userAddDto.Email), new ToastrOptions { Title = "İşlem Başarılı" });
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    result.AddToIdentityModelState(ModelState);
                    validation.AddToModelState(ModelState);
                    return View();
                }
            }
            validation.AddToModelState(ModelState);
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> MyArticles()
        {
            var articles = await userService.GetUserArticles();
            return View(articles);
        }
        [HttpGet]
        public async Task<IActionResult> MyForum()
        {
            var forum = await userService.GetUserForum();
            return View(forum);
        }
        
        [HttpGet]
        public async Task<IActionResult> MyComments()
        {
            var forum = await userService.GetUserComments();
            return View(forum);
        }

        [HttpGet]
        [Authorize(Roles = $"{RoleConsts.Superadmin},{RoleConsts.Admin},{RoleConsts.User}")]
        public async Task<IActionResult> AddForum()
        {
            return View();
        }
        [HttpPost]
        [Authorize(Roles = $"{RoleConsts.Superadmin},{RoleConsts.Admin},{RoleConsts.User}")]
        public async Task<IActionResult> AddForum(DiscussionAddDto discussionAddDto)
        {
            var map = mapper.Map<Discussion>(discussionAddDto);
            var result = await discussionValidator.ValidateAsync(map);

            if (result.IsValid)
            {
                await discussionService.CreateDiscussionAsnyc(discussionAddDto);
                toastNotification.AddSuccessToastMessage(Messages.Article.Add(discussionAddDto.Title), new ToastrOptions { Title = "Başarılı!" });
                return RedirectToAction("MyForum", "UserProfile");
            }
            else
            {
                result.AddToModelState(this.ModelState);
                return View();
            }
        }

        [HttpGet]
        [Authorize(Roles = $"{RoleConsts.User},{RoleConsts.Admin},{RoleConsts.Superadmin}")]
        public async Task<IActionResult> MyDeletedArticles()
        {
            var articles = await userService.GetDeletedArticles();
            return View(articles);
        }

        [HttpGet]
        [Authorize(Roles = $"{RoleConsts.User},{RoleConsts.Admin},{RoleConsts.Superadmin}")]
        public async Task<IActionResult> AddArticle()
        {
            var categories = await categoryService.GetAllCategoriesNonDeleted();
            return View(new ArticleAddDto { Categories = categories });
        }
        [HttpPost]
        [Authorize(Roles = $"{RoleConsts.User},{RoleConsts.Admin},{RoleConsts.Superadmin}")]
        public async Task<IActionResult> AddArticle(ArticleAddDto articleAddDto)
        {
            var map = mapper.Map<Article>(articleAddDto);
            var result = await articleValidator.ValidateAsync(map);

            if (result.IsValid)
            {
                await articleService.CreateArticleAsnyc(articleAddDto);
                toastNotification.AddSuccessToastMessage(Messages.Article.Add(articleAddDto.Title), new ToastrOptions { Title = "Başarılı!" });
                return RedirectToAction("MyArticles", "UserProfile");
            }
            else
            {
                result.AddToModelState(this.ModelState);
                var categories = await categoryService.GetAllCategoriesNonDeleted();
                return View(new ArticleAddDto { Categories = categories });
            }
        }

        [HttpGet]
        [Authorize(Roles = $"{RoleConsts.User},{RoleConsts.Admin},{RoleConsts.Superadmin}")]
        public async Task<IActionResult> UpdateArticle(Guid articleId)
        {
            var article = await articleService.GetArticleWithCategoryNonDeletedAsync(articleId);
            var categories = await categoryService.GetAllCategoriesNonDeleted();

            var articleUpdateDto = mapper.Map<ArticleUpdateDto>(article);
            articleUpdateDto.Categories = categories;

            return View(articleUpdateDto);
        }
        [HttpPost]
        [Authorize(Roles = $"{RoleConsts.User},{RoleConsts.Admin},{RoleConsts.Superadmin}")]
        public async Task<IActionResult> UpdateArticle(ArticleUpdateDto articleUpdateDto)
        {
            var map = mapper.Map<Article>(articleUpdateDto);
            var result = await articleValidator.ValidateAsync(map);

            if (result.IsValid)
            {
                var title = await articleService.UpdateArticleAsync(articleUpdateDto);
                toastNotification.AddSuccessToastMessage(Messages.Article.Update(title), new ToastrOptions { Title = "İşlem Başarılı" });
                return RedirectToAction("MyArticles", "UserProfile");
            }
            else
            {
                result.AddToModelState(this.ModelState);

            }

            var categories = await categoryService.GetAllCategoriesNonDeleted();

            articleUpdateDto.Categories = categories;

            return View(articleUpdateDto);
        }
        [Authorize(Roles = $"{RoleConsts.User},{RoleConsts.Admin},{RoleConsts.Superadmin}")]
        public async Task<IActionResult> Delete(Guid articleId)
        {
            var title = await articleService.SafeDeleteArticleAsync(articleId);
            toastNotification.AddSuccessToastMessage(Messages.Article.Delete(title), new ToastrOptions { Title = "İşlem Başarılı" });

            return RedirectToAction("MyArticles", "UserProfile");
        }
        [Authorize(Roles = $"{RoleConsts.User},{RoleConsts.Admin},{RoleConsts.Superadmin}")]
        public async Task<IActionResult> UndoDelete(Guid articleId)
        {
            var title = await articleService.UndoDeleteArticleAsync(articleId);
            toastNotification.AddSuccessToastMessage(Messages.Article.UndoDelete(title), new ToastrOptions { Title = "İşlem Başarılı" });

            return RedirectToAction("MyArticles", "UserProfile");
        }
    }


}
