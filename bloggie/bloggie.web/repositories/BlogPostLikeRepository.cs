
using bloggie.web.Data;
using bloggie.web.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace bloggie.web.repositories
{
    public class BlogPostLikeRepository : IBlogPostLikeRepository
    {
        private readonly BloggieDbContext bloggieDbContext;

        public BlogPostLikeRepository(BloggieDbContext bloggieDbContext)
        {
            this.bloggieDbContext = bloggieDbContext;
        }

        public async Task<int> GetTotalLikesForBlog(Guid BlogPostId)
        {
            return await bloggieDbContext.BlogPostLike
                .CountAsync(x => x.BlogPostId == BlogPostId);
        }

        public async Task AddLikeForBlogPost(Guid blogPostId, Guid userId)
        {
            var like = new BlogPostLike
            {
                Id = Guid.NewGuid(),
                BlogPostId = blogPostId,
                UserId = userId
            };
            
            await bloggieDbContext.BlogPostLike.AddAsync(like);

            await bloggieDbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<BlogPostLike>> GetLikesForBlog(Guid blogPostId)
        {
            return await bloggieDbContext.BlogPostLike.Where(x => x.BlogPostId == blogPostId).ToListAsync();
        }
    }
}
