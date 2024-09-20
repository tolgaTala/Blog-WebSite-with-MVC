using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using YoutubeBlog.Service.Services.Abstract;
using YoutubeBlog.Web.Consts;

namespace YoutubeBlog.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class HomeController : Controller
    {
        private readonly IArticleService articleService;
        private readonly IDashboardService dashboardService;

        public HomeController(IArticleService articleService, IDashboardService dashboardService)
        {
            this.articleService = articleService;
            this.dashboardService = dashboardService;
        }
        [Authorize(Roles = $"{RoleConsts.Superadmin}")]
        public async Task<IActionResult> Index()
        {
            var articles = await articleService.GetAllArticleWithCategoryNonDeletedAsync();
            var result = await dashboardService.GetYearlyArticleCounts();
            return View(articles);
        }
        [HttpGet]
        public async Task<IActionResult> YearlyArticlesCounts()
        {
            var count = await dashboardService.GetYearlyArticleCounts();
            return Json(JsonConvert.SerializeObject(count));
        }

        [HttpGet]
        public async Task<IActionResult> TotalArticleCount()
        {
            var count = await dashboardService.GetTotalArticleCount();
            return Json(count);
        }

        [HttpGet]
        public async Task<IActionResult> TotalCategoryCount()
        {
            var count = await dashboardService.GetTotalCategoryCount();
            return Json(count);
        }

        [HttpGet]
        public async Task<IActionResult> TotalUserCount()
        {
            var count = await dashboardService.GetTotalUserCount();
            return Json(count);
        }
        
        [HttpGet]
        public async Task<IActionResult> TotalForumCount()
        {
            var count = await dashboardService.GetTotalForumCount();
            return Json(count);
        }

        [HttpGet]
        public async Task<IActionResult> TotalCommentCount()
        {
            var count = await dashboardService.GetTotalCommentCount();
            return Json(count);
        }
    }
}
