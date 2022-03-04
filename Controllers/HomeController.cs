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
        
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        // return view UntukValidasi dengan arrow function
        public IActionResult UntukFormValidasi() => View();

        [HttpPost]
        public IActionResult UntukFormValidasi(ContohModelUntukValidasi data)
        {
            if (ModelState.IsValid) return Ok(data);
            return View(data);
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
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
