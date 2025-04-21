using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Skill : BaseEntity
    {
        [Display(Name = "Başlık")]
        [Required(ErrorMessage = "{0} alanı boş geçilemez.")]
        public string Title { get; set; }
        [Display(Name = "Oran")]
        [Required(ErrorMessage = "{0} alanı boş geçilemez.")]
        [Range(1, 99, ErrorMessage = "Oran 1 ile 99 arasında olmalıdır.")]
        public int? Number { get; set; }
    }
}
