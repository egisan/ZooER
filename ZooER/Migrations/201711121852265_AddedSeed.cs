namespace ZooER.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedSeed : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Visits", "End", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Visits", "End", c => c.DateTime(nullable: false));
        }
    }
}
