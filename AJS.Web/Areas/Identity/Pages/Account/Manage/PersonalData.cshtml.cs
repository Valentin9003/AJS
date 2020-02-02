using System.Threading.Tasks;
using AJS.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;

namespace AJS.Web.Areas.Identity.Pages.Account.Manage
{
    public class PersonalDataModel : PageModel
    {
        private readonly UserManager<User> _userManager;
        private readonly ILogger<PersonalDataModel> _logger;
        private readonly IStringLocalizer<PersonalDataModel> _localizer;

        public PersonalDataModel(
            UserManager<User> userManager,
            ILogger<PersonalDataModel> logger, 
            IStringLocalizer<PersonalDataModel> localizer)
        {
            _userManager = userManager ?? throw new System.ArgumentNullException(nameof(userManager));
            _logger = logger;
            _localizer = localizer;
        }

        public async Task<IActionResult> OnGet()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound(string.Format(_localizer[$"Unable to load user with ID '{0}'."], _userManager.GetUserId(User)));
            }

            return Page();
        }
    }
}