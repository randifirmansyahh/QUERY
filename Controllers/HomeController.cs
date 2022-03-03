using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using QUERY.Data;
using QUERY.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

        // return view UntukValidasi
        public IActionResult UntukFormValidasi() => View();

        [HttpPost]
        public IActionResult UntukFormValidasi(ContohModelUntukValidasi data)
        {
            if (ModelState.IsValid) return Ok(data);
            return View(data);
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

                foreach (var item in Tambah)
                {
                    _context.Add(item);
                }
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

        public string CekValidasi([RegularExpression(@"^[0-9]*$")] string Cek)
        {
            if (ModelState.IsValid)
            {
                return Cek;
            }
            return "salah, harus angka";
        }
    }
}
