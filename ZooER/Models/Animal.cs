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

        // Navigation 
     
        [InverseProperty("Child")]
        public virtual ICollection<ChildParent> IsChildOf { get; set; }

        [InverseProperty("Parent")]
        public virtual ICollection<ChildParent> IsParentOf { get; set; }


    }
}
