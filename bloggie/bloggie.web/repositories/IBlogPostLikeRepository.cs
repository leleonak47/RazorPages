using bloggie.web.Models.Domain;

namespace bloggie.web.repositories
{
    public interface IBlogPostLikeRepository
    {
        Task<int> GetTotalLikesForBlog(Guid BlogPostId);

        Task AddLikeForBlogPost(Guid blogPostId, Guid userId);

        Task<IEnumerable<BlogPostLike>> GetLikesForBlog(Guid blogPostId);
    }
}
