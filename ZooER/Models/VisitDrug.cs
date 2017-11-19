﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooER.Models
{
    // I could let Bridge table be autogenerated by CodeFirst
    // but I need to have nullable FK in it and therefore I
    // defined it explicitly

    public class VisitDrug
    {
        public int ID { get; set; }
        public int? VisitID { get; set; }
        public int? DrugID { get; set; }

        public virtual Visit Visit { get; set; }
        public virtual Drug Drug { get; set; }
    }
}
