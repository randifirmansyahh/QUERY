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
    }
}