using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZooER.Models
{
    public class Animal
    {

        public  int ID { get; set; }

        [Required]
        [StringLength(30, ErrorMessage = "Max 30 and at least 3 characters allowed", MinimumLength = 3)]
        public string Name { get; set; }

        public double Weight { get; set; }

        // Navigation to Link table Children-Parents
     
        [InverseProperty("IsParentOf")]
        
        public virtual ICollection<Animal> IsChildOf { get; set; }

        [InverseProperty("IsChildOf")]
        public virtual ICollection<Animal> IsParentOf { get; set; }

        // Nav to other entities
        [Required]
        public virtual Habitat Habitat { get; set; }
        [Required]
        public virtual Species Species { get; set; }
        [Required]
        public virtual Diet Diet { get; set; }
        [Required]
        public virtual Origin Origin { get; set; }

        public virtual ICollection<Visit> Visits { get; set; }

    }
}
