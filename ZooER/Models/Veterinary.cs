using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooER.Models
{
    public class Veterinary
    {
        public int VeterinaryId { get; set; }

        [StringLength(30, ErrorMessage = "Max 30 and at least 3 characters allowed", MinimumLength = 3)]
       // [Required]
        public string Name { get; set; }

        // Nav
        public virtual ICollection<Visit> Visits { get; set; }
    }
}
