using System;
using System.Collections.Generic;
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
        public string HabitatType { get; set; }
        public string DietType { get; set; }
        public string OriginCountry { get; set; }
        public string SpeciesType { get; set; }
        public Animal Mother { get;  set; }
        public Animal Father { get; set; }
        public List<Visit> OwnVisits { get; set; }
    }
}
