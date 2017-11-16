using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooER.Models;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace ZooER.DAL
{
    public class ZooContext : DbContext
    {
        public ZooContext() : base("ZooER")
        {
            // Database.SetInitializer<ZooContext>(new CreateDatabaseIfNotExists<ZooContext>());
            //Database.SetInitializer<SchoolDBContext>(new DropCreateDatabaseAlways<SchoolDBContext>());

            //Database.SetInitializer<ZooContext>(new ZooDBInitializer());
            //Database.Initialize(true);
        }

        public DbSet<Animal> Animals { get; set; }
        // public DbSet<ChildParent> ChildrenParents { get; set; }

        public DbSet<Habitat> Habitats { get; set; }
        public DbSet<Species> Species { get; set; }
        public DbSet<Diet> Diets { get; set; }
        public DbSet<Origin> Origins { get; set; }
        public DbSet<Diagnosis> Diagnoses { get; set; }
        public DbSet<Visit> Visits { get; set; }
        public DbSet<Drug> Drugs { get; set; }
        public DbSet<Veterinary> Veterinaries { get; set; }

        // Some adaptations

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            // Many to many relation Edit for Visits <--> Drugs
            modelBuilder.Entity<Visit>()
                .HasMany(c => c.Drugs)
                .WithMany(c => c.Visits)
                .Map(m =>
                {
                    m.ToTable("VisitsDrugs");
                    m.MapLeftKey("VisitID");
                    m.MapRightKey("DrugID");
                });

            // Many to many relation Edit for Animal.Child <--> Animal.Parent

            // I want to DISABLE CASCaDE ON DELETE FOR ANIMALS
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            modelBuilder.Entity<Animal>()
               .HasMany(c => c.IsChildOf)
               .WithMany(d => d.IsParentOf)
               .Map(m =>
               {
                   m.ToTable("ChildrenParents");
                   m.MapLeftKey("ChildID");
                   m.MapRightKey("ParentID");
               });

            // modelBuilder.Entity<Visit>()
            //         .HasOptional(p => p.Drugs).WithOptionalPrincipal();

        }

        // I override the SaveChanges() for Troubleshooting purposes when I get Validation Errors in 
        // Seeding!!
        public override int SaveChanges()
        {
            try
            {
                return base.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                var errorMessages = ex.EntityValidationErrors
                        .SelectMany(x => x.ValidationErrors)
                        .Select(x => x.ErrorMessage);

                var fullErrorMessage = string.Join("; ", errorMessages);

                var exceptionMessage = string.Concat(ex.Message, " The validation errors are: ", fullErrorMessage);

                throw new DbEntityValidationException(exceptionMessage, ex.EntityValidationErrors);
            }
        }

    }


    public class ZooDBInitializer : DropCreateDatabaseAlways<ZooContext>
    // public class ZooDBInitializer : CreateDatabaseIfNotExists<ZooDBContext> // DEFAULT INitializer
    //  public class ZooDBInitializer : DropCreateDatabaseIfModelChanges<ZooDBContext>
    {
        protected override void Seed(ZooContext context)
        {
            // Habitats table
            List<Habitat> habitats = new List<Habitat>() {

                        new Habitat { Name = "Ground" },
                        new Habitat { Name = "Tree" },
                        new Habitat { Name = "Sea" }
                };
            // For each 'habitat' in the list 'habitats' above, 
            // add it to the ICollection Habitats in the context (in other words in the DB)
            habitats.ForEach(s => context.Habitats.Add(s));

            // Save all changes made in the current context 'ZooContext' to the DB!
            context.SaveChanges();


            // Species Table
            List<Species> species = new List<Species>() {
                            new Species { Name = "Mammals" },
                            new Species { Name = "Reptiles"},
                            new Species { Name = "Birds" }
                };

            species.ForEach(s => context.Species.Add(s));
            context.SaveChanges();

            // Diets table
            List<Diet> diets = new List<Diet>() {
                            new Diet { Name = "Vegetarian" },
                            new Diet { Name = "Carnivor" },
                };
            diets.ForEach(s => context.Diets.Add(s));
            context.SaveChanges();

            // Origins Table
            List<Origin> origins = new List<Origin>() {
                            new Origin { Name = "Africa" },
                            new Origin { Name = "Asia" },
                            new Origin { Name = "North America" },
                            new Origin { Name = "South America" },
                            new Origin { Name = "Central America" },
                            new Origin { Name = "Europe" },
                            new Origin { Name = "Australia" }
                };
            origins.ForEach(s => context.Origins.Add(s));
            context.SaveChanges();


            // Animals
            List<Animal> animals = new List<Animal>() {
                        new Animal
                        {
                            Name = "Eagle",
                            Weight = 15.1,
                            HabitatId = habitats[1].HabitatId, // context.Habitats.Where(c => c.Name == "Tree").SingleOrDefault().HabitatId,
                            SpeciesId = species[2].SpeciesId, // context.Species.Where(c => c.Name == "Birds").SingleOrDefault().SpeciesId,
                            DietId = diets[1].DietId, //context.Diets.Where(c => c.Name == "Carnivors").SingleOrDefault().DietId,
                            OriginId = origins[2].OriginId // context.Origins.Where(c => c.Name == "North America").SingleOrDefault().OriginId,

                            //Visits = new List<Visit>(),
                            //IsChildOf = new List<Animal>(),
                            //IsParentOf = new List<Animal>(),

                            // Visits = new List<Visit> { new Visit { Start = new DateTime(2017, 10, 02), End = new DateTime(2017, 10, 03) } }
                        },
                        new Animal
                        {
                            Name = "Horse",
                            Weight = 300.3,
                            HabitatId = habitats[0].HabitatId, // context.Habitats.Where(c => c.Name == "Ground").SingleOrDefault().HabitatId,
                            SpeciesId = species[0].SpeciesId, // context.Species.Where(c => c.Name == "Mammals").SingleOrDefault().SpeciesId,
                            DietId = diets[0].DietId, // context.Diets.Where(c => c.Name == "Vegetarian").SingleOrDefault().DietId,
                            OriginId = origins[2].OriginId // context.Origins.Where(c => c.Name == "North America").SingleOrDefault().OriginId,

                            // Visits = new List<Visit> { new Visit { Start = new DateTime(2017, 06, 10), End = new DateTime(2017, 06, 11) } }
                        },
                        new Animal
                        {
                            Name = "Dog",
                            Weight = 15.4,
                            HabitatId = habitats[0].HabitatId, // context.Habitats.Where(c => c.Name == "Ground").SingleOrDefault().HabitatId,
                            SpeciesId = species[0].SpeciesId, // context.Species.Where(c => c.Name == "Mammals").SingleOrDefault().SpeciesId,
                            DietId = diets[1].DietId, // context.Diets.Where(c => c.Name == "Carnivor").SingleOrDefault().DietId,
                            OriginId = origins[5].OriginId // context.Origins.Where(c => c.Name == "Europe").SingleOrDefault().OriginId,

                            //  Visits = new List<Visit> { new Visit { Start = new DateTime(2017, 11, 3), End = new DateTime(2017, 11, 5) } }
                        },
                        new Animal
                        {
                            Name = "Cat",
                            Weight = 9.0,
                            HabitatId = habitats[0].HabitatId, // context.Habitats.Where(c => c.Name == "Ground").SingleOrDefault().HabitatId,
                            SpeciesId = species[0].SpeciesId, // context.Species.Where(c => c.Name == "Mammals").SingleOrDefault().SpeciesId,
                            DietId = diets[1].DietId, // context.Diets.Where(c => c.Name == "Carnivor").SingleOrDefault().DietId,
                            OriginId = origins[5].OriginId // context.Origins.Where(c => c.Name == "Europe").SingleOrDefault().OriginId,

                            // Visits = new List<Visit> { new Visit { Start = new DateTime(2017, 03, 16), End = new DateTime(2017, 03, 18) } }
                        },
                        new Animal
                        {
                            Name = "Wale",
                            Weight = 1200.2,
                            HabitatId = habitats[2].HabitatId, // context.Habitats.Where(c => c.Name == "Sea").SingleOrDefault().HabitatId,
                            SpeciesId = species[0].SpeciesId, // context.Species.Where(c => c.Name == "Mammals").SingleOrDefault().SpeciesId,
                            DietId = diets[1].DietId, // context.Diets.Where(c => c.Name == "Carnivor").SingleOrDefault().DietId,
                            OriginId = origins[2].OriginId // context.Origins.Where(c => c.Name == "North America").SingleOrDefault().OriginId,

                            // Visits = new List<Visit> { new Visit { Start = new DateTime(2017, 03, 16), End = new DateTime(2017, 03, 18) } }
                        }
            };

            animals.ForEach(s => context.Animals.Add(s));
            context.SaveChanges();

        }
    }
}
