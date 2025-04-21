using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class About : BaseEntity
    {
        public string Image { get; set; }
        public string Unvan { get; set; }
     
        public string Description { get; set; }

    }
}
