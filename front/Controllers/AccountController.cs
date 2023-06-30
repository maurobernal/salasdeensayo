using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

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
        public IActionResult Login(string ReturnUrl = "")
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

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> ForgotPass() => View();

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> ForgotPass(string email)
        {
            var res = await _userManager.FindByEmailAsync(email);
            if (res == null)
            {
                ViewData["error"] = "Error al encontrar email.";
                return View();

            }
            string token = await _userManager.GeneratePasswordResetTokenAsync(res);
            ViewData["emailUser"] = res.Email;
            ViewData["tokenUser"] = token;
            return View("TokenVerificator");
        }



        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> ChangePass(string Token, string Email)
        {
            ViewData["tokenUser"] = Token;
            ViewData["emailUser"] = Email;

            return View();
        }
       
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> ChangePass(string Email, string Token, string password, string password2)
        {
            var user = await _userManager.FindByEmailAsync(Email);
            

            if (user == null)
            {
                ViewData["error"] = "Error al encontrar usuario";
                return View();
            }

            if (password != password2)
            {
                ViewData["error"] = "Las contraseñas no coinciden";
                return View();
            }

            //await _userManager.UpdateAsync(user);
           var res= await _userManager.ResetPasswordAsync(user, Token, password);
            if (!res.Succeeded) {
                ViewData["error"] = "Contraseña Debil. Intente de nuevo";
                return View();
            }
            return Redirect("Login");
        }

       

    }
}
