using bloggie.web.Models.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.IdentityModel.Tokens;

namespace bloggie.web.Pages
{
    public class LoginModel : PageModel
    {
        private readonly SignInManager<IdentityUser> signInManager;

        [BindProperty]
        public Login LoginViewModel { get; set; }


        public LoginModel(SignInManager<IdentityUser> signInManager)
        {
            this.signInManager = signInManager;
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost(string ReturnUrl)
        {
            var signInResult = await signInManager.PasswordSignInAsync(
                 LoginViewModel.Username, LoginViewModel.Password, false, false
                 );
            if (signInResult.Succeeded)
            {
                if (!string.IsNullOrWhiteSpace(ReturnUrl))
                {
                    return RedirectToPage(ReturnUrl);
                }

                return RedirectToPage("index");
            }
            else
            {
                ViewData["Notification"] = new Notification
                {
                    type = Enums.NotificationType.Error,
                    message = "Unable to login"
                };

                return Page();
            }
        }
    }
}
