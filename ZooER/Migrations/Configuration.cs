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

            //context.Species.AddOrUpdate(
            //    x => x.Name,
            //        new Species { Name = "Mammals" },
            //        new Species { Name = "Reptiles" },
            //        new Species { Name = "Birds" }
            //);


            //context.Habitats.AddOrUpdate(
            //    x => x.Name,
            //        new Habitat { Name = "Ground" },
            //        new Habitat { Name = "Tree" },
            //        new Habitat { Name = "Sea" }
            //);


            //context.Diets.AddOrUpdate(
            //    x => x.Name,
            //        new Diet { Name = "Vegetarian" },
            //        new Diet { Name = "Carnivor" }
            //);

            //context.Origins.AddOrUpdate(
            //    x => x.Name,
            //        new Origin { Name = "Africa" },
            //        new Origin { Name = "Asia" },
            //        new Origin { Name = "North America" },
            //        new Origin { Name = "Sounth America" },
            //        new Origin { Name = "Central America" },
            //        new Origin { Name = "Europe" },
            //        new Origin { Name = "Australia" }
            //);

            AddAnimals();
            // AddDiagnosis();
            // AddVets();
            //   AddDrugs();
            // AddVisits();

        }


        private void AddAnimals()
        {
            //
            // Create all Animals
            // 
            var Eagle = new Animal()
            {
                Name = "Eagle",
                Weight = 15.1,
                Habitat = new Habitat(),
                Species = new Species(),
                Diet = new Diet(),
                Origin = new Origin(),
                Visits = new List<Visit>(),

                IsChildOf = new List<Animal>(),
                IsParentOf = new List<Animal>()
            };

            var Horse = new Animal
            {
                Name = "Horse",
                Weight = 300.3,
                Habitat = new Habitat(),
                Species = new Species(),
                Diet = new Diet(),
                Origin = new Origin(),
                Visits = new List<Visit>(),

                IsChildOf = new List<Animal>(),
                IsParentOf = new List<Animal>()
            };

            var Dog = new Animal
            {
                Name = "Dog",
                Weight = 15.4,
                Habitat = new Habitat(),
                Species = new Species(),
                Diet = new Diet(),
                Origin = new Origin(),
                Visits = new List<Visit>(),

                IsChildOf = new List<Animal>(),
                IsParentOf = new List<Animal>()
            };

            var Cat = new Animal
            {
                Name = "Cat",
                Weight = 9.0,
                Habitat = new Habitat(),
                Species = new Species(),
                Diet = new Diet(),
                Origin = new Origin(),
                Visits = new List<Visit>(),

                IsChildOf = new List<Animal>(),
                IsParentOf = new List<Animal>()
            };

            var Wale = new Animal
            {
                Name = "Wale",
                Weight = 1200.2,
                Habitat = new Habitat(),
                Species = new Species(),
                Diet = new Diet(),
                Origin = new Origin(),
                Visits = new List<Visit>(),

                IsChildOf = new List<Animal>(),
                IsParentOf = new List<Animal>()
            };

            context.Animals.AddOrUpdate(
                        x => x.Name,
                        Eagle, Horse, Dog, Cat, Wale);

            // Habitats
            var Ground = new Habitat { Name = "Ground" };
            var Tree = new Habitat { Name = "Tree" };
            var Sea = new Habitat { Name = "Sea" };

            context.Habitats.AddOrUpdate(
                    x => x.Name,
                    Ground, Tree, Sea);

            // Species
            var Mammals = new Species { Name = "Mammals" };
            var Reptiles = new Species { Name = "Reptiles" };
            var Birds = new Species { Name = "Birds" };

            context.Species.AddOrUpdate(
                    x => x.Name, 
                    Mammals, Reptiles, Birds);

            // Diets
            var Vegetarian = new Diet { Name = "Vegetarian" };
            var Carnivor = new Diet { Name = "Carnivor" };

            context.Diets.AddOrUpdate(
                    x => x.Name,
                    Vegetarian, Carnivor);

            // Origins
            var Africa = new Origin { Name = "Africa" };
            var Asia = new Origin { Name = "Asia" };
            var NorthAmerica = new Origin { Name = "North America" };
            var SouthAmerica = new Origin { Name = "Sounth America" };
            var CentralAmerica = new Origin { Name = "Central America" };
            var Europe = new Origin { Name = "Europe" };
            var Australia = new Origin { Name = "Australia" };

            context.Origins.AddOrUpdate(
                    x => x.Name,
                    Africa, Asia, NorthAmerica, SouthAmerica, CentralAmerica, Europe, Australia);

            // After creating and Adding in the context: Animals and all the Entities
            // which are connected to it, I need to save, so each models get an ID
            context.SaveChanges();


            // Linking Animals to Habitat, Origin, Diet, Species
            // Visits will be set down when I define the Visits connections
            // Eagle
            //Eagle.Habitat = Tree;
            //Eagle.Species = Birds;
            //Eagle.Diet = Carnivor;
            //Eagle.Origin = NorthAmerica;
            // Eagle.Visits.Add(vis1) --> this is linked later from Visits Side!

            var animal1 = context.Animals.Where(c => c.Name == "Eagle").FirstOrDefault();
            animal1.Habitat = context.Habitats.Where(c => c.Name == "Tree").FirstOrDefault();
            animal1.Species = context.Species.Where(c => c.Name == "Birds").FirstOrDefault();
            animal1.Diet = context.Diets.Where(c => c.Name == "Carnivors").FirstOrDefault();
            animal1.Origin = context.Origins.Where(c => c.Name == "North America").FirstOrDefault();

            // Link to the entry in each table via the context to Animals table entry
            
            // Horse
            //Horse.Habitat = Ground;
            //Horse.Species = Mammals;
            //Horse.Diet = Vegetarian;
            //Horse.Origin = NorthAmerica;

            var animal2 = context.Animals.Where(c => c.Name == "Horse").FirstOrDefault();
            animal2.Habitat = context.Habitats.Where(c => c.Name == "Ground").FirstOrDefault();
            animal2.Species = context.Species.Where(c => c.Name == "Mammals").FirstOrDefault();
            animal2.Diet = context.Diets.Where(c => c.Name == "Vegetarian").FirstOrDefault();
            animal2.Origin = context.Origins.Where(c => c.Name == "North America").FirstOrDefault();

            // Dog
            //Dog.Habitat = Ground;
            //Dog.Species = Mammals;
            //Dog.Diet = Carnivor;
            //Dog.Origin = Europe;

            var animal3 = context.Animals.Where(c => c.Name == "Dog").FirstOrDefault();
            animal3.Habitat = context.Habitats.Where(c => c.Name == "Ground").FirstOrDefault();
            animal3.Species = context.Species.Where(c => c.Name == "Mammals").FirstOrDefault();
            animal3.Diet = context.Diets.Where(c => c.Name == "Carnivor").FirstOrDefault();
            animal3.Origin = context.Origins.Where(c => c.Name == "Europe").FirstOrDefault();

            // Cat
            //Cat.Habitat = Ground;
            //Cat.Species = Mammals;
            //Cat.Diet = Carnivor;
            //Cat.Origin = Europe;

            var animal4 = context.Animals.Where(c => c.Name == "Cat").FirstOrDefault();
            animal4.Habitat = context.Habitats.Where(c => c.Name == "Ground").FirstOrDefault();
            animal4.Species = context.Species.Where(c => c.Name == "Mammals").FirstOrDefault();
            animal4.Diet = context.Diets.Where(c => c.Name == "Carnivor").FirstOrDefault();
            animal4.Origin = context.Origins.Where(c => c.Name == "Europe").FirstOrDefault();

            // Wale
            //Wale.Habitat = Sea;
            //Wale.Species = Mammals;
            //Wale.Diet = Carnivor;
            //Wale.Origin = NorthAmerica;

            var animal5 = context.Animals.Where(c => c.Name == "Wale").FirstOrDefault();
            animal5.Habitat = context.Habitats.Where(c => c.Name == "Sea").FirstOrDefault();
            animal5.Species = context.Species.Where(c => c.Name == "Mammals").FirstOrDefault();
            animal5.Diet = context.Diets.Where(c => c.Name == "Carnivor").FirstOrDefault();
            animal5.Origin = context.Origins.Where(c => c.Name == "North America").FirstOrDefault();

            // Link the relations Parent - Child
            animal5.IsChildOf.Add(animal2);
            animal1.IsChildOf.Add(animal2);
            animal3.IsParentOf.Add(animal2);
            animal3.IsParentOf.Add(animal4);

            //Wale.IsChildOf.Add(Horse);
            //Eagle.IsChildOf.Add(Horse);
            ////Cat.IsChildOf.Add(Dog);
            //Dog.IsParentOf.Add(Cat);
            //Dog.IsParentOf.Add(Horse);

            //
            // Create all visits
            // 
            var vis1 = new Visit
            {
                Start = new DateTime(2017, 10, 02),
                End = new DateTime(2017, 10, 03),
                // Animal = context.Animals.Where(c => c.Name == "Eagle").FirstOrDefault(),
                //Diagnosis = context.Diagnosises.Where(c => c.Description == "Flu").FirstOrDefault(),
                //Veterinary = context.Veterinaries.Where(c => c.Name == "Francisco Manzano").FirstOrDefault(),
                //Drugs = context.Drugs.Where(c => c.Name == "Drug 1" && c.Name == "Drug 2").ToList()
            };

            var vis2 = new Visit
            {
                Start = new DateTime(2017, 06, 10),
                End = new DateTime(2017, 06, 11),
                // Animal = context.Animals.Where(c => c.Name == "Horse").FirstOrDefault(),
                //Diagnosis = context.Diagnosises.Where(c => c.Description == "Hart failure").FirstOrDefault(),
                //Veterinary = context.Veterinaries.Where(c => c.Name == "Anders Fredriksson").FirstOrDefault(),
                //Drugs = context.Drugs.Where(c => c.Name == "Drug 2" && c.Name == "Drug 3").ToList()
            };

            var vis3 = new Visit
            {
                Start = new DateTime(2017, 11, 3),
                End = new DateTime(2017, 11, 5),
                // Animal = context.Animals.Where(c => c.Name == "Dog").FirstOrDefault(),
                //Diagnosis = context.Diagnosises.Where(c => c.Description == "Low blod pressure").FirstOrDefault(),
                //Veterinary = context.Veterinaries.Where(c => c.Name == "Anders Fredriksson").FirstOrDefault(),
                //Drugs = context.Drugs.Where(c => c.Name == "Drug 4").ToList()
            };

            var vis4 = new Visit
            {
                Start = new DateTime(2017, 03, 16),
                End = new DateTime(2017, 03, 18),
                //  Animal = context.Animals.Where(c => c.Name == "Cat").FirstOrDefault(),
                //Diagnosis = context.Diagnosises.Where(c => c.Description == "Trauma").FirstOrDefault(),
                //Veterinary = context.Veterinaries.Where(c => c.Name == "Helena Lindeberg").FirstOrDefault(),
                //Drugs = context.Drugs.Where(c => c.Name == "Drug 1").ToList()
            };

            context.Visits.AddOrUpdate(
                x => new { x.ID, x.Start }, vis1, vis2, vis3, vis4);


            // Diagnosis
            var diag1 = new Diagnosis { Description = "Hart failure" };
            var diag2 = new Diagnosis { Description = "Low blod pressure" };
            var diag3 = new Diagnosis { Description = "Trauma" };
            var diag4 = new Diagnosis { Description = "Flu" };

            context.Diagnosises.AddOrUpdate(
               x => x.Description, diag1, diag2, diag3, diag4);
 
            // Vets
            var vet1 = new Veterinary { Name = "Francisco Manzano" };
            var vet2 = new Veterinary { Name = "Anders Fredriksson" };
            var vet3 = new Veterinary { Name = "Lotta Lindeberg" };
            var vet4 = new Veterinary { Name = "Helena Lindeberg" };

            context.Veterinaries.AddOrUpdate(
                x => x.Name, vet1, vet2, vet3, vet4);

            // Drugs
            var Drug1 = new Drug { Name = "Drug 1" };
            var Drug2 = new Drug { Name = "Drug 2" };
            var Drug3 = new Drug { Name = "Drug 3" };
            var Drug4 = new Drug { Name = "Drug 4" };

            context.Drugs.AddOrUpdate(
             x => x.Name, Drug1, Drug2, Drug3, Drug4);


            // Linking Visits to Diagnosis, veterinary, Drugs, Animal
            // vis1 -- Eagle
            vis1.Diagnosis = diag1;
            vis1.Veterinary = vet1;
            vis1.Drugs.Add(Drug1);
            vis1.Drugs.Add(Drug2);
            vis1.Animal = Eagle;  // I link the previously created animals in each Visit!

            // vis2 -- Horse
            vis2.Diagnosis = diag2;
            vis2.Veterinary = vet2;
            vis2.Drugs.Add(Drug3);
           // vis2.Drugs.Add(Drug2);
            vis2.Animal = Horse;

            // vis3 -- Dog
            vis3.Diagnosis = diag3;
            vis3.Veterinary = vet3;
            vis3.Drugs.Add(Drug3);
            vis3.Drugs.Add(Drug4);
            vis3.Animal = Dog;

            // vis4 -- Cat
            vis4.Diagnosis = diag4;
            vis4.Veterinary = vet4;
            vis4.Drugs.Add(Drug2);
            vis4.Animal = Cat;

            // Wales does not have any Visit 


            //new Animal
            //{
            //    Name = "Eagle",
            //    Weight = 15.1,
            //    Habitat = new Habitat(),
            //    Species = new Species(),
            //    Diet = new Diet(),
            //    Origin = new Origin(),
            //    Visits = new List<Visit>(),

            //    IsChildOf = new List<Animal>(),
            //    IsParentOf = new List<Animal>(),

            //   // Habitat = context.Habitats.Where(c => c.Name == "Tree").FirstOrDefault(),
            //    //  Species = context.Species.Where(c => c.Name == "Birds").FirstOrDefault(),
            //    //   Diet = context.Diets.Where(c => c.Name == "Carnivors").FirstOrDefault(),
            //    //   Origin = context.Origins.Where( c => c.Name == "North America").FirstOrDefault(),
            //    // Visits = new List<Visit> { new Visit { Start = new DateTime(2017, 10, 02), End = new DateTime(2017, 10, 03) } }
            //}

            //        new Animal
            //        {
            //            Name = "Horse",
            //            Weight = 300.3,
            //            //Habitat = context.Habitats.Where(c => c.Name == "Ground").FirstOrDefault(),
            //            //Species = context.Species.Where(c => c.Name == "Mammals").FirstOrDefault(),
            //            //Diet = context.Diets.Where(c => c.Name == "Vegetarian").FirstOrDefault(),
            //            //Origin = context.Origins.Where(c => c.Name == "North America").FirstOrDefault()
            //            // Visits = new List<Visit> { new Visit { Start = new DateTime(2017, 06, 10), End = new DateTime(2017, 06, 11) } }
            //        },

            //        new Animal
            //        {
            //            Name = "Dog",
            //            Weight = 15.4,
            //            //Habitat = context.Habitats.Where(c => c.Name == "Ground").FirstOrDefault(),
            //            //Species = context.Species.Where(c => c.Name == "Mammals").FirstOrDefault(),
            //            //Diet = context.Diets.Where(c => c.Name == "Carnivor").FirstOrDefault(),
            //            //Origin = context.Origins.Where(c => c.Name == "Europe").FirstOrDefault(),
            //            //  Visits = new List<Visit> { new Visit { Start = new DateTime(2017, 11, 3), End = new DateTime(2017, 11, 5) } }
            //        },

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
           


            // End method AddAnimals()
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
