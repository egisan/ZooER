using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooER.ViewModels
{
    public class CancelBookingModel
    {
        public int Id { get; set; }

        [Display(Name = "Doctor Name")]
        public string NameDoctor { get; set; }

        [Display(Name = "Patient Name")]
        public string NamePatient { get; set; }
    }
}
