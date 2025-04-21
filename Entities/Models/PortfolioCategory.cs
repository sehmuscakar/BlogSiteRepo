using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class PortfolioCategory:BaseEntity
    {
        public string Name { get; set; }
        public List<Portfolio> Portfolios { get; set; }

    }
}
