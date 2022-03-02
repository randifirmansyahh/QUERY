using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using QUERY.Helper;
using QUERY.Models;
using QUERY.Services.BlogService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QUERY.Areas.Admin.Controllers
{
    [Authorize]
    [Area("Admin")]
    public class HomeController : Controller
    {
        private readonly IBlogService _service;
        public HomeController(IBlogService s)
        {
            _service = s;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Blog datanya)
        {
            _service.BuatBlogBaru(User.GetUsername(), datanya);
            return RedirectToAction("Index");
        }
    }
}
