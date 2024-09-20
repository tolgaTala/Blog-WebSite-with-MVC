using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YoutubeBlog.Entity.Entities;
using YoutubeBlog.Service.Services.Abstract;
using YoutubeBlog.Data.UnitOfWorks;
using YoutubeBlog.Entity.Dtos.Articles;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using YoutubeBlog.Service.Extensions;
using YoutubeBlog.Service.Helpers.Images;
using YoutubeBlog.Entity.Enums;

namespace YoutubeBlog.Service.Services.Conrete
{
    public class ArticleService : IArticleService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly IImageHelper imageHelper;
        private readonly ClaimsPrincipal _user;

        public ArticleService(IUnitOfWork unitOfWork, IMapper mapper, IHttpContextAccessor httpContextAccessor , IImageHelper imageHelper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            this.httpContextAccessor = httpContextAccessor;
            _user = httpContextAccessor.HttpContext.User;
            this.imageHelper = imageHelper;
            
        }

        public async Task<ArticleListDto> GetAllByPagingAsync(Guid? categoryId, int currentPage = 1,int pageSize=3 ,bool isAscending = false)
        {
            pageSize = pageSize > 20 ? 20 : pageSize;

            var articles = categoryId == null
                ? await unitOfWork.GetRepository<Article>().GetAllAsync(x => !x.IsDeleted, a => a.Category, i => i.Image, u =>u.User)
                : await unitOfWork.GetRepository<Article>().GetAllAsync(a => a.CategoryId == categoryId && !a.IsDeleted, x => x.Category, i => i.Image, u => u.User);
            //var deneme = articles;
            //deneme.Sort((a, b) => a.CreatedDate.CompareTo(b.CreatedDate));
            var sortedArticles = isAscending
                ? articles.OrderBy(a => a.CreatedDate).Skip((currentPage - 1) * pageSize).Take(pageSize).ToList()
                : articles.OrderByDescending(a => a.CreatedDate).Skip((currentPage - 1) * pageSize).Take(pageSize).ToList();

            return new ArticleListDto
            {
                Articles = sortedArticles,
                CategoryId = categoryId == null ? null : categoryId.Value,
                CurrentPage = currentPage,
                PageSize = pageSize,
                TotalCount = articles.Count(),
                IsAscending = isAscending
            };
        }
        public async Task CreateArticleAsnyc(ArticleAddDto articleAddDto)
        {
            var userId = _user.GetLoggedInUserId();
            var userEmail = _user.GetLoggedInEmail();

                var imageUpload = await imageHelper.Upload(articleAddDto.Title, articleAddDto.Photo, ImageType.Post);
                Image image = new(imageUpload.FullName, articleAddDto.Photo.ContentType, userEmail);
                await unitOfWork.GetRepository<Image>().AddAsync(image);

            //var imageId = Guid.Parse("CB2150F3-A4F9-4316-B1C1-A4FE1693FC7E");

            var article = new Article(articleAddDto.Title,articleAddDto.Content,userId, userEmail,articleAddDto.CategoryId,image.Id);

            await unitOfWork.GetRepository<Article>().AddAsync(article);
            await unitOfWork.SaveAsync();
        }

        public async Task<List<ArticleDto>> GetAllArticleWithCategoryNonDeletedAsync()
        {
            var articles = await unitOfWork.GetRepository<Article>().GetAllAsync(x=>!x.IsDeleted, x=>x.Category);
            var map = mapper.Map<List<ArticleDto>>(articles);
            return map;
        }

        public async Task<ArticleDto> GetArticleWithCategoryNonDeletedAsync(Guid articleId)
        {
            var article = await unitOfWork.GetRepository<Article>().GetAsync(x => !x.IsDeleted && x.Id == articleId, x => x.Category, i=>i.Image, u=>u.User);
            
            var map = mapper.Map<ArticleDto>(article);
            return map; 
        }
        public async Task<string> UpdateArticleAsync(ArticleUpdateDto articleUpdateDto)
        {
            var userEmail = _user.GetLoggedInEmail();
            var article = await unitOfWork.GetRepository<Article>().GetAsync(x => !x.IsDeleted && x.Id == articleUpdateDto.Id, x => x.Category, i => i.Image);
            var stackImageId = article.ImageId;
            var stackImage = article.Image;
            if (articleUpdateDto.Photo != null)
            {
                imageHelper.Delete(article.Image.FileName);
                var imageUpload = await imageHelper.Upload(articleUpdateDto.Title,articleUpdateDto.Photo,ImageType.Post);
                Image image = new(imageUpload.FullName, articleUpdateDto.Photo.ContentType, userEmail);
                await unitOfWork.GetRepository<Image>().AddAsync(image);

                article.ImageId = image.Id;
                article.Image = image;
            }
            var map = mapper.Map<Article>(articleUpdateDto);
            //mapleme hatası
            mapper.Map(map, article);


            if (articleUpdateDto.Photo == null)
            {
                article.ImageId = stackImageId;
                article.Image = stackImage;
            }
            article.ModifiedDate = DateTime.Now;
            article.ModifiedBy = userEmail;


            await unitOfWork.GetRepository<Article>().UpdateAsync(article);

            await unitOfWork.SaveAsync();

            return article.Title;
        }

        public async Task<string> SafeDeleteArticleAsync(Guid articleId)
        {
            var userEmail = _user.GetLoggedInEmail();
            var article = await unitOfWork.GetRepository<Article>().GetByGuidAsync(articleId);

            article.IsDeleted = true;
            article.DeletedDate = DateTime.Now;
            article.DeletedBy = userEmail;

            await unitOfWork.GetRepository<Article>().UpdateAsync(article);
            await unitOfWork.SaveAsync();

            return article.Title;
        }

        public async Task<List<ArticleDto>> GetAllDeletedArticles()
        {
            var articles = await unitOfWork.GetRepository<Article>().GetAllAsync(x => x.IsDeleted, x => x.Category);
            var map = mapper.Map<List<ArticleDto>>(articles);
            return map;
        }

        public async Task<string> UndoDeleteArticleAsync(Guid articleId)
        {
            var article = await unitOfWork.GetRepository<Article>().GetByGuidAsync(articleId);

            article.IsDeleted = false;
            article.DeletedDate = null;
            article.DeletedBy = null;

            await unitOfWork.GetRepository<Article>().UpdateAsync(article);
            await unitOfWork.SaveAsync();

            return article.Title;
        }

        public async Task<ArticleListDto> SearchAsync(string keyword, int currentPage = 1, int pageSize = 3, bool isAscending = false)
        {
            pageSize = pageSize > 20 ? 20 : pageSize;

            var articles = await unitOfWork.GetRepository<Article>().GetAllAsync(
                x => !x.IsDeleted && (x.Title.Contains(keyword) || x.Content.Contains(keyword) || x.Category.Name.Contains(keyword)),
                a => a.Category, i => i.Image, u => u.User);

            var sortedArticles = isAscending
                ? articles.OrderBy(a => a.CreatedDate).Skip((currentPage - 1) * pageSize).Take(pageSize).ToList()
                : articles.OrderByDescending(a => a.CreatedDate).Skip((currentPage - 1) * pageSize).Take(pageSize).ToList();

            return new ArticleListDto
            {
                Articles = sortedArticles,
                CurrentPage = currentPage,
                PageSize = pageSize,
                TotalCount = articles.Count(),
                IsAscending = isAscending
            };
        }

        public async Task<List<ArticleDto>> GetRecentArticles()
        {
            var articles = await unitOfWork.GetRepository<Article>().GetAllAsync(x=>!x.IsDeleted);
            var sortedArticles = articles.OrderByDescending(a => a.CreatedDate).Take(4).ToList();

            var map = mapper.Map<List<ArticleDto>>(sortedArticles);
            return map;
        }
    }
}
