namespace ZooER.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using ZooER.Models;
    using ZooER.DAL;

    internal sealed class Configuration : DbMigrationsConfiguration<ZooER.DAL.ZooContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "ZooER.DAL.ZooContext";
        }

        protected override void Seed(ZooER.DAL.ZooContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            context.Animals.AddOrUpdate(
                x => x.Name,
                    new Animal { Name = "Eagle", Weight = 15.1 },
                    new Animal { Name = "Horse", Weight = 300.3 },
                    new Animal { Name = "Dog", Weight = 15.4 },
                    new Animal { Name = "Cat", Weight = 9.0 },
                    new Animal { Name = "Wale", Weight = 1200.2 }
            );

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
                    new Habitat { Name = "Water" }
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

            context.Diagnosises.AddOrUpdate(
               x => x.ID,
                    new Diagnosis { Description = "Flu" },
                    new Diagnosis { Description = "Hart failure" },
                    new Diagnosis { Description = "Low blod pressure" },
                    new Diagnosis { Description = "Trauma" }
            );

            context.Veterinaries.AddOrUpdate(
                x => x.Name,
                    new Veterinary { Name = "Francisco Manzano" },
                    new Veterinary { Name = "Anders Fredriksson" },
                    new Veterinary { Name = "Lotta Lindeberg" },
                    new Veterinary { Name = "Helena Lindeberg" }
            );

            context.Drugs.AddOrUpdate(
               x => x.Name,
                   new Drug { Name = "Drug 1" },
                   new Drug { Name = "Drug 2" },
                   new Drug { Name = "Drug 3" },
                   new Drug { Name = "Drug 4" }
            );

            context.Visits.AddOrUpdate(
               x => x.ID,
                   new Visit { Start = new DateTime(2017, 10, 02), End = new DateTime(2017, 10, 03) },
                   new Visit { Start = new DateTime(2017, 06, 10), End = new DateTime(2017, 06, 11) },
                   new Visit { Start = new DateTime(2017, 11, 3), End = new DateTime(2017, 11, 5) },
                   new Visit { Start = new DateTime(2017, 03, 16), End = new DateTime(2017, 03, 18) }
           );
        } 
    }
}
