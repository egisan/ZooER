using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooER.ViewModels
{
    public class BookingModel
    {
        public int Id { get; set; }
        
        public DateTime TimeBooked { get; set; }
        public string Diagnosis { get; set; }
        public List<string> Drugs { get; set; }
    }
}
