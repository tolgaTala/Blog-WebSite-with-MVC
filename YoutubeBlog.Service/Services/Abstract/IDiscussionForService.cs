using YoutubeBlog.Entity.Dtos.Discussions;
using YoutubeBlog.Entity.Entities;

namespace YoutubeBlog.Service.Services.Abstract
{
    public interface IDiscussionForService
    {
        Task<List<DiscussionForDto>> GetAllNonDeletedDiscussionFors();
        Task<List<DiscussionForDto>> GetAllDeletedDiscussionFors();
        Task<List<DiscussionForDto>> GetAllDiscussionsForForUser(Guid userId);
        Task<List<DiscussionForDto>> GetAllDiscussionsForDiscussionId(Guid discussionId);
        Task<DiscussionForDto> GetDiscussionForWithId(Guid discussionForId);
        Task CreateDiscussionForAsnyc(DiscussionForAddDto discussionForAddDto);
        Task<DiscussionFor> UpdateDiscussionForAsync(DiscussionForUpdateDto discussionForUpdateDto);
        Task<DiscussionFor> SafeDeleteDiscussionForAsync(Guid discussionForId);
        Task<DiscussionFor> HardDeleteDiscussionAsync(Guid discussionId);
        Task<DiscussionFor> UndoDeleteDiscussionForAsync(Guid discussionForId);
    }
}
