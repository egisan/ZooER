using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooER.Models;
using System.Data.Entity;
using System.Data.Entity.Validation;

namespace ZooER.DAL
{
    class ZooContext : DbContext
    {
        public ZooContext() : base("ZooER")
        {
            Database.SetInitializer<ZooContext>(new UniDBInitializer<ZooContext>());
        }

        public DbSet<Animal> Animals { get; set; }
        //public DbSet<ChildParent> ChildrenParents { get; set; }

        public DbSet<Habitat> Habitats { get; set; }
        public DbSet<Species> Species { get; set; }
        public DbSet<Diet> Diets { get; set; }
        public DbSet<Origin> Origins { get; set; }
        public DbSet<Diagnosis> Diagnosises { get; set; }
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


        private class UniDBInitializer<T> : DropCreateDatabaseAlways<ZooContext>
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
                            new Origin { Name = "Sounth America" },
                            new Origin { Name = "Central America" },
                            new Origin { Name = "Europe" },
                            new Origin { Name = "Australia" }
                };
                origins.ForEach(s => context.Origins.Add(s));
                context.SaveChanges();




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


    }
