using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QUERY.Data;
using QUERY.Helper;
using QUERY.Models;
using QUERY.Services;
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

        public HomeController(IBlogService b)
        {
            _service = b;
        }

        public IActionResult Index()
        {
            var banyakData = new BlogDashboard(); // dari model Blog

            banyakData.blog = _service.AmbilSemuaBlog();
            banyakData.user = _service.AmbilSemuaUser();
            banyakData.roles = _service.AmbilSemuaRoles();

            return View(banyakData);
        }

        public IActionResult Details(string id)
        {
            Blog cari = _service.AmbilBlogBerdasarkanId(id);

            if (cari != null)
            {
                return View(cari);
            }
            return NotFound();
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Blog blog, IFormFile Image)
        {
            if (ModelState.IsValid)
            {
                _service.BuatBlogBaru(User.GetUsername(), blog, Image);
                return Redirect("/Admin/Home/Details/" + blog.Id);
            }
            return View(blog);
        }

        public IActionResult Edit(string id)
        {
            var cari = _service.AmbilBlogBerdasarkanId(id);

            if (cari != null)
            {
                return View(cari);
            }
            return NotFound();
        }

        [HttpPost]
        public IActionResult Edit(Blog blog, IFormFile Foto)
        {
            if (ModelState.IsValid)
            {
                var cari = _service.AmbilBlogBerdasarkanId(blog.Id);

                if (cari != null)
                {
                    _service.UbahBlog(blog, Foto);

                    return Redirect("/Admin/Home/Details/" + blog.Id);
                }
                return NotFound();
            }
            return View(blog);
        }

        public IActionResult Delete(string id)
        {
            var cari = _service.AmbilBlogBerdasarkanId(id);

            if (cari != null)
            {
                _service.HapusBlog(id);
                return RedirectToAction("Index");
            }
            return NotFound();
        }
    }
}
