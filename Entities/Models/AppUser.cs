using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class AppUser : IdentityUser<int>
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string About { get; set; }
        public string Image { get; set; }
        public string Phone { get; set; }
        public string Adress { get; set; }

        public List<About> Abouts { get; set; }
        public List<Skill> Skills { get; set; }
        public List<Resume> Resumes { get; set; }
        public List<Portfolio> Portfolios { get; set; }
        public List<PortfolioCategory> PortfolioCategories { get; set; }
    }
}
