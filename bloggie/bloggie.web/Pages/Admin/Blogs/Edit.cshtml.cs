using bloggie.web.Data;
using bloggie.web.Models.Domain;
using bloggie.web.Models.ViewModels;
using bloggie.web.repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;

namespace bloggie.web.Pages.Admin.Blogs
{
    [Authorize(Roles = "Admin")]
    public class EditModel : PageModel
    {
        private readonly IBlogPostRepository blogPostRepository;

        [BindProperty]
        public BlogPost BlogPost { get; set; }
        [BindProperty]
        public IFormFile FeaturedImage { get; set; }
        [BindProperty]
        public string Tags { get; set; }
        public EditModel(IBlogPostRepository blogPostRepository)
        {
            this.blogPostRepository = blogPostRepository;
        }

        public async Task OnGet(Guid id)
        {
            BlogPost = await blogPostRepository.GetAsync(id);
            

            if (BlogPost != null && BlogPost.Tags != null)
            {
                Tags = string.Join(',', BlogPost.Tags.Select(x => x.Name));
            }
        }

        public async Task<IActionResult> OnPostEdit()
        {
            BlogPost.Tags = new List<Tag>(Tags.Split(',').Select(x => new Tag()
            {
                Name = x.Trim()
            }));

            await blogPostRepository.UpdateAsync(BlogPost);

            try
            {

                ViewData["Notification"] = new Notification
                {
                    message = "Record updated successfullt!",
                    type = Enums.NotificationType.Success
                };
            }
            catch (Exception ex)
            {
                ViewData["Notification"] = new Notification
                {
                    message = ex.Message,
                    type = Enums.NotificationType.Error
                };
            }

            return Page();
        }

        public async Task<IActionResult> OnPostDelete()
        {
            var deleted = await blogPostRepository.DeleteAsync(BlogPost.Id);

            if (deleted)
            {
                var notification = new Notification
                {
                    message = "Blog Was deleted successfully!",
                    type = Enums.NotificationType.Success
                };

                TempData["Notification"] = JsonSerializer.Serialize(notification);

                return RedirectToPage("/admin/blogs/list");
            }
            
            return Page();
        }
    }
}
