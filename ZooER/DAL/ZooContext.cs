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
