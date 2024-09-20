using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using YoutubeBlog.Data.Migrations;
using YoutubeBlog.Data.UnitOfWorks;
using YoutubeBlog.Entity.Dtos.Discussions;
using YoutubeBlog.Entity.Entities;
using YoutubeBlog.Service.Extensions;
using YoutubeBlog.Service.Services.Abstract;

namespace YoutubeBlog.Service.Services.Conrete
{
    public class DiscussionForService : IDiscussionForService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly ClaimsPrincipal _user;

        public DiscussionForService(IUnitOfWork unitOfWork, IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            this.httpContextAccessor = httpContextAccessor;
            _user = httpContextAccessor.HttpContext.User;
        }
        public async Task CreateDiscussionForAsnyc(DiscussionForAddDto discussionForAddDto)
        {
            var userId = _user.GetLoggedInUserId();
            var userEmail = _user.GetLoggedInEmail();

            var discus = new DiscussionFor(discussionForAddDto.Content, discussionForAddDto.DiscussionId, userId, userEmail);

            await unitOfWork.GetRepository<DiscussionFor>().AddAsync(discus);
            await unitOfWork.SaveAsync();
        }

        public async Task<List<DiscussionForDto>> GetAllDeletedDiscussionFors()
        {
            var discuss = await unitOfWork.GetRepository<DiscussionFor>().GetAllAsync(x => x.IsDeleted, u => u.User, d => d.Discussion);
            var map = mapper.Map<List<DiscussionForDto>>(discuss);
            return map;
        }

        public async Task<List<DiscussionForDto>> GetAllDiscussionsForDiscussionId(Guid discussionId)
        {
            var discusses = await unitOfWork.GetRepository<DiscussionFor>().GetAllAsync(x=>!x.IsDeleted && x.DiscussionId == discussionId, u => u.User, d => d.Discussion);
            var map = mapper.Map<List<DiscussionForDto>>(discusses);
            return map;
        }

        public async Task<List<DiscussionForDto>> GetAllDiscussionsForForUser(Guid userId)
        {
            var discuss = await unitOfWork.GetRepository<DiscussionFor>().GetAllAsync(x=>!x.IsDeleted && x.UserId == userId, u => u.User, d => d.Discussion);
            var map = mapper.Map<List<DiscussionForDto>>(discuss);
            return map;
        }

        public async Task<List<DiscussionForDto>> GetAllNonDeletedDiscussionFors()
        {
            var discuss = await unitOfWork.GetRepository<DiscussionFor>().GetAllAsync(x => !x.IsDeleted, u=>u.User, d=>d.Discussion);
            var map = mapper.Map<List<DiscussionForDto>>(discuss);
            return map;
        }

        public async Task<DiscussionForDto> GetDiscussionForWithId(Guid discussionForId)
        {
            var discus = await unitOfWork.GetRepository<DiscussionFor>().GetAsync(x=>x.Id == discussionForId, u => u.User, d => d.Discussion);
            var map = mapper.Map<DiscussionForDto>(discus);
            return map;
        }

        public async Task<DiscussionFor> HardDeleteDiscussionAsync(Guid discussionId)
        {
            var discus = await unitOfWork.GetRepository<DiscussionFor>().GetByGuidAsync(discussionId);
            await unitOfWork.GetRepository<DiscussionFor>().DeleteAsync(discus);
            await unitOfWork.SaveAsync();

            return discus;
        }

        public async Task<DiscussionFor> SafeDeleteDiscussionForAsync(Guid discussionForId)
        {
            var userEmail = _user.GetLoggedInEmail();
            var discus = await unitOfWork.GetRepository<DiscussionFor>().GetAsync(x => x.Id == discussionForId ,d=>d.Discussion);
            discus.IsDeleted = true;
            discus.ModifiedDate = DateTime.Now;
            discus.ModifiedBy = userEmail;
            
            await unitOfWork.GetRepository<DiscussionFor>().UpdateAsync(discus);
            await unitOfWork.SaveAsync();

            return discus;
        }

        public async Task<DiscussionFor> UndoDeleteDiscussionForAsync(Guid discussionForId)
        {
            var userEmail = _user.GetLoggedInEmail();
            var discus = await unitOfWork.GetRepository<DiscussionFor>().GetAsync(x => x.Id == discussionForId, d=>d.Discussion);
            discus.IsDeleted = false;
            discus.ModifiedDate = DateTime.Now;
            discus.ModifiedBy = userEmail;

            await unitOfWork.GetRepository<DiscussionFor>().UpdateAsync(discus);
            await unitOfWork.SaveAsync();

            return discus;
        }

        public async Task<DiscussionFor> UpdateDiscussionForAsync(DiscussionForUpdateDto discussionForUpdateDto)
        {
            var discus = await unitOfWork.GetRepository<DiscussionFor>().GetAsync(x => x.Id == discussionForUpdateDto.Id);
            var map = mapper.Map(discussionForUpdateDto, discus);
            await unitOfWork.GetRepository<DiscussionFor>().UpdateAsync(map);
            await unitOfWork.SaveAsync();

            return discus;
        }
    }
}
