using Entities.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework.Context
{ 
    public class ProjeContext : IdentityDbContext<AppUser, AppRole, int>  //: dbcontext
    {
        public DbSet<About> Abouts { get; set; }
        public DbSet<Resume> Resumes { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Portfolio> Portfolios { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<PortfolioCategory> PortfolioCategories { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) // ovveride on yaz gerisi gelir
        {
            optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS;  database=BlogSite; integrated security=true; TrustServerCertificate=true");
            base.OnConfiguring(optionsBuilder);
        }

    }
}
