using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel; // Used for DisplayName (annotation) which is Different from Display ("Origin")
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

        [DisplayName("Habitat")]
        public string HabitatType { get; set; }

        [DisplayName("Diet")]
        public string DietType { get; set; }

        [DisplayName("Origin")]
        public string OriginCountry { get; set; }

        [DisplayName("Species")]
        public string SpeciesType { get; set; }

        [DisplayName("Parent 1")]
        public string Parent1 { get;  set; }

        [DisplayName("Parent 2")]
        public string Parent2 { get; set; }

        [DisplayName("Booked visits")]
        public List<Visit> OwnVisits { get; set; }
    }
}
