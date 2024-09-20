using Microsoft.AspNetCore.Mvc;
using YoutubeBlog.Service.Services.Abstract;
using YoutubeBlog.Service.Services.Conrete;

namespace YoutubeBlog.Web.ViewComponents
{
    public class HomeRecentArticlesViewComponent : ViewComponent
    {
        private readonly IArticleService articleService;

        public HomeRecentArticlesViewComponent(IArticleService articleService)
        {
            this.articleService = articleService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var recentArticles = await articleService.GetRecentArticles();
            return View(recentArticles);
        }
    }
}
