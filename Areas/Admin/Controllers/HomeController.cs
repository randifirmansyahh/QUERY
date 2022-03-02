﻿using Microsoft.AspNetCore.Authorization;
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
        private readonly AppDbContext _context;
        private readonly FileService _file;

        public HomeController(AppDbContext context, FileService f)
        {
            _context = context;
            _file = f;
        }

        // GET: Blog
        public IActionResult Index()
        {
            //var data = TampilkanSemuaBlog(); // get 1 model

            var banyakData = new BlogDashboard(); // dari model Blog

            banyakData.blog = TampilkanSemuaBlog();
            banyakData.user = _context.Tb_User.ToList();
            banyakData.roles = _context.Tb_Roles.ToList();

            //var data2 = User.GetUsername(); // cari username di cookie helper/DapatkanIdentity.cs

            return View(banyakData);
        }

        // GET: Blog/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var blog = await _context.Tb_Blog
                .FirstOrDefaultAsync(m => m.Id == id);
            if (blog == null)
            {
                return NotFound();
            }

            return View(blog);
        }

        // GET: Blog/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Blog/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Blog blog, IFormFile Image)
        {
            if (ModelState.IsValid)
            {
                blog.Id = BuatPrimariKey.BuatPrimaryDenganGuild();
                blog.User = CariUserByUsername(User.GetUsername()); // mengisi field user
                blog.Image = await _file.SimpanFile(Image);
                
                _context.Add(blog);
                await _context.SaveChangesAsync();

                return RedirectToAction("Index");
            }
            return View(blog);
        }

        // GET: Blog/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }
            id = id.ToString();
            var blog = await _context.Tb_Blog.FindAsync(id);
            if (blog == null)
            {
                return NotFound();
            }
            return View(blog);
        }

        // POST: Blog/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Blog blog, IFormFile Foto)
        {
            if (blog.Id==null)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if(Foto != null)
                    {
                        blog.Image = await _file.SimpanFile(Foto);
                    }

                    _context.Update(blog);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BlogExists(blog.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(blog);
        }

        // GET: Blog/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var blog = await _context.Tb_Blog
                .FirstOrDefaultAsync(m => m.Id == id);
            if (blog == null)
            {
                return NotFound();
            }

            return View(blog);
        }

        // POST: Blog/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var blog = await _context.Tb_Blog.FindAsync(id);
            _context.Tb_Blog.Remove(blog);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BlogExists(string id)
        {
            return _context.Tb_Blog.Any(e => e.Id == id);
        }

        private Models.User CariUserByUsername(string user)
        {
            return _context.Tb_User.FirstOrDefault(x => x.Username == user);
        }

        private List<Blog> TampilkanSemuaBlog()
        {
            return _context.Tb_Blog
                .Include(x => x.User)
                .ToList();
        }

        private List<Blog> BlogsByUsername(string username)
        {
            var cari = CariUserByUsername(username); // cari data
            return _context.Tb_Blog.Where(x => x.User == cari).ToList();
        }
    }
}