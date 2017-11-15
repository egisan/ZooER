using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooER.Models;

namespace ZooER.ViewModels
{
    public class AnimalDetails
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public double Weight { get; set; }

        [Display(Name = "Habitat")]
        public string HabitatType { get; set; }

        [Display(Name = "Diet")]
        public string DietType { get; set; }

        [Display(Name = "Origin")]
        public string OriginCountry { get; set; }

        [Display(Name = "Species")]
        public string SpeciesType { get; set; }

        [Display(Name = "Parent 1")]
        public string Parent1 { get;  set; }

        [Display(Name = "Parent 2")]
        public string Parent2 { get; set; }

        [Display(Name = "Booked visits")]
        public List<Visit> OwnVisits { get; set; }
    }
}
