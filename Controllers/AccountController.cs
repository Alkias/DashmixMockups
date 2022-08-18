using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using DashmixMockups.Data;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace DashmixMockups.Controllers
{
    public class AccountController : Controller
    {
        #region Fields

        private readonly IOptions<List<UserToLogin>> _users;

        #endregion

        #region Ctor

        public AccountController (IOptions<List<UserToLogin>> users) {
            _users = users;
        }

        #endregion

        #region Methods

        public async Task<IActionResult> Login() {
            var model = new UserToLogin();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Login (UserToLogin userToLogin) {
            var user = _users.Value.Find(c => c.UserName == userToLogin.UserName && c.Password == userToLogin.Password);

            if (!(user is null)) {
                var claims = new List<Claim> {
                    new Claim(ClaimTypes.Name, userToLogin.UserName),
                    new Claim("FullName", userToLogin.UserName),
                    new Claim(ClaimTypes.Role, user.Role),
                };

                var claimsIdentity = new ClaimsIdentity(
                    claims,
                    CookieAuthenticationDefaults.AuthenticationScheme);

                var authProperties = new AuthenticationProperties {
                    RedirectUri = "/Home/Index",
                };

                await HttpContext.SignInAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(claimsIdentity),
                    authProperties);

                return Redirect("/Home/Index");
            }

            return Redirect("/Account/Error");
        }

        public async Task<IActionResult> PasswordReminder() {
            var model = new UserToLogin();
            return View(model);
        }

        public async Task<IActionResult> EkdilosiEndiaferonts() {
            var model = new EkdilosiEndiaferontsModel();

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EkdilosiEndiaferonts (EkdilosiEndiaferontsModel model) {
            if (ModelState.IsValid) {
                model.SuccessfullySent = true;
                model.Result = "Ευχαριστούμε για την Εκδήλωση Ενδιαφέροντος, θα επικοινωνήσουμε μαζί σας το συντομώτερο δυνατό.";
                return View(model);
            }

            return View(model);
        }

        [Authorize]
        public async Task<IActionResult> Logout() {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            return Redirect("/Account/Login");
        }

        #endregion
    }
}