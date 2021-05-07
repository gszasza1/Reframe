using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Reframe.Dal.Entities;

namespace Reframe.Web.Pages.Auth
{
    public class ChangePasswordModel : PageModel
    {

        private readonly UserManager<User> _userManager;

        [BindProperty]
        public string NewPassword { get; set; }

        public ChangePasswordModel(
            UserManager<User> userManager)
        {
            _userManager = userManager;
        }
        public async Task OnPostCreateNewPassword()
        {
            var user = await _userManager.FindByIdAsync(User.FindFirstValue(ClaimTypes.NameIdentifier));

            var token = await _userManager.GeneratePasswordResetTokenAsync(user);

            var result = await _userManager.ResetPasswordAsync(user, token, NewPassword);
        }
    }
}
