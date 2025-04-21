using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Resume: BaseEntity
    {
        public string Uzmanlik { get; set; }
        public string WorkRage { get; set; }
        public string Konum { get; set; }
        public string Description { get; set; }
    }
}
