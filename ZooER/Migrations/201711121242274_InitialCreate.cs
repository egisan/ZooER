namespace ZooER.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Animals",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Weight = c.Double(nullable: false),
                        Diet_ID = c.Int(),
                        Habitat_ID = c.Int(),
                        Origin_ID = c.Int(),
                        Species_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Diets", t => t.Diet_ID)
                .ForeignKey("dbo.Habitats", t => t.Habitat_ID)
                .ForeignKey("dbo.Origins", t => t.Origin_ID)
                .ForeignKey("dbo.Species", t => t.Species_ID)
                .Index(t => t.Diet_ID)
                .Index(t => t.Habitat_ID)
                .Index(t => t.Origin_ID)
                .Index(t => t.Species_ID);
            
            CreateTable(
                "dbo.Diets",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Habitats",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.ChildParents",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ChildID = c.Int(),
                        ParentID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Animals", t => t.ChildID)
                .ForeignKey("dbo.Animals", t => t.ParentID)
                .Index(t => t.ChildID)
                .Index(t => t.ParentID);
            
            CreateTable(
                "dbo.Origins",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Species",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Visits",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Start = c.DateTime(nullable: false),
                        End = c.DateTime(nullable: false),
                        Animal_ID = c.Int(),
                        Diagnosis_ID = c.Int(),
                        Veterinary_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Animals", t => t.Animal_ID)
                .ForeignKey("dbo.Diagnosis", t => t.Diagnosis_ID)
                .ForeignKey("dbo.Veterinaries", t => t.Veterinary_ID)
                .Index(t => t.Animal_ID)
                .Index(t => t.Diagnosis_ID)
                .Index(t => t.Veterinary_ID);
            
            CreateTable(
                "dbo.Diagnosis",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Drugs",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Veterinaries",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
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
            DropForeignKey("dbo.Visits", "Veterinary_ID", "dbo.Veterinaries");
            DropForeignKey("dbo.VisitsDrugs", "DrugID", "dbo.Drugs");
            DropForeignKey("dbo.VisitsDrugs", "VisitID", "dbo.Visits");
            DropForeignKey("dbo.Visits", "Diagnosis_ID", "dbo.Diagnosis");
            DropForeignKey("dbo.Visits", "Animal_ID", "dbo.Animals");
            DropForeignKey("dbo.Animals", "Species_ID", "dbo.Species");
            DropForeignKey("dbo.Animals", "Origin_ID", "dbo.Origins");
            DropForeignKey("dbo.ChildParents", "ParentID", "dbo.Animals");
            DropForeignKey("dbo.ChildParents", "ChildID", "dbo.Animals");
            DropForeignKey("dbo.Animals", "Habitat_ID", "dbo.Habitats");
            DropForeignKey("dbo.Animals", "Diet_ID", "dbo.Diets");
            DropIndex("dbo.VisitsDrugs", new[] { "DrugID" });
            DropIndex("dbo.VisitsDrugs", new[] { "VisitID" });
            DropIndex("dbo.Visits", new[] { "Veterinary_ID" });
            DropIndex("dbo.Visits", new[] { "Diagnosis_ID" });
            DropIndex("dbo.Visits", new[] { "Animal_ID" });
            DropIndex("dbo.ChildParents", new[] { "ParentID" });
            DropIndex("dbo.ChildParents", new[] { "ChildID" });
            DropIndex("dbo.Animals", new[] { "Species_ID" });
            DropIndex("dbo.Animals", new[] { "Origin_ID" });
            DropIndex("dbo.Animals", new[] { "Habitat_ID" });
            DropIndex("dbo.Animals", new[] { "Diet_ID" });
            DropTable("dbo.VisitsDrugs");
            DropTable("dbo.Veterinaries");
            DropTable("dbo.Drugs");
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
