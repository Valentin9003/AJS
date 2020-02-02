﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AJS.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;

namespace AJS.Web.Areas.Identity.Pages.Account.Manage
{
    public class ResetAuthenticatorModel : PageModel
    {
        UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        ILogger<ResetAuthenticatorModel> _logger;
        private readonly IStringLocalizer<ResetAuthenticatorModel> _localizer;

        public ResetAuthenticatorModel(
            UserManager<User> userManager,
            SignInManager<User> signInManager,
            ILogger<ResetAuthenticatorModel> logger,
            IStringLocalizer<ResetAuthenticatorModel> localizer)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            _localizer = localizer;
        }

        [TempData]
        public string StatusMessage { get; set; }

        public async Task<IActionResult> OnGet()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound(string.Format(_localizer[$"Unable to load user with ID '{0}'."], _userManager.GetUserId(User)));
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound(string.Format(_localizer[$"Unable to load user with ID '{0}'."], _userManager.GetUserId(User)));
            }

            await _userManager.SetTwoFactorEnabledAsync(user, false);
            await _userManager.ResetAuthenticatorKeyAsync(user);
            _logger.LogInformation("User with ID '{UserId}' has reset their authentication app key.", user.Id);

            await _signInManager.RefreshSignInAsync(user);
            StatusMessage = _localizer["Your authenticator app key has been reset, you will need to configure your authenticator app using the new key."];

            return RedirectToPage("./EnableAuthenticator");
        }
    }
}