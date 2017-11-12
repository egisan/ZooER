using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooER.Models
{
    public class Visit
    {
        public int ID { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }

        // Nav
        public virtual Animal Animal { get; set; }
        public virtual Diagnosis Diagnosis { get; set; }
        public virtual Veterinary Veterinary { get; set; }

        public virtual ICollection<Drug> Drugs { get; set; }



    }
}
