namespace ZooER.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
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
                        HabitatId = c.Int(nullable: false),
                        DietId = c.Int(nullable: false),
                        OriginId = c.Int(nullable: false),
                        Species_SpeciesId = c.Int(),
                    })
                .PrimaryKey(t => t.AnimalId)
                .ForeignKey("dbo.Diets", t => t.DietId, cascadeDelete: true)
                .ForeignKey("dbo.Habitats", t => t.HabitatId, cascadeDelete: true)
                .ForeignKey("dbo.Origins", t => t.OriginId, cascadeDelete: true)
                .ForeignKey("dbo.Species", t => t.Species_SpeciesId)
                .Index(t => t.HabitatId)
                .Index(t => t.DietId)
                .Index(t => t.OriginId)
                .Index(t => t.Species_SpeciesId);
            
            CreateTable(
                "dbo.Diets",
                c => new
                    {
                        DietId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 30),
                    })
                .PrimaryKey(t => t.DietId)
                .Index(t => t.Name, unique: true);
            
            CreateTable(
                "dbo.Habitats",
                c => new
                    {
                        HabitatId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 30),
                    })
                .PrimaryKey(t => t.HabitatId)
                .Index(t => t.Name, unique: true);
            
            CreateTable(
                "dbo.Origins",
                c => new
                    {
                        OriginId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 30),
                    })
                .PrimaryKey(t => t.OriginId)
                .Index(t => t.Name, unique: true);
            
            CreateTable(
                "dbo.Visits",
                c => new
                    {
                        VisitId = c.Int(nullable: false, identity: true),
                        Start = c.DateTime(nullable: false),
                        End = c.DateTime(),
                        AnimalId = c.Int(nullable: false),
                        DiagnosisId = c.Int(nullable: false),
                        VeterinaryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.VisitId)
                .ForeignKey("dbo.Animals", t => t.AnimalId, cascadeDelete: true)
                .ForeignKey("dbo.Diagnosis", t => t.DiagnosisId, cascadeDelete: true)
                .ForeignKey("dbo.Veterinaries", t => t.VeterinaryId, cascadeDelete: true)
                .Index(t => t.AnimalId)
                .Index(t => t.DiagnosisId)
                .Index(t => t.VeterinaryId);
            
            CreateTable(
                "dbo.Diagnosis",
                c => new
                    {
                        DiagnosisId = c.Int(nullable: false, identity: true),
                        Description = c.String(nullable: false, maxLength: 60),
                    })
                .PrimaryKey(t => t.DiagnosisId);
            
            CreateTable(
                "dbo.Drugs",
                c => new
                    {
                        DrugId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 30),
                    })
                .PrimaryKey(t => t.DrugId);
            
            CreateTable(
                "dbo.Veterinaries",
                c => new
                    {
                        VeterinaryId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 30),
                    })
                .PrimaryKey(t => t.VeterinaryId);
            
            CreateTable(
                "dbo.Species",
                c => new
                    {
                        SpeciesId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 30),
                    })
                .PrimaryKey(t => t.SpeciesId)
                .Index(t => t.Name, unique: true);
            
            CreateTable(
                "dbo.ChildrenParents",
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
                "dbo.VisitsDrugs",
                c => new
                    {
                        VisitID = c.Int(nullable: false),
                        DrugID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.VisitID, t.DrugID })
                .ForeignKey("dbo.Visits", t => t.VisitID, cascadeDelete: true)
                .ForeignKey("dbo.Drugs", t => t.DrugID, cascadeDelete: true)
                .Index(t => t.VisitID)
                .Index(t => t.DrugID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Animals", "Species_SpeciesId", "dbo.Species");
            DropForeignKey("dbo.Visits", "VeterinaryId", "dbo.Veterinaries");
            DropForeignKey("dbo.VisitsDrugs", "DrugID", "dbo.Drugs");
            DropForeignKey("dbo.VisitsDrugs", "VisitID", "dbo.Visits");
            DropForeignKey("dbo.Visits", "DiagnosisId", "dbo.Diagnosis");
            DropForeignKey("dbo.Visits", "AnimalId", "dbo.Animals");
            DropForeignKey("dbo.Animals", "OriginId", "dbo.Origins");
            DropForeignKey("dbo.ChildrenParents", "ParentID", "dbo.Animals");
            DropForeignKey("dbo.ChildrenParents", "ChildID", "dbo.Animals");
            DropForeignKey("dbo.Animals", "HabitatId", "dbo.Habitats");
            DropForeignKey("dbo.Animals", "DietId", "dbo.Diets");
            DropIndex("dbo.VisitsDrugs", new[] { "DrugID" });
            DropIndex("dbo.VisitsDrugs", new[] { "VisitID" });
            DropIndex("dbo.ChildrenParents", new[] { "ParentID" });
            DropIndex("dbo.ChildrenParents", new[] { "ChildID" });
            DropIndex("dbo.Species", new[] { "Name" });
            DropIndex("dbo.Visits", new[] { "VeterinaryId" });
            DropIndex("dbo.Visits", new[] { "DiagnosisId" });
            DropIndex("dbo.Visits", new[] { "AnimalId" });
            DropIndex("dbo.Origins", new[] { "Name" });
            DropIndex("dbo.Habitats", new[] { "Name" });
            DropIndex("dbo.Diets", new[] { "Name" });
            DropIndex("dbo.Animals", new[] { "Species_SpeciesId" });
            DropIndex("dbo.Animals", new[] { "OriginId" });
            DropIndex("dbo.Animals", new[] { "DietId" });
            DropIndex("dbo.Animals", new[] { "HabitatId" });
            DropTable("dbo.VisitsDrugs");
            DropTable("dbo.ChildrenParents");
            DropTable("dbo.Species");
            DropTable("dbo.Veterinaries");
            DropTable("dbo.Drugs");
            DropTable("dbo.Diagnosis");
            DropTable("dbo.Visits");
            DropTable("dbo.Origins");
            DropTable("dbo.Habitats");
            DropTable("dbo.Diets");
            DropTable("dbo.Animals");
        }
    }
}
