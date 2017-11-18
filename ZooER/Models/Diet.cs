using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooER.Models
{
    public class Diet
    {
        public int DietId { get; set; }

        [StringLength(30, ErrorMessage = "Max 30 and at least 3 characters allowed", MinimumLength = 3)]
        [Index(IsUnique = true)]
        [Display(Name = "Diet type")]
        public string Name { get; set; }

        // Nav
        public virtual ICollection<Animal> Animals { get; set; }
    }
}
