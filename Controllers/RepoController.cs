using Microsoft.AspNetCore.Mvc;
using QUERY.Helper;
using QUERY.Models;
using QUERY.Services;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace QUERY.Controllers
{
    [Route("repo")]
    public class RepoController : Controller
    {
        private readonly IBlogService _blog;

        public RepoController(IBlogService blog)
        {
            _blog = blog;
        }

        [Route("semua")]
        public async Task<ActionResult<List<Blog>>> TampilkanSemuaBlog()
        {
            return View("Index", await _blog.AmbilSemuaBlogAsync());
        }

        public IActionResult Buat()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult<Blog>> Buat(Blog dariView)
        {
            if (ModelState.IsValid)
            {
                string username = User.GetUsername().ToString(); // dari helper
                await _blog.BuatBlogBaru(username, dariView);
                return RedirectToAction("semua");
            }
            return View(dariView);
        }

        [Route("ubah/{id}")]
        public async Task<ActionResult<Blog>> Perbarui(string id)
        {
            return View("Ubah", await _blog.AmbilBlogBerdasarkanIdAsync(id));
        }

        [HttpPost]
        [Route("ubah")]
        public async Task<ActionResult<Blog>> Perbarui(Blog dariView)
        {
            if (ModelState.IsValid)
            {
                await _blog.UbahBlogAsync(dariView);
                return Redirect("cari/" + dariView.Id);
            }
            return View(dariView);
        }

        [Route("cari/{id}")]
        public async Task<ActionResult<Blog>> Detail(string id)
        {
            return View("Detail", await _blog.AmbilBlogBerdasarkanIdAsync(id));
        }
    }
}