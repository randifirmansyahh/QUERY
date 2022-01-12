using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using QUERY.Data;
using QUERY.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace QUERY.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly AppDbContext _context;

        public HomeController(ILogger<HomeController> logger, AppDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            var cekRoles = _context.Tb_Roles.ToList();

            if (cekRoles.Count < 2)
            {
                var Tambah = new Roles[]{ 
                    new Roles { Id = "1", Name = "Admin" }, 
                    new Roles { Id = "2", Name = "User" }
                };
                _context.Add(Tambah[0]);
                _context.Add(Tambah[1]);
                _context.SaveChangesAsync();
            }

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
