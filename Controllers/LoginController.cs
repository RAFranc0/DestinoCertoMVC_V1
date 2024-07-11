using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using DestinoCertoMVC.Data;
using DestinoCertoMVC.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;

namespace DestinoCertoMVC.Controllers
{
    public class LoginController : Controller
    {
        private readonly DCDbContext _context;

        public LoginController(DCDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> LoginUsuarioAsync(LoginModel loginTry)
        {
            TempData["ErrorMessage"] = "";

            if (ModelState.IsValid)
            {
                var user = _context.Usuarios.FirstOrDefault(u =>
                    u.Login == loginTry.Login && u.Senha == loginTry.Senha
                );

                if (user != null)
                {
                    TempData["ErrorMessage"] = "";

                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                        new Claim(ClaimTypes.Name, user.Nome)
                    };

                    var claimsIdentity = new ClaimsIdentity(
                        claims,
                        CookieAuthenticationDefaults.AuthenticationScheme
                    );

                    await HttpContext.SignInAsync(
                        CookieAuthenticationDefaults.AuthenticationScheme,
                        new ClaimsPrincipal(claimsIdentity)
                    );

                    return RedirectToAction("MenuUsuario", "Home");
                }
            }
            return RedirectToAction("Index", "Home");
        }
    }
}
