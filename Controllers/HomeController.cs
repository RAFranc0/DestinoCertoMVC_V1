using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using DestinoCertoMVC.Data;
using DestinoCertoMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace DestinoCertoMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly DCDbContext _context;

        public HomeController(DCDbContext context)
        {
            _context = context;
        }

        public IActionResult TesteDb()
        {
            var usuarios = _context.Usuarios.ToList();
            var pacotes = _context.Pacotes.ToList();

            ViewBag.Usuarios = usuarios;
            ViewBag.Pacotes = pacotes;

            return View();
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult MenuUsuario()
        {
            return View();
        }

        public IActionResult Vitrine()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(
                new ErrorViewModel
                {
                    RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
                }
            );
        }
    }
}
