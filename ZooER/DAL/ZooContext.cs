using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooER.Models;
using System.Data.Entity;

namespace ZooER.DAL
{
    class ZooContext : DbContext
    {
        public ZooContext() : base ("ZooER")
        {
        }

        public DbSet<Animal> Animals { get; set; }
        public DbSet<ChildParent> ChildrenParents { get; set; }

        public DbSet<Habitat> Habitats { get; set; }
        public DbSet<Species> Species  { get; set; }
        public DbSet<Diet> Diets { get; set; }
        public DbSet<Origin> Origins { get; set; }
        public DbSet<Diagnosis> Diagnosises { get; set; }
        public DbSet<Visit> Visits { get; set; }
        public DbSet<Drug> Drugs { get; set; }
        public DbSet<Veterinary> Veterinaries { get; set; }


    }


}
