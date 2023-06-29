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

            var usertemp = new IdentityUser();
            usertemp.UserName = "admin";
            usertemp.EmailConfirmed = true;
            usertemp.Email = "admin@salasdenesayo.com";

            var user = await _userManager.FindByEmailAsync(usertemp.Email);
            if (user == null)
            {
                await _userManager.CreateAsync(usertemp);
                string token = await _userManager.GeneratePasswordResetTokenAsync(usertemp);
                await _userManager.ResetPasswordAsync(usertemp, token, "Pass2023!");
            }

            var role = await _roleManager.FindByIdAsync("Supervisor");
            if (role == null)
            {
                await _roleManager.CreateAsync(new IdentityRole() { Name = "Supervisor" });
            }


            var UsersInRole = await _userManager.GetRolesAsync(user);
            if (UsersInRole.Where(w => w.Contains("Supervisor")).Count() == 0)
            {
                await _userManager.AddToRoleAsync(user, "Supervisor");
            }




            return Json(usertemp);
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Login(string ReturnUrl = "")
        {
            
            ViewData["returnurl"] = ReturnUrl;
            return View();
        }

        [HttpGet]
        public IActionResult Claims()
        {

            var listClaims = User.Claims.ToList();
            var res = listClaims.Select(s => new { type = s.Type, value = s.Value }).ToList();
            return Json(res);
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> ActivarEmail(string id)
        {
            var identityuser = await _userManager.FindByIdAsync(id);
            identityuser.EmailConfirmed = true;
            await _userManager.UpdateAsync(identityuser);
            return View("Login");
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(string user, string password, string ReturnUrl = "")
        {
            var res = await _siginManager.PasswordSignInAsync(user, password, true, false);

            if (!res.Succeeded)
            {
                ViewData["error"] = "Error al iniciar sesión.";
                var identityuser = await _userManager.FindByNameAsync(user);
                if (!identityuser.EmailConfirmed)
				{
					ViewData["idUser"] = identityuser.Id;
					return View("ActivarEmail");
                }
            }
            else
            {
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
