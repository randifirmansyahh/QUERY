using Microsoft.AspNetCore.Mvc;
using QUERY.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QUERY.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Masuk(User parameter)
        {
            return Ok(parameter);
        }
    }
}