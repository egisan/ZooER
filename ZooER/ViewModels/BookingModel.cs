using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooER.ViewModels
{
    public class BookingModel
    {
        public int Id { get; set; }

        [Display(Name = "Doctor")]
        public string DoctorName { get; set; }

        [Display(Name = "Patient Name")]
        public string NamePatient { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm}", ApplyFormatInEditMode = true)]
        [Display(Name = "Time booked")]
        public DateTime TimeBooked { get; set; }

        public string Diagnosis { get; set; }
        public string Drugs { get; set; } // I will concatenate the drugs
    }
}
