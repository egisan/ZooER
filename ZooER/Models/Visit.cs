using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooER.Models
{
    public class Visit
    {
        public int ID { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Start { get; set; }

        [DisplayFormat(NullDisplayText = "END Date not set")]
        public DateTime? End { get; set; }

        // Nav
        [Required]
        public virtual Animal Animal { get; set; }
        [Required]
        public virtual Diagnosis Diagnosis { get; set; }
        [Required]
        public virtual Veterinary Veterinary { get; set; }

        public virtual ICollection<Drug> Drugs { get; set; }



    }
}
