using bloggie.web.Models.Domain;

namespace bloggie.web.repositories
{
    public interface IBlogPostCommentRepository
    {
        Task<BlogPostComment> AddAsync(BlogPostComment blogPostComment);

        Task<IEnumerable<BlogPostComment>> GetAllAsync(Guid blogPostId);
    }
}
