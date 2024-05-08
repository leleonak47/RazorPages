using bloggie.web.Data;
using bloggie.web.Models.Domain;
using bloggie.web.Models.ViewModels;
using bloggie.web.repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;

namespace bloggie.web.Pages.Admin.Blogs
{
    [Authorize(Roles = "Admin")]
    public class AddModel : PageModel
    {
        private readonly IBlogPostRepository blogPostRepository;

        [BindProperty]
        public AddBlogPost AddBlogPostRequest { get; set; }
        [BindProperty]
        public IFormFile FeaturedImage { get; set; }
        [BindProperty]
        public string Tags { get; set; }

        public AddModel(IBlogPostRepository blogPostRepository)
        {
            this.blogPostRepository = blogPostRepository;
        }

        public void OnGet()
        {
        }
        public async Task<IActionResult> OnPost() 
        {
            var blogPost = new BlogPost()
            {
                Heading = AddBlogPostRequest.Heading,
                PageTitle = AddBlogPostRequest.PageTitle,
                Content = AddBlogPostRequest.Content,
                ShortDescription = AddBlogPostRequest.ShortDescription,
                FeaturedImageUrl = AddBlogPostRequest.FeaturedImageUrl,
                UrlHandle = AddBlogPostRequest.UrlHandle,
                PublishedDate = AddBlogPostRequest.PublishedDate,
                Author = AddBlogPostRequest.Author,
                Visible = AddBlogPostRequest.Visible,
                Tags = new List<Tag>(Tags.Split(',').Select(x => new Tag() { Name = x.Trim() }))
            };

            await blogPostRepository.AddAsync(blogPost);

            var notification = new Notification
            {
                message = "new blog post created!",
                type = Enums.NotificationType.Success
            };

            TempData["Notification"] = JsonSerializer.Serialize(notification);

            return RedirectToPage("/admin/blogs/list");
        }
    }
}
