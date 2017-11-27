namespace ZooER.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Animals",
                c => new
                    {
                        AnimalId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 30),
                        Weight = c.Double(nullable: false),
                        HabitatId = c.Int(),
                        SpeciesId = c.Int(),
                        DietId = c.Int(),
                        OriginId = c.Int(),
                    })
                .PrimaryKey(t => t.AnimalId)
                .ForeignKey("dbo.Diets", t => t.DietId)
                .ForeignKey("dbo.Habitats", t => t.HabitatId)
                .ForeignKey("dbo.Origins", t => t.OriginId)
                .ForeignKey("dbo.Species", t => t.SpeciesId)
                .Index(t => t.HabitatId)
                .Index(t => t.SpeciesId)
                .Index(t => t.DietId)
                .Index(t => t.OriginId);
            
            CreateTable(
                "dbo.Diets",
                c => new
                    {
                        DietId = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 30),
                    })
                .PrimaryKey(t => t.DietId)
                .Index(t => t.Name, unique: true);
            
            CreateTable(
                "dbo.Habitats",
                c => new
                    {
                        HabitatId = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 30),
                    })
                .PrimaryKey(t => t.HabitatId)
                .Index(t => t.Name, unique: true);
            
            CreateTable(
                "dbo.ChildParents",
                c => new
                    {
                        ChildID = c.Int(nullable: false),
                        ParentID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ChildID, t.ParentID })
                .ForeignKey("dbo.Animals", t => t.ChildID)
                .ForeignKey("dbo.Animals", t => t.ParentID)
                .Index(t => t.ChildID)
                .Index(t => t.ParentID);
            
            CreateTable(
                "dbo.Origins",
                c => new
                    {
                        OriginId = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 30),
                    })
                .PrimaryKey(t => t.OriginId)
                .Index(t => t.Name, unique: true);
            
            CreateTable(
                "dbo.Species",
                c => new
                    {
                        SpeciesId = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 30),
                    })
                .PrimaryKey(t => t.SpeciesId)
                .Index(t => t.Name, unique: true);
            
            CreateTable(
                "dbo.Visits",
                c => new
                    {
                        VisitId = c.Int(nullable: false, identity: true),
                        Start = c.DateTime(nullable: false),
                        AnimalId = c.Int(),
                        DiagnosisId = c.Int(),
                        VeterinaryId = c.Int(),
                    })
                .PrimaryKey(t => t.VisitId)
                .ForeignKey("dbo.Animals", t => t.AnimalId)
                .ForeignKey("dbo.Diagnosis", t => t.DiagnosisId)
                .ForeignKey("dbo.Veterinaries", t => t.VeterinaryId)
                .Index(t => t.AnimalId)
                .Index(t => t.DiagnosisId)
                .Index(t => t.VeterinaryId);
            
            CreateTable(
                "dbo.Diagnosis",
                c => new
                    {
                        DiagnosisId = c.Int(nullable: false, identity: true),
                        Description = c.String(maxLength: 60),
                    })
                .PrimaryKey(t => t.DiagnosisId);
            
            CreateTable(
                "dbo.VisitDrugs",
                c => new
                    {
                        VisitID = c.Int(nullable: false),
                        DrugID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.VisitID, t.DrugID })
                .ForeignKey("dbo.Drugs", t => t.DrugID)
                .ForeignKey("dbo.Visits", t => t.VisitID)
                .Index(t => t.VisitID)
                .Index(t => t.DrugID);
            
            CreateTable(
                "dbo.Drugs",
                c => new
                    {
                        DrugId = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 30),
                    })
                .PrimaryKey(t => t.DrugId);
            
            CreateTable(
                "dbo.Veterinaries",
                c => new
                    {
                        VeterinaryId = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 30),
                    })
                .PrimaryKey(t => t.VeterinaryId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Visits", "VeterinaryId", "dbo.Veterinaries");
            DropForeignKey("dbo.VisitDrugs", "VisitID", "dbo.Visits");
            DropForeignKey("dbo.VisitDrugs", "DrugID", "dbo.Drugs");
            DropForeignKey("dbo.Visits", "DiagnosisId", "dbo.Diagnosis");
            DropForeignKey("dbo.Visits", "AnimalId", "dbo.Animals");
            DropForeignKey("dbo.Animals", "SpeciesId", "dbo.Species");
            DropForeignKey("dbo.Animals", "OriginId", "dbo.Origins");
            DropForeignKey("dbo.ChildParents", "ParentID", "dbo.Animals");
            DropForeignKey("dbo.ChildParents", "ChildID", "dbo.Animals");
            DropForeignKey("dbo.Animals", "HabitatId", "dbo.Habitats");
            DropForeignKey("dbo.Animals", "DietId", "dbo.Diets");
            DropIndex("dbo.VisitDrugs", new[] { "DrugID" });
            DropIndex("dbo.VisitDrugs", new[] { "VisitID" });
            DropIndex("dbo.Visits", new[] { "VeterinaryId" });
            DropIndex("dbo.Visits", new[] { "DiagnosisId" });
            DropIndex("dbo.Visits", new[] { "AnimalId" });
            DropIndex("dbo.Species", new[] { "Name" });
            DropIndex("dbo.Origins", new[] { "Name" });
            DropIndex("dbo.ChildParents", new[] { "ParentID" });
            DropIndex("dbo.ChildParents", new[] { "ChildID" });
            DropIndex("dbo.Habitats", new[] { "Name" });
            DropIndex("dbo.Diets", new[] { "Name" });
            DropIndex("dbo.Animals", new[] { "OriginId" });
            DropIndex("dbo.Animals", new[] { "DietId" });
            DropIndex("dbo.Animals", new[] { "SpeciesId" });
            DropIndex("dbo.Animals", new[] { "HabitatId" });
            DropTable("dbo.Veterinaries");
            DropTable("dbo.Drugs");
            DropTable("dbo.VisitDrugs");
            DropTable("dbo.Diagnosis");
            DropTable("dbo.Visits");
            DropTable("dbo.Species");
            DropTable("dbo.Origins");
            DropTable("dbo.ChildParents");
            DropTable("dbo.Habitats");
            DropTable("dbo.Diets");
            DropTable("dbo.Animals");
        }
    }
}
