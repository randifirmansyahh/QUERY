using Microsoft.EntityFrameworkCore;
using QUERY.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QUERY.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }
        public virtual DbSet<Blog> Tb_Blog { get; set; }
        public virtual DbSet<User> Tb_User { get; set; }
        public virtual DbSet<Roles> Tb_Roles { get; set; }


        // migrasi auto isi value ke database
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // isi tabel roles
            modelBuilder.Entity<Roles>().HasData(new Roles[]
            {
                new Roles
                {
                    Id = "1",
                    Name = "Admin"
                },
                new Roles
                {
                    Id = "2",
                    Name ="User"
                }
            });

            // isi tabel user
            modelBuilder.Entity<User>().HasData(new User
            {
                Username = "randi",
                Password = "randi",
                Name = "Randi Firmansyah",
                Email = "hehehe@gmail.com",
                Roles = null
            });

            modelBuilder.Entity<Blog>().HasData(new Blog
            {
                Id = "1",
                Title = "judulnya",
                Content = "kontennya",
                CreateDate = DateTime.Now,
                Image = "https://avatars.githubusercontent.com/u/87772215?v=4",
                Status = true,
                User = null // cape ngisi jadi di null wkwk
            });
        }
    }
}