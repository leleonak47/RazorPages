using bloggie.web.Data;
using bloggie.web.Models.Domain;
using bloggie.web.Models.ViewModels;
using bloggie.web.repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace bloggie.web.Pages.Admin.Blogs
{
    [Authorize(Roles = "Admin")]
    public class ListModel : PageModel
    {
        private readonly IBlogPostRepository blogPostRepository;

        public List<BlogPost> BlogPosts { get; set; }


        public ListModel(IBlogPostRepository blogPostRepository)
        {
            this.blogPostRepository = blogPostRepository;
        }

        public async Task OnGet()
        {
            var notificationJson = (string)TempData["Notification"];

            if (notificationJson != null)
            {
                ViewData["Notification"] = JsonSerializer.Deserialize < Notification>(notificationJson);
            }

            BlogPosts = (await blogPostRepository.GetAllAsync()).ToList();
        }
    }
}
