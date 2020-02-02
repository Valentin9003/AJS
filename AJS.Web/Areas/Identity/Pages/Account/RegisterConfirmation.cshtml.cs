using Microsoft.AspNetCore.Authorization;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.WebUtilities;
using AJS.Data.Models;
using Microsoft.Extensions.Localization;

namespace AJS.Web.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class RegisterConfirmationModel : PageModel
    {
        private readonly UserManager<User> _userManager;
        private readonly IEmailSender _sender;
        private readonly IStringLocalizer<RegisterConfirmationModel> _localizer;

        public RegisterConfirmationModel(UserManager<User> userManager, IEmailSender sender, IStringLocalizer<RegisterConfirmationModel> localizer)
        {
            _userManager = userManager;
            _sender = sender;
            _localizer = localizer;
        }

        public string Email { get; set; }

        public bool DisplayConfirmAccountLink { get; set; }

        public string EmailConfirmationUrl { get; set; }

        public async Task<IActionResult> OnGetAsync(string email)
        {
            if (email == null)
            {
                return RedirectToPage("/Index");
            }

            var user = await _userManager.FindByEmailAsync(email);
            if (user == null)
            {
                return NotFound(string.Format(_localizer[$"Unable to load user with email '{0}'."], email));
            }

            Email = email;
            // Once you add a real email sender, you should remove this code that lets you confirm the account
                DisplayConfirmAccountLink = true; // Comment this when Email Sender is activate
            if (DisplayConfirmAccountLink)
            {
                var userId = await _userManager.GetUserIdAsync(user);
                var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
                EmailConfirmationUrl = Url.Page(
                    "/Account/ConfirmEmail",
                    pageHandler: null,
                    values: new { area = "Identity", userId = userId, code = code },
                    protocol: Request.Scheme);
            }

            return Page();
        }
    }
}
