using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooER.Models
{
    public class Drug
    {
        public int ID { get; set; }
        public string Name { get; set; }

        // Nav M-2-M
        public virtual ICollection<Visit> Visits { get; set; }
    }
}
