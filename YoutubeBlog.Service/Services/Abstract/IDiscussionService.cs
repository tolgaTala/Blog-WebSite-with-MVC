using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YoutubeBlog.Entity.Dtos.Articles;
using YoutubeBlog.Entity.Dtos.Discussions;
using YoutubeBlog.Entity.Entities;

namespace YoutubeBlog.Service.Services.Abstract
{
    public interface IDiscussionService
    {
        Task<DiscussionListDto> GetAllByPagingAsync(int currentPage = 1, int pageSize = 5, bool isAscending = false);
        Task<DiscussionListDto> SearchAsync(string keyword, int currentPage = 1, int pageSize = 3, bool isAscending = false);
        Task<List<DiscussionDto>> GetAllNonDeletedDiscussions();
        Task<List<DiscussionDto>> GetAllDeletedDiscussions();
        Task<List<DiscussionDto>> GetAllDiscussionsForUser(Guid userId);
        Task<DiscussionDto> GetDiscussionWithId(Guid discussionId);
        Task CreateDiscussionAsnyc(DiscussionAddDto discussionAddDto);
        Task<string> UpdateDiscussionAsync(DiscussionUpdateDto discussionUpdateDto);
        Task<string> SafeDeleteDiscussionAsync(Guid discussionId);
        Task<Discussion> HardDeleteDiscussionAsync(Guid discussionId);
        Task<string> UndoDeleteDiscussionAsync(Guid discussionId);
    }
}
