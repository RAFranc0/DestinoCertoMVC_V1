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

namespace DestinoCertoMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly DCDbContext _context;

        public HomeController(DCDbContext context)
        {
            _context = context;
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
    }
}
