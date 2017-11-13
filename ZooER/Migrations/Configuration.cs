namespace ZooER.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using ZooER.Models;
    using ZooER.DAL;
    using System.Collections.Generic;

    internal sealed class Configuration : DbMigrationsConfiguration<ZooContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "ZooER.DAL.ZooContext";
        }

        public ZooContext context { get; set; }

        protected override void Seed(ZooContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            // Add first the Entities on the "one" side

            this.context = context;

            context.Species.AddOrUpdate(
                x => x.Name,
                    new Species { Name = "Mammals" },
                    new Species { Name = "Reptiles" },
                    new Species { Name = "Birds" }
            );

            context.Habitats.AddOrUpdate(
                x => x.Name,
                    new Habitat { Name = "Ground" },
                    new Habitat { Name = "Tree" },
                    new Habitat { Name = "Sea" }
            );

            context.Diets.AddOrUpdate(
                x => x.Name,
                    new Diet { Name = "Vegetarian" },
                    new Diet { Name = "Carnivor" }
            );

            context.Origins.AddOrUpdate(
                x => x.Name,
                    new Origin { Name = "Africa" },
                    new Origin { Name = "Asia" },
                    new Origin { Name = "North America" },
                    new Origin { Name = "Sounth America" },
                    new Origin { Name = "Central America" },
                    new Origin { Name = "Europe" },
                    new Origin { Name = "Australia" }
            );

          // AddAnimals();
           // AddDiagnosis();
           // AddVets();
         //   AddDrugs();
            AddVisits();

        }


        private void AddAnimals()
        {
            context.Animals.AddOrUpdate(
                x => x.Name,
                    new Animal
                    {
                        Name = "Eagle",
                        Weight = 15.1,
                        Habitat = new Habitat(),
                        Species = new Species(),
                        Diet = new Diet(),
                        Origin = new Origin(),
                        Visits = new List<Visit>(),

                        IsChildOf = new List<Animal>(),
                        IsParentOf = new List<ChildParent>()

                        //  Habitat = context.Habitats.Where(c => c.Name == "Tree").FirstOrDefault(),
                        //  Species = context.Species.Where(c => c.Name == "Birds").FirstOrDefault(),
                        //   Diet = context.Diets.Where(c => c.Name == "Carnivors").FirstOrDefault(),
                        //   Origin = context.Origins.Where( c => c.Name == "North America").FirstOrDefault(),
                        // Visits = new List<Visit> { new Visit { Start = new DateTime(2017, 10, 02), End = new DateTime(2017, 10, 03) } }
                    }

                    //new Animal
                    //{
                    //    Name = "Horse",
                    //    Weight = 300.3,
                    //    //Habitat = context.Habitats.Where(c => c.Name == "Ground").FirstOrDefault(),
                    //    //Species = context.Species.Where(c => c.Name == "Mammals").FirstOrDefault(),
                    //    //Diet = context.Diets.Where(c => c.Name == "Vegetarian").FirstOrDefault(),
                    //    //Origin = context.Origins.Where(c => c.Name == "North America").FirstOrDefault()
                    //    // Visits = new List<Visit> { new Visit { Start = new DateTime(2017, 06, 10), End = new DateTime(2017, 06, 11) } }
                    //},

                    //new Animal
                    //{
                    //    Name = "Dog",
                    //    Weight = 15.4,
                    //    //Habitat = context.Habitats.Where(c => c.Name == "Ground").FirstOrDefault(),
                    //    //Species = context.Species.Where(c => c.Name == "Mammals").FirstOrDefault(),
                    //    //Diet = context.Diets.Where(c => c.Name == "Carnivor").FirstOrDefault(),
                    //    //Origin = context.Origins.Where(c => c.Name == "Europe").FirstOrDefault(),
                    //    //  Visits = new List<Visit> { new Visit { Start = new DateTime(2017, 11, 3), End = new DateTime(2017, 11, 5) } }
                    //},

                    //new Animal
                    //{
                    //    Name = "Cat",
                    //    Weight = 9.0,
                    //    //Habitat = context.Habitats.Where(c => c.Name == "Ground").FirstOrDefault(),
                    //    //Species = context.Species.Where(c => c.Name == "Mammals").FirstOrDefault(),
                    //    //Diet = context.Diets.Where(c => c.Name == "Carnivor").FirstOrDefault(),
                    //    //Origin = context.Origins.Where(c => c.Name == "Europe").FirstOrDefault(),
                    //    // Visits = new List<Visit> { new Visit { Start = new DateTime(2017, 03, 16), End = new DateTime(2017, 03, 18) } }
                    //},

                    //new Animal
                    //{
                    //    Name = "Wale",
                    //    Weight = 1200.2,
                    //    //Habitat = context.Habitats.Where(c => c.Name == "Sea").FirstOrDefault(),
                    //    //Species = context.Species.Where(c => c.Name == "Mammals").FirstOrDefault(),
                    //    //Diet = context.Diets.Where(c => c.Name == "Carnivor").FirstOrDefault(),
                    //    //Origin = context.Origins.Where(c => c.Name == "North America").FirstOrDefault(),
                    //    // Visits = new List<Visit> { new Visit { Start = new DateTime(2017, 03, 16), End = new DateTime(2017, 03, 18) } }
                    //}
            );
        }

        private void AddDiagnosis()
        {
            context.Diagnosises.AddOrUpdate(
               x => x.ID,
                    new Diagnosis { Description = "Flu" },
                    new Diagnosis { Description = "Hart failure" },
                    new Diagnosis { Description = "Low blod pressure" },
                    new Diagnosis { Description = "Trauma" }
            );

            
        }

        private void AddVets()
        {
            context.Veterinaries.AddOrUpdate(
                x => x.Name,
                    new Veterinary { Name = "Francisco Manzano" },
                    new Veterinary { Name = "Anders Fredriksson" },
                    new Veterinary { Name = "Lotta Lindeberg" },
                    new Veterinary { Name = "Helena Lindeberg" }
            );
        }

        private void AddDrugs()
        {
            context.Drugs.AddOrUpdate(
               x => x.Name,
                   new Drug { Name = "Drug 1" },
                   new Drug { Name = "Drug 2" },
                   new Drug { Name = "Drug 3" },
                   new Drug { Name = "Drug 4" }
            );
        }


        private void AddVisits()
        {
            context.Visits.AddOrUpdate(
               x => x.ID,
                   new Visit
                   {
                       Start = new DateTime(2017, 10, 02),
                       End = new DateTime(2017, 10, 03),
                      // Animal = context.Animals.Where(c => c.Name == "Eagle").FirstOrDefault(),
                       Diagnosis = context.Diagnosises.Where(c => c.Description == "Flu").FirstOrDefault(),
                       Veterinary = context.Veterinaries.Where(c => c.Name == "Francisco Manzano").FirstOrDefault(),
                       Drugs = context.Drugs.Where(c => c.Name == "Drug 1" && c.Name == "Drug 2").ToList()
                   },

                   new Visit
                   {
                       Start = new DateTime(2017, 06, 10),
                       End = new DateTime(2017, 06, 11),
                      // Animal = context.Animals.Where(c => c.Name == "Horse").FirstOrDefault(),
                       Diagnosis = context.Diagnosises.Where(c => c.Description == "Hart failure").FirstOrDefault(),
                       Veterinary = context.Veterinaries.Where(c => c.Name == "Anders Fredriksson").FirstOrDefault(),
                       Drugs = context.Drugs.Where(c => c.Name == "Drug 2" && c.Name == "Drug 3").ToList()
                   },

                   new Visit
                   {
                       Start = new DateTime(2017, 11, 3),
                       End = new DateTime(2017, 11, 5),
                      // Animal = context.Animals.Where(c => c.Name == "Dog").FirstOrDefault(),
                       Diagnosis = context.Diagnosises.Where(c => c.Description == "Low blod pressure").FirstOrDefault(),
                       Veterinary = context.Veterinaries.Where(c => c.Name == "Anders Fredriksson").FirstOrDefault(),
                       Drugs = context.Drugs.Where(c => c.Name == "Drug 4").ToList()
                   },

                   new Visit
                   {
                       Start = new DateTime(2017, 03, 16),
                       End = new DateTime(2017, 03, 18),
                     //  Animal = context.Animals.Where(c => c.Name == "Cat").FirstOrDefault(),
                       Diagnosis = context.Diagnosises.Where(c => c.Description == "Trauma").FirstOrDefault(),
                       Veterinary = context.Veterinaries.Where(c => c.Name == "Helena Lindeberg").FirstOrDefault(),
                       Drugs = context.Drugs.Where(c => c.Name == "Drug 1").ToList()
                   }
           );
        }

    }
}
