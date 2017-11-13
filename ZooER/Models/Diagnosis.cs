using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooER.Models
{
    public class Diagnosis
    {
        public int ID { get; set; }

        [StringLength(60, ErrorMessage = "Max 30 and at least 3 characters allowed", MinimumLength = 3)]
        [Required]
        [Display(Name = "Diagnosis")]
        public string Description { get; set; }

        // Nav
        public virtual ICollection<Visit> Visits { get; set; }
    }
}
