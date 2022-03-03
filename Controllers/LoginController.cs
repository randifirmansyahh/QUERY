using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QUERY.Data;
using QUERY.Helper;
using QUERY.Models;
using QUERY.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace QUERY.Controllers
{
    public class LoginController : Controller
    {
        private readonly AppDbContext _context;
        private readonly EmailService _email;
        private static int _OTP;

        public LoginController(AppDbContext context, EmailService e)
        {
            _context = context;
            _email = e;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(User parameter)
        {
            var cariUser = _context.Tb_User
                .Where(x => x.Username == parameter.Username
                    && x.Password == parameter.Password)
                .Include(x => x.Roles)
                .FirstOrDefault();

            if (cariUser != null)
            {
                var claims = new List<Claim> {
                    new Claim("Username", cariUser.Username),
                    new Claim("Role", cariUser.Roles.Id)
                };

                await HttpContext.SignInAsync(new ClaimsPrincipal(
                    new ClaimsIdentity(claims, "Cookies", "Username", "Role")
                    ));

                if (cariUser.Roles.Id == "1")
                {
                    return Redirect("/Admin/Home");
                }
                else if (cariUser.Roles.Id == "2")
                {
                    return Redirect("/User/Home");
                }

                return Redirect("/Index");
            }

            if (!string.IsNullOrEmpty(parameter.Username) && !string.IsNullOrEmpty(parameter.Password))
            {
                ViewBag.Pesan = "Pengguna tidak ditemukan";
            }

            return View(parameter);
        }

        public IActionResult Daftar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Daftar(User parameter, int otp)
        {
            if (otp == _OTP)
            {
                Roles cariRoles = _context.Tb_Roles.FirstOrDefault(x => x.Id == "2");

                parameter.Roles = cariRoles;

                _context.Tb_User.Add(parameter);
                _context.SaveChanges();

                return RedirectToAction("Index");
            }
            return View(parameter);
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return Redirect("/");
        }

        [HttpPost]
        public string KirimEmailOTP(string emailTujuan)
        {
            // cari email ke database
            var cariEmail = _context.Tb_User.FirstOrDefault(x => x.Email == emailTujuan);

            // pengecekan email
            // != null berarti email ditemukan
            if (cariEmail != null) return "Email tersebut sudah digunakan";

            BanyakBantuan _bantu = new();
            _OTP = _bantu.BuatOTP(); // dari helper, dan memasukan ke variable _OTP diatas

            // mengisi email
            string subjeknya = "Konfirmasi email untuk daftar akun";
            // bisa diisi html seperti img, a href, button, dll
            string isiEmailnya =
                "<h1>Berikut OTP anda <i style='color: red;'>"
                + _OTP.ToString()
                + "</i></h1>"
                + "<a href='mailto:dotnetlanjutan@gmail.com?subject=Bantuan&body=Halo'>Bantuan</a>";

            // dari services/EmailService.cs
            bool cek = _email.KirimEmail(emailTujuan, subjeknya, isiEmailnya); // return nya true atau false

            // cek jika true
            if (cek) return "Kode OTP berhasil dikirimkan ke " + emailTujuan;

            // jika false
            return "Email " + emailTujuan + " tidak ditemukan";
        }
    }
}