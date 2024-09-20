using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YoutubeBlog.Entity.Dtos.Articles;
using YoutubeBlog.Entity.Entities;

namespace YoutubeBlog.Service.Services.Abstract
{
    public interface IArticleService
    {
        Task<List<ArticleDto>> GetAllArticleWithCategoryNonDeletedAsync();
        Task<List<ArticleDto>> GetAllDeletedArticles();
        Task<List<ArticleDto>> GetRecentArticles();
        Task<ArticleListDto> GetAllByPagingAsync(Guid? categoryId, int currentPage = 1, int pageSize = 3, bool isAscending = false);
        Task<ArticleListDto> SearchAsync(string keyword, int currentPage = 1, int pageSize = 3, bool isAscending = false);
        Task<ArticleDto> GetArticleWithCategoryNonDeletedAsync(Guid articleId); 
        Task CreateArticleAsnyc(ArticleAddDto articleAddDto);
        Task<string> UpdateArticleAsync(ArticleUpdateDto articleUpdateDto);
        Task<string> SafeDeleteArticleAsync(Guid articleId);
        Task<string> UndoDeleteArticleAsync(Guid articleId);
    }
}
