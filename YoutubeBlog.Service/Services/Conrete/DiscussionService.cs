using AutoMapper;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using YoutubeBlog.Data.UnitOfWorks;
using YoutubeBlog.Entity.Dtos.Articles;
using YoutubeBlog.Entity.Dtos.Discussions;
using YoutubeBlog.Entity.Entities;
using YoutubeBlog.Entity.Enums;
using YoutubeBlog.Service.Extensions;
using YoutubeBlog.Service.Helpers.Images;
using YoutubeBlog.Service.Services.Abstract;

namespace YoutubeBlog.Service.Services.Conrete
{
    public class DiscussionService : IDiscussionService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly ClaimsPrincipal _user;

        public DiscussionService(IUnitOfWork unitOfWork, IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            this.httpContextAccessor = httpContextAccessor;
            _user = httpContextAccessor.HttpContext.User;
        }

        public async Task<DiscussionListDto> GetAllByPagingAsync(int currentPage = 1, int pageSize = 4, bool isAscending = false)
        {
            pageSize = pageSize > 20 ? 20 : pageSize;

            var data = await unitOfWork.GetRepository<Discussion>().GetAllAsync(x => !x.IsDeleted, u => u.User, d => d.DiscussionFors, i => i.User.Image);

            var discussions = mapper.Map<List<DiscussionDto>>(data);
            
            var sortedDiscussions = isAscending
                ? discussions.OrderBy(a => a.CreatedDate).Skip((currentPage - 1) * pageSize).Take(pageSize).ToList()
                : discussions.OrderByDescending(a => a.CreatedDate).Skip((currentPage - 1) * pageSize).Take(pageSize).ToList();

            return new DiscussionListDto
            {
                DiscussionDtos = sortedDiscussions,
                CurrentPage = currentPage,
                PageSize = pageSize,
                TotalCount = discussions.Count(),
                IsAscending = isAscending
            };
        }

        public async Task<DiscussionListDto> SearchAsync(string keyword, int currentPage = 1, int pageSize = 4, bool isAscending = false)
        {
            pageSize = pageSize > 20 ? 20 : pageSize;
            
            var data = await unitOfWork.GetRepository<Discussion>().GetAllAsync(
                x => !x.IsDeleted && (x.Title.Contains(keyword) || x.Content.Contains(keyword)),
                 u => u.User, d => d.DiscussionFors, i => i.User.Image);

            if (keyword == null)
            {
                data = await unitOfWork.GetRepository<Discussion>().GetAllAsync(x => !x.IsDeleted, u => u.User, d => d.DiscussionFors, i => i.User.Image);
            }

            var discussions = mapper.Map<List<DiscussionDto>>(data);

            var sortedDiscussions = isAscending
                ? discussions.OrderBy(a => a.CreatedDate).Skip((currentPage - 1) * pageSize).Take(pageSize).ToList()
                : discussions.OrderByDescending(a => a.CreatedDate).Skip((currentPage - 1) * pageSize).Take(pageSize).ToList();

            return new DiscussionListDto
            {
                DiscussionDtos = sortedDiscussions,
                CurrentPage = currentPage,
                PageSize = pageSize,
                TotalCount = discussions.Count(),
                IsAscending = isAscending
            };
        }
        public async Task CreateDiscussionAsnyc(DiscussionAddDto discussionAddDto)
        {
            var userId = _user.GetLoggedInUserId();
            var userEmail = _user.GetLoggedInEmail();

            var discus = new Discussion(discussionAddDto.Title, discussionAddDto.Content, userId, userEmail);

            await unitOfWork.GetRepository<Discussion>().AddAsync(discus);
            await unitOfWork.SaveAsync();
        }

        public async Task<List<DiscussionDto>> GetAllDeletedDiscussions()
        {
            var deletedDiscussions = await unitOfWork.GetRepository<Discussion>().GetAllAsync(x=> x.IsDeleted, u=>u.User);
            var map = mapper.Map<List<DiscussionDto>>(deletedDiscussions);
            return map;
        }

        public async Task<List<DiscussionDto>> GetAllDiscussionsForUser(Guid userId)
        {
            var Discussions = await unitOfWork.GetRepository<Discussion>().GetAllAsync(x => !x.IsDeleted && x.UserId == userId, u => u.User, i => i.User.Image);
            var map = mapper.Map<List<DiscussionDto>>(Discussions);
            return map;
        }

        public async Task<List<DiscussionDto>> GetAllNonDeletedDiscussions()
        {
            var Discussions = await unitOfWork.GetRepository<Discussion>().GetAllAsync(x => !x.IsDeleted, u => u.User, d=>d.DiscussionFors, i=>i.User.Image);
            var map = mapper.Map<List<DiscussionDto>>(Discussions);
            return map;
        }

        public async Task<DiscussionDto> GetDiscussionWithId(Guid discussionId)
        {
            var discussion = await unitOfWork.GetRepository<Discussion>().GetAsync(x=>x.Id == discussionId, d=>d.DiscussionFors, u => u.User, i => i.User.Image);
            foreach (var item in discussion.DiscussionFors)
            {
                var item2 = await unitOfWork.GetRepository<DiscussionFor>().GetAsync(x => x.Id == item.Id, u => u.User, i => i.User.Image);
                item.User = item2.User;
            }
            var map = mapper.Map<DiscussionDto>(discussion);
            return map;
        }

        public async Task<string> SafeDeleteDiscussionAsync(Guid discussionId)
        {
            var userEmail = _user.GetLoggedInEmail();
            var discussion = await unitOfWork.GetRepository<Discussion>().GetByGuidAsync(discussionId);

            discussion.IsDeleted = true;
            discussion.DeletedDate = DateTime.Now;
            discussion.DeletedBy = userEmail;

            await unitOfWork.GetRepository<Discussion>().UpdateAsync(discussion);
            await unitOfWork.SaveAsync();

            return discussion.Title;
        }

        public async Task<Discussion> HardDeleteDiscussionAsync(Guid discussionId)
        {
            var discussion = await unitOfWork.GetRepository<Discussion>().GetAsync(x=>x.Id == discussionId , d=>d.DiscussionFors);

            foreach (var item in discussion.DiscussionFors)
            {
                await unitOfWork.GetRepository<DiscussionFor>().DeleteAsync(item);
            }

            await unitOfWork.GetRepository<Discussion>().DeleteAsync(discussion);
            await unitOfWork.SaveAsync();

            return discussion;
        }

        public async Task<string> UndoDeleteDiscussionAsync(Guid discussionId)
        {
            var userEmail = _user.GetLoggedInEmail();
            var discussion = await unitOfWork.GetRepository<Discussion>().GetByGuidAsync(discussionId);

            discussion.IsDeleted = false;
            discussion.DeletedDate = DateTime.Now;
            discussion.DeletedBy = userEmail;

            await unitOfWork.GetRepository<Discussion>().UpdateAsync(discussion);
            await unitOfWork.SaveAsync();

            return discussion.Title;
        }

        public async Task<string> UpdateDiscussionAsync(DiscussionUpdateDto discussionUpdateDto)
        {
            var discus = await unitOfWork.GetRepository<Discussion>().GetAsync(x => x.Id == discussionUpdateDto.Id);
            var map = mapper.Map(discussionUpdateDto, discus);
            await unitOfWork.GetRepository<Discussion>().UpdateAsync(map);
            await unitOfWork.SaveAsync();

            return discus.Title;
        }
    }
}
