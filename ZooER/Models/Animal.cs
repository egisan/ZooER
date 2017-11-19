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
        // TEst
        public int AnimalId { get; set; }

        [Required]
        [StringLength(30, ErrorMessage = "Max 30 and at least 3 characters allowed", MinimumLength = 3)]
        public string Name { get; set; }

        public double Weight { get; set; }

        // Nav to other entities & Explicit FK declaration
        // Explicit declaring the FK to get Seed working
        //[Required]
        [ForeignKey("Habitat")]
        public int? HabitatId { get; set; }
        public virtual Habitat Habitat { get; set; }

        [ForeignKey("Species")]
        public int? SpeciesId { get; set; }
        public virtual Species Species { get; set; }

        [ForeignKey("Diet")]
        public int? DietId { get; set; }
        public virtual Diet Diet { get; set; }

        [ForeignKey("Origin")]
        public int? OriginId { get; set; }
        public virtual Origin Origin { get; set; }

        // Navigation to Link table Children-Parents
      //  [InverseProperty("Child")]
        public virtual ICollection<ChildParent> IsChildOf { get; set; }

      //  [InverseProperty("Parent")]
        public virtual ICollection<ChildParent> IsParentOf { get; set; }



        //// Navigation to Link table Children-Parents
        //[InverseProperty("IsParentOf")]
        //public virtual ICollection<Animal> IsChildOf { get; set; }

        //[InverseProperty("IsChildOf")]
        //public virtual ICollection<Animal> IsParentOf { get; set; }

        public virtual ICollection<Visit> Visits { get; set; }




        //public int AnimalId { get; set; }

        //[Required]
        //[StringLength(30, ErrorMessage = "Max 30 and at least 3 characters allowed", MinimumLength = 3)]
        //public string Name { get; set; }

        //public double Weight { get; set; }

        //// Nav to other entities & Explicit FK declaration
        //// Explicit declaring the FK to get Seed working
        ////[Required]
        //[ForeignKey("Habitat")]
        //public int? HabitatId { get; set; } 
        //public virtual Habitat Habitat { get; set; }

        //[ForeignKey("Species")]
        //public int? SpeciesId { get; set; }
        //public virtual Species Species { get; set; }

        //[ForeignKey("Diet")]
        //public int? DietId { get; set; }
        //public virtual Diet Diet { get; set; }

        //[ForeignKey("Origin")]
        //public int? OriginId { get; set; }
        //public virtual Origin Origin { get; set; }


        //// Navigation to Link table Children-Parents
        //[InverseProperty("IsParentOf")]
        //public virtual ICollection<Animal> IsChildOf { get; set; }

        //[InverseProperty("IsChildOf")]
        //public virtual ICollection<Animal> IsParentOf { get; set; }

        //public virtual ICollection<Visit> Visits { get; set; }
    }
}
