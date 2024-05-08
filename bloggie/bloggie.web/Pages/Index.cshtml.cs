using bloggie.web.Models.Domain;
using bloggie.web.repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace bloggie.web.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IBlogPostRepository blogPostRepository;
        private readonly ITagRepository tagRepository;

        public List<BlogPost> Blogs { get; set; }
        public List<Tag> tags { get; set; }

        public IndexModel(ILogger<IndexModel> logger, IBlogPostRepository blogPostRepository, ITagRepository tagRepository)
        {
            _logger = logger;
            this.blogPostRepository = blogPostRepository;
            this.tagRepository = tagRepository;
        }

        public async Task<IActionResult> OnGet()
        {
            Blogs = (await blogPostRepository.GetAllAsync()).ToList();
            tags = (await tagRepository.GetAllAsync()).ToList();

            return Page();
        }
    }
}
