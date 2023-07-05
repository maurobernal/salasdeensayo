using front.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Text.RegularExpressions;
using Newtonsoft.Json.Linq;

namespace front.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUserDTO> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly SignInManager<IdentityUserDTO> _siginManager;

        public AccountController(
            UserManager<IdentityUserDTO> userManager,
            RoleManager<IdentityRole> roleManager,
            SignInManager<IdentityUserDTO> siginManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _siginManager = siginManager;

        }

        [HttpGet]
        public async Task<IActionResult> Seed()
        {

            var usertemp = new IdentityUserDTO();
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

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Register() => View();


        private bool missingData (string email,string password,string user)
        {
            if (password == null || email == null || user == null) return false;
            else return true;
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Register(UserRegisterDTO entity)
        {

            if(!missingData(entity.Email, entity.Password, entity.User))
            {
                ViewData["missingData"] = "Campo (*) obligatorio.";
                return View();
            }
            
            if(ModelState.Values.ToList().Count()!=0)
            {
                ViewData["passworderror"] = "la contrasela debe tener mayus,min, caracter especial, numero y 8 caracteres";
                return View();
            }
           

            var usertemp = new IdentityUserDTO();
            usertemp.UserName = entity.User;
            usertemp.EmailConfirmed = false;
            usertemp.Email = entity.Email;

            var userFind = await _userManager.FindByEmailAsync(usertemp.Email);

            if (userFind == null)
            {
                await _userManager.CreateAsync(usertemp);
                string token = await _userManager.GeneratePasswordResetTokenAsync(usertemp);
                await _userManager.ResetPasswordAsync(usertemp, token, entity.Password);
            return Redirect("/account/login");
            }

            ViewData["error"] = "Error al registar usuario.";
            return View();
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
