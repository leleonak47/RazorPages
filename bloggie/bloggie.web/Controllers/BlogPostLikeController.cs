using bloggie.web.Models.ViewModels;
using bloggie.web.repositories;
using Microsoft.AspNetCore.Mvc;

namespace bloggie.web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BlogPostLikeController : Controller
    {
        private readonly IBlogPostLikeRepository blogPostLikeRepository;

        public BlogPostLikeController(IBlogPostLikeRepository blogPostLikeRepository)
        {
            this.blogPostLikeRepository = blogPostLikeRepository;
        }

        [Route("Add")]
        [HttpPost]
        public async Task<IActionResult> AddLike([FromBody] AddBlogPostLikeRequest addBlogPostLikeRequest)
        {
            await blogPostLikeRepository.AddLikeForBlogPost(
                addBlogPostLikeRequest.BlogPostId,
                addBlogPostLikeRequest.UserId);

            return Ok();
        }

        [HttpGet]
        [Route("{blogPostId:Guid}/totalLikes")]
        public async Task<IActionResult> GetTotalLikes([FromRoute] Guid blogPostId)
        {
            var totalLikes = await blogPostLikeRepository.GetTotalLikesForBlog(blogPostId);

            return Ok(totalLikes);
        }
    }
}
