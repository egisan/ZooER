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

            // THIS CODE IS FOR DEBUGGING Migrations

            //if (System.Diagnostics.Debugger.IsAttached == false)
            //{
            //    System.Diagnostics.Debugger.Launch();
            //}
        }

        protected override void Seed(ZooContext context)
        {
            //  This method will be called after migrating to the latest version.
            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
            // Add first the Entities on the "one" side

            // -------------------------------------------
            // All Entities around Animal
            // -------------------------------------------

            // Habitats table
            var habitats = new Habitat[]
            {
                        new Habitat { HabitatId = 1, Name = "Ground" },
                        new Habitat { HabitatId = 2, Name = "Tree" },
                        new Habitat { HabitatId = 3, Name = "Sea" }
            };
            // For each 'habitat' in the list 'habitats' above, 
            // add it to the ICollection Habitats in the context (in other words in the DB)

            // habitats.ForEach(s => context.Habitats.Add(s));

            context.Habitats.AddOrUpdate(x => x.Name, habitats);

            // Save all changes made in the current context 'ZooContext' to the DB!
            context.SaveChanges();


            // Species Table
            var species = new Species[]
            {
                            new Species { Name = "Mammals" },
                            new Species { Name = "Reptiles"},
                            new Species { Name = "Birds" }
            };
            // species.ForEach(s => context.Species.Add(s));
            context.Species.AddOrUpdate(x => x.Name, species);


            // Diets table
            var diets = new Diet[]
            {
                            new Diet { Name = "Vegetarian" },
                            new Diet { Name = "Carnivor" },
            };
            // diets.ForEach(s => context.Diets.Add(s));
            context.Diets.AddOrUpdate(x => x.Name, diets);
          
            
            // Origins Table
            var origins = new Origin[]
            {
                            new Origin { Name = "Africa" },
                            new Origin { Name = "Asia" },
                            new Origin { Name = "North America" },
                            new Origin { Name = "South America" },
                            new Origin { Name = "Central America" },
                            new Origin { Name = "Europe" },
                            new Origin { Name = "Australia" }
            };
            // origins.ForEach(s => context.Origins.Add(s));
            context.Origins.AddOrUpdate(x => x.Name, origins);
         

            // -------------------------------------------
            // All Entities around Visit
            // -------------------------------------------

            // Diagnosis Table
            var diagnoses = new Diagnosis[]
            {
                            new Diagnosis { Description = "Hart failure" },
                            new Diagnosis { Description = "Low blod pressure" },
                            new Diagnosis { Description = "Trauma" },
                            new Diagnosis { Description = "Flu" }
            };
            // Add the collection in the Context and then save in the DB
            context.Diagnoses.AddOrUpdate(x => x.Description, diagnoses);


            // Vets Table
            var veterinaries = new Veterinary[]
            {
                            new Veterinary { Name = "Francisco Manzano" },
                            new Veterinary { Name = "Anders Fredriksson" },
                            new Veterinary { Name = "Lotta Lindeberg" },
                            new Veterinary { Name = "Helena Lindeberg" }
            };
            context.Veterinaries.AddOrUpdate(x => x.Name, veterinaries);


            // Drugs Table
            var drugs = new Drug[]
            {
                            new Drug { DrugId = 1, Name = "Drug 1" },
                            new Drug { DrugId = 2, Name = "Drug 2" },
                            new Drug { DrugId = 3, Name = "Drug 3" },
                            new Drug { DrugId = 4, Name = "Drug 4" }
            };
            context.Drugs.AddOrUpdate(x => x.Name, drugs);

            context.SaveChanges();


            // --------------------------------------------
            // Animals
            // --------------------------------------------
            // NOTE! I JUST NEED TO INITIALIZE THE MAIN PROPERTIES and NOT the Navigation Props!
            // IMPORTANT!! To avoid FK conflicts, I need to specify placeholders for the IDs otherwise
            // EF Code First (which assigns by defaul the same value ID=0 to all object) will give error
            // https://stackoverflow.com/questions/11602683/error-seeding-database-foreign-key-issue
            var animals = new Animal[]
            {
                 new Animal() { AnimalId = 1, Name = "Eagle", Weight = 15.1, IsChildOf = new List<ChildParent>(), IsParentOf = new List<ChildParent>() },
                 new Animal() { AnimalId = 2, Name = "Horse", Weight = 300.3, IsChildOf = new List<ChildParent>(), IsParentOf = new List<ChildParent>() },
                 new Animal() { AnimalId = 3, Name = "Dog", Weight = 15.4, IsChildOf = new List<ChildParent>(), IsParentOf = new List<ChildParent>() },
                 new Animal() { AnimalId = 4, Name = "Cat", Weight = 9.0, IsChildOf = new List<ChildParent>(), IsParentOf = new List<ChildParent>() },
                 new Animal() { AnimalId = 5, Name = "Wale", Weight = 1200.2, IsChildOf = new List<ChildParent>(), IsParentOf = new List<ChildParent>() }
            };
            // -----------------------------------------------------------------------------------------
            // Need to create the relations from the "1" side and add the animals BEFORE savingChanges()
            // -----------------------------------------------------------------------------------------

            // Eagle links to Diet, Habitat, Origin & Species
            animals[0].Diet = diets[1];
            animals[0].Origin = origins[2];
            animals[0].Habitat = habitats[1];
            animals[0].Species = species[2];

            // Horse links
            animals[1].Diet = diets[1];
            animals[1].Origin = origins[2];
            animals[1].Habitat = habitats[0];
            animals[1].Species = species[0];

            // Dog links
            animals[2].Diet = diets[1];
            animals[2].Origin = origins[5];
            animals[2].Habitat = habitats[0];
            animals[2].Species = species[0];

            // Cat links
            animals[3].Diet = diets[1];
            animals[3].Origin = origins[5];
            animals[3].Habitat = habitats[0];
            animals[3].Species = species[0];

            // For wale
            animals[4].Diet = diets[1];
            animals[4].Origin = origins[3];
            animals[4].Habitat = habitats[2];
            animals[4].Species = species[0];


            // --------------------
            // Create all visits
            // --------------------
            // NOTE! I JUST NEED TO INITIALIZE THE MAIN PROPERTIES and NOT the Navigation Props!
            // IMPORTANT!! To avoid FK conflicts, I need to specify placeholders for the IDs otherwise
            // EF Code First (which assigns by defaul the same value ID=0 to all object) will give error
            // https://stackoverflow.com/questions/11602683/error-seeding-database-foreign-key-issue
            var visits = new Visit[]
            {
                new Visit { VisitId = 1, Start = new DateTime(2016, 10, 02, 10, 15, 45), Drugs = new List<VisitDrug>() },
                new Visit { VisitId = 2, Start = new DateTime(2017, 03, 16, 08, 30, 00), Drugs = new List<VisitDrug>() },
                new Visit { VisitId = 3, Start = new DateTime(2017, 09, 12, 15, 00, 00), Drugs = new List<VisitDrug>() }
            };


            // -------------------------------------
            // Create the Bridge table VisitDrugs
            // -------------------------------------
            // IMPORTANT!! To avoid FK conflicts, I need to specify placeholders for the IDs otherwise
            // EF Code First (which assigns by defaul the same value ID=0 to all object) will give error
            // https://stackoverflow.com/questions/11602683/error-seeding-database-foreign-key-issue
            VisitDrug[] visitDrugs = new VisitDrug[]
            {
                new VisitDrug { VisitID = visits[0].VisitId, DrugID = drugs[0].DrugId },
                new VisitDrug { VisitID = visits[1].VisitId, DrugID = drugs[2].DrugId },
                new VisitDrug { VisitID = visits[2].VisitId, DrugID = drugs[1].DrugId }
            };


            // -----------------------------------------------------------------------------------------
            // Need to create the relations from the "1" side and add the visits BEFORE savingChanges()
            // -----------------------------------------------------------------------------------------
            // Linking Visit to Diagnosis, Drugs, Veterinary, Animal

            // visits[0]
            visits[0].Diagnosis = diagnoses[0];
            visits[0].Veterinary = veterinaries[0];
            // visits[0].Drugs.Add(drugs[0]);
            visits[0].Animal = animals[0];

            // visits[1]
            visits[1].Diagnosis = diagnoses[1];
            visits[1].Veterinary = veterinaries[0];
            //  visits[1].Drugs.Add(drugs[2]);
            visits[1].Animal = animals[1];

            // visits[2]
            visits[2].Diagnosis = diagnoses[2];
            visits[2].Veterinary = veterinaries[1];
            // visits[2].Drugs.Add(drugs[1]);
            visits[2].Animal = animals[2];


            // -------------------------------------
            // Create the Bridge table ChildParents
            // -------------------------------------
            // IMPORTANT!! To avoid FK conflicts, I need to specify placeholders for the IDs otherwise
            // EF Code First (which assigns by defaul the same value ID=0 to all object) will give error
            // https://stackoverflow.com/questions/11602683/error-seeding-database-foreign-key-issue
            ChildParent[] childparents = new ChildParent[]
            {
                new ChildParent { ChildID = animals[0].AnimalId, ParentID = animals[1].AnimalId },
                new ChildParent { ChildID = animals[1].AnimalId, ParentID = animals[2].AnimalId },
                new ChildParent { ChildID = animals[3].AnimalId, ParentID = animals[2].AnimalId },
                new ChildParent { ChildID = animals[4].AnimalId, ParentID = animals[1].AnimalId }
            };

            // Add the Animals & Visits to the Context & Save to DB
            context.Animals.AddOrUpdate(x => x.Name, animals);
            context.Visits.AddOrUpdate(x => x.Start, visits);
            context.ChildParents.AddOrUpdate(c => new { c.ChildID, c.ParentID }, childparents);
            context.VisitDrugs.AddOrUpdate(v => new { v.VisitID, v.DrugID }, visitDrugs);
            context.SaveChanges();
        }
    }
}
