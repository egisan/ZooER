using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooER.Models
{
    public class Habitat
    {
        public int ID { get; set; }
        public string Name { get; set; }

        // Nav
        public virtual ICollection<Animal> Animals { get; set; }
    }
}
