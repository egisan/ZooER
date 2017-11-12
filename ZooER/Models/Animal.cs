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

        public int ID { get; set; }
        public string Name { get; set; }
        public double Weight { get; set; }

        // Navigation to Link table Children-Parents
     
        [InverseProperty("Child")]
        public virtual ICollection<ChildParent> IsChildOf { get; set; }

        [InverseProperty("Parent")]
        public virtual ICollection<ChildParent> IsParentOf { get; set; }

        // Nav to other entities
        public virtual Habitat Habitat { get; set; }
        public virtual Species Species { get; set; }
        public virtual Diet Diet { get; set; }
        public virtual Origin Origin { get; set; }
        public virtual ICollection<Visit> Visits { get; set; }

    }
}
