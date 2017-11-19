using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooER.Models
{
    public class Visit
    {
        public int VisitId { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd H:mm:ss}", ApplyFormatInEditMode = true)]
        public DateTime Start { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd H:mm:ss}", NullDisplayText = "END Date not set", ApplyFormatInEditMode = true)]
        public DateTime? End { get; set; }

        // Nav
        [ForeignKey("Animal")]
        public int AnimalId { get; set; }
        public virtual Animal Animal { get; set; }

        [ForeignKey("Diagnosis")]
        public int? DiagnosisId { get; set; }
        public virtual Diagnosis Diagnosis { get; set; }

        [ForeignKey("Veterinary")]
        public int? VeterinaryId { get; set; }
        public virtual Veterinary Veterinary { get; set; }

        public virtual ICollection<VisitDrug> Drugs { get; set; }



    }
}
