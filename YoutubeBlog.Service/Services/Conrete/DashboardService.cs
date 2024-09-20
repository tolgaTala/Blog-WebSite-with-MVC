using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YoutubeBlog.Data.UnitOfWorks;
using YoutubeBlog.Entity.Entities;
using YoutubeBlog.Service.Services.Abstract;

namespace YoutubeBlog.Service.Services.Conrete
{
    public class DashboardService : IDashboardService
    {
        private readonly IUnitOfWork unitOfWork;

        public DashboardService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<List<int>> GetYearlyArticleCounts()
        {
            var articles = await unitOfWork.GetRepository<Article>().GetAllAsync(x => !x.IsDeleted);
            var startDate = DateTime.Now.Date;
            startDate = new DateTime(startDate.Year, 1, 1);

            List<int> datas = new();

            for (var i = 1; i <= 12 ; i++)
            {
                var startedDate = new DateTime(startDate.Year, i, 1);
                var endedDate = startDate.AddMonths(1);
                var data = articles.Where(x=>x.CreatedDate >= startedDate && x.CreatedDate < endedDate).Count();
                datas.Add(data);
            }
            return datas;
        }
        public async Task<int> GetTotalArticleCount()
        {
            var articleCount = await unitOfWork.GetRepository<Article>().CountAsync();
            return articleCount;
        }
        public async Task<int> GetTotalCategoryCount()
        {
            var categoryCount = await unitOfWork.GetRepository<Category>().CountAsync();
            return categoryCount;
        }
        public async Task<int> GetTotalUserCount()
        {
            var userCount = await unitOfWork.GetRepository<AppUser>().CountAsync();
            return userCount;
        }
        public async Task<int> GetTotalForumCount()
        {
            var forumCount = await unitOfWork.GetRepository<Discussion>().CountAsync();
            return forumCount;
        }
        public async Task<int> GetTotalCommentCount()
        {
            var forumCount = await unitOfWork.GetRepository<DiscussionFor>().CountAsync();
            return forumCount;
        }
    }
}
