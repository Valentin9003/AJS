using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Text.Encodings.Web;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.WebUtilities;
using AJS.Data.Models;
using Microsoft.Extensions.Localization;

namespace AJS.Web.Areas.Identity.Pages.Account.Manage
{
    public partial class EmailModel : PageModel
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IEmailSender _emailSender;
        private readonly IStringLocalizer<EmailModel> _localizer;

        public EmailModel(
            UserManager<User> userManager,
            SignInManager<User> signInManager,
            IEmailSender emailSender,
            IStringLocalizer<EmailModel> localizer)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _emailSender = emailSender;
            _localizer = localizer;
        }

        public string Username { get; set; }

        [Display(Name = "Email")]
        public string Email { get; set; }

        public bool IsEmailConfirmed { get; set; }

        [TempData]
        public string StatusMessage { get; set; }

        [BindProperty]
        public InputModel Input { get; set; }

        public class InputModel
        {
            [Required(ErrorMessage = "Email is Required")]
            [EmailAddress(ErrorMessage = "Invalid Email")]
            [Display(Name = "New email")]
            public string NewEmail { get; set; }
        }

        private async Task LoadAsync(User user)
        {
            var email = await _userManager.GetEmailAsync(user);
            Email = email;

            Input = new InputModel
            {
                NewEmail = email,
            };

            IsEmailConfirmed = await _userManager.IsEmailConfirmedAsync(user);
        }

        public async Task<IActionResult> OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound(string.Format(_localizer[$"Unable to load user with ID '{0}'."], _userManager.GetUserId(User)));
            }

            await LoadAsync(user);
            return Page();
        }

        public async Task<IActionResult> OnPostChangeEmailAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound(string.Format(_localizer[$"Unable to load user with ID '{0}'."], _userManager.GetUserId(User)));
            }

            if (!ModelState.IsValid)
            {
                await LoadAsync(user);
                return Page();
            }

            var email = await _userManager.GetEmailAsync(user);
            if (Input.NewEmail != email)
            {
                var userId = await _userManager.GetUserIdAsync(user);
                var code = await _userManager.GenerateChangeEmailTokenAsync(user, Input.NewEmail);
                var callbackUrl = Url.Page(
                    "/Account/ConfirmEmailChange",
                    pageHandler: null,
                    values: new { userId = userId, email = Input.NewEmail, code = code },
                    protocol: Request.Scheme);
                await _emailSender.SendEmailAsync(
                    Input.NewEmail,
                    "Confirm your email",
                    $"Please confirm your account by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");

                StatusMessage = _localizer["Confirmation link to change email sent. Please check your email."];
                return RedirectToPage();
            }

            StatusMessage = _localizer["Your email is unchanged."];
            return RedirectToPage();
        }

        public async Task<IActionResult> OnPostSendVerificationEmailAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound(string.Format(_localizer[$"Unable to load user with ID '{0}'."], _userManager.GetUserId(User)));
            }

            if (!ModelState.IsValid)
            {
                await LoadAsync(user);
                return Page();
            }

            var userId = await _userManager.GetUserIdAsync(user);
            var email = await _userManager.GetEmailAsync(user);
            var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
            code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
            var callbackUrl = Url.Page(
                "/Account/ConfirmEmail",
                pageHandler: null,
                values: new { area = "Identity", userId = userId, code = code },
                protocol: Request.Scheme);
            await _emailSender.SendEmailAsync(
                email,
                "Confirm your email",
                $"Please confirm your account by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");

            StatusMessage = _localizer["Verification email sent. Please check your email."];
            return RedirectToPage();
        }
    }
}
