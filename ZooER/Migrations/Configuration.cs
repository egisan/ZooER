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

            AddAnimals();
            AddDiagnosis();
            AddVets();
            AddDrugs();
            AddVisits();

            /*
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
            */

        }


        private void AddAnimals()
        {
            context.Animals.AddOrUpdate(
                x => x.Name,
                    new Animal
                    {
                        Name = "Eagle",
                        Weight = 15.1,
                        Habitat = new Habitat { Name = "Tree" },
                        Species = new Species { Name = "Birds" },
                        Diet = new Diet { Name = "Carnivors" },
                        Origin = new Origin { Name = "North America" },
                        // Visits = new List<Visit> { new Visit { Start = new DateTime(2017, 10, 02), End = new DateTime(2017, 10, 03) } }
                    },

                    new Animal
                    {
                        Name = "Horse",
                        Weight = 300.3,
                        Habitat = new Habitat { Name = "Ground" },
                        Species = new Species { Name = "Mammals" },
                        Diet = new Diet { Name = "Vegetarian" },
                        Origin = new Origin { Name = "North America" },
                        // Visits = new List<Visit> { new Visit { Start = new DateTime(2017, 06, 10), End = new DateTime(2017, 06, 11) } }
                    },

                    new Animal
                    {
                        Name = "Dog",
                        Weight = 15.4,
                        Habitat = new Habitat { Name = "Ground" },
                        Species = new Species { Name = "Mammals" },
                        Diet = new Diet { Name = "Carnivor" },
                        Origin = new Origin { Name = "Europe" },
                        Visits = new List<Visit> { new Visit { Start = new DateTime(2017, 11, 3), End = new DateTime(2017, 11, 5) } }
                    },

                    new Animal
                    {
                        Name = "Cat",
                        Weight = 9.0,
                        Habitat = new Habitat { Name = "Ground" },
                        Species = new Species { Name = "Mammals" },
                        Diet = new Diet { Name = "Carnivor" },
                        Origin = new Origin { Name = "Europe" },
                        // Visits = new List<Visit> { new Visit { Start = new DateTime(2017, 03, 16), End = new DateTime(2017, 03, 18) } }
                    },

                    new Animal
                    {
                        Name = "Wale",
                        Weight = 1200.2,
                        Habitat = new Habitat { Name = "Sea" },
                        Species = new Species { Name = "Mammals" },
                        Diet = new Diet { Name = "Carnivor" },
                        Origin = new Origin { Name = "North America" },
                        // Visits = new List<Visit> { new Visit { Start = new DateTime(2017, 03, 16), End = new DateTime(2017, 03, 18) } }
                    }
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
                       Animal = context.Animals.Where(c => c.Name == "Eagle").FirstOrDefault(),
                       Diagnosis = context.Diagnosises.Where(c => c.Description == "Flu").FirstOrDefault(),
                       Veterinary = context.Veterinaries.Where(c => c.Name == "Francisco Manzano").FirstOrDefault(),
                       Drugs = context.Drugs.Where(c => c.Name == "Drug 1" && c.Name == "Drug 2").ToList()
                   },

                   new Visit
                   {
                       Start = new DateTime(2017, 06, 10),
                       End = new DateTime(2017, 06, 11),
                       Animal = context.Animals.Where(c => c.Name == "Horse").FirstOrDefault(),
                       Diagnosis = context.Diagnosises.Where(c => c.Description == "Hart failure").FirstOrDefault(),
                       Veterinary = context.Veterinaries.Where(c => c.Name == "Anders Fredriksson").FirstOrDefault(),
                       Drugs = context.Drugs.Where(c => c.Name == "Drug 2" && c.Name == "Drug 3").ToList()
                   },

                   new Visit
                   {
                       Start = new DateTime(2017, 11, 3),
                       End = new DateTime(2017, 11, 5),
                       Animal = context.Animals.Where(c => c.Name == "Dog").FirstOrDefault(),
                       Diagnosis = context.Diagnosises.Where(c => c.Description == "Low blod pressure").FirstOrDefault(),
                       Veterinary = context.Veterinaries.Where(c => c.Name == "Anders Fredriksson").FirstOrDefault(),
                       Drugs = context.Drugs.Where(c => c.Name == "Drug 4").ToList()
                   },

                   new Visit
                   {
                       Start = new DateTime(2017, 03, 16),
                       End = new DateTime(2017, 03, 18),
                       Animal = context.Animals.Where(c => c.Name == "Cat").FirstOrDefault(),
                       Diagnosis = context.Diagnosises.Where(c => c.Description == "Trauma").FirstOrDefault(),
                       Veterinary = context.Veterinaries.Where(c => c.Name == "Helena Lindeberg").FirstOrDefault(),
                       Drugs = context.Drugs.Where(c => c.Name == "Drug 1").ToList()
                   }
           );
        }

    }
}
