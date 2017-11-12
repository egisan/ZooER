using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooER.Models
{
    public class Diagnosis
    {
        public int ID { get; set; }
        public string Description { get; set; }

        // Nav
        public virtual ICollection<Visit> Visits { get; set; }
    }
}
