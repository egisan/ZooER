using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZooER.Models
{
    public class ChildParent
    {
        public int ID { get; set; }

        [ForeignKey ("Child")]
        public int? ChildID { get; set; }

        // I test 2 ways of defining FK in this entity
        public int? ParentID { get; set; }

        // Navigation

        public virtual Animal Child { get; set; }

        [ForeignKey("ParentID")]
        public virtual Animal Parent { get; set; }

    }
}
