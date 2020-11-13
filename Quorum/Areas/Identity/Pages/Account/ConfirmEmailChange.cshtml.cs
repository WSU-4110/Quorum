using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.WebUtilities;
using QuorumDB.Models;

namespace Quorum.Areas.Identity.Pages.Account
{
    interface ConfirmEmail
    {
        private readonly UserManager<AspNetUser> _userManager;
        private readonly SignInManager<AspNetUser> _signInManager;

        public ConfirmEmailChangeModel(UserManager<AspNetUser> userManager, SignInManager<AspNetUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [TempData]
        public string StatusMessage { get; set; }
        public void check();
    }

    class UserInsert : ConfirmEmail
    {
        public void check(string userId, string code)
        {
            if (userId == null)
            {
                return RedirectToPage("/Index");
            }

            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{userId}'.");
            }
        }
    }
    class EmailInsert : ConfirmEmail
    {
        public void check(string email, string code)
        {
            if (email == null)
            {
                return RedirectToPage("/Index");
            }

            code = Encoding.UTF8.GetString(WebEncoders.Base64UrlDecode(code));
            var result = await _userManager.ChangeEmailAsync(user, email, code);
            if (!result.Succeeded)
            {
                StatusMessage = "Error changing email.";
                return Page();
            }
        }
    }


}
