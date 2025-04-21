using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class BaseEntity : IEntity
    {
        //   Ortak Alanları Tek Bir Yerde Tanımlar: Id, Ad, Soyad, Image gibi tüm entity'lerde olması gereken alanları burada tanımlarsın.
        public int Id { get; set; }
        public int? AppUserId { get; set; }
        public virtual AppUser AppUser { get; set; }
    }
}
