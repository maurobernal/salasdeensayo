using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace front.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly SignInManager<IdentityUser> _siginManager;

        public AccountController(
            UserManager<IdentityUser> userManager,
            RoleManager<IdentityRole> roleManager,
            SignInManager<IdentityUser> siginManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _siginManager = siginManager;

        }

        [HttpGet]
        public async Task<IActionResult> Seed()
        {

            var user = new IdentityUser();
            user.UserName = "admin";
            user.EmailConfirmed = true;
            user.Email = "admin@salasdenesayo.com";

            var res = await _userManager.FindByEmailAsync(user.Email);
            if (res == null)
            {
                await _userManager.CreateAsync(user);
                string token = await _userManager.GeneratePasswordResetTokenAsync(user);
                await _userManager.ResetPasswordAsync(user, token, "Pass2023!");
            }

            return Json(user);
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login(string ReturnUrl = "")
        {
            ViewData["returnurl"] = ReturnUrl;
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(string user, string password, string ReturnUrl = "")
        {
            var res = await _siginManager.PasswordSignInAsync(user, password, true, false);

            if (!res.Succeeded)
            {
                ViewData["error"] = "Error al iniciar sesión.";
            }
            else
            {
                var identityuser = await _userManager.FindByNameAsync(user);
                //await _siginManager.CreateUserPrincipalAsync(identityuser);
                ViewData["exito"] = "Ha iniciado correctamente";
                if (ReturnUrl != null && ReturnUrl != "")
                {
                    return Redirect(ReturnUrl);
                }
            }


            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await _siginManager.SignOutAsync();
            return Redirect("/");
        }
    }
}
