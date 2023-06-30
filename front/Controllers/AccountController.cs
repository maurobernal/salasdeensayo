﻿using front.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Text.RegularExpressions;

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
        public IActionResult Register() => View();


        private bool missingData (string email,string password,string user)
        {
            if (password == null || email == null || user == null) return false;
            else return true;
        }


        private bool ContrasenaSegura(string contraseñaSinVerificar)
        {
            Regex letras = new Regex(@"[a-zA-z]");

            Regex numeros = new Regex(@"[0-9]");
            
            Regex caracEsp = new Regex("[!\"#\\$%&'()*+,-./:;=?@\\[\\]^_`{|}~]");
            
            if (!letras.IsMatch(contraseñaSinVerificar)) return false;
            if (!numeros.IsMatch(contraseñaSinVerificar)) return false;
            if (!caracEsp.IsMatch(contraseñaSinVerificar)) return false;
            return true;
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

    }
}
