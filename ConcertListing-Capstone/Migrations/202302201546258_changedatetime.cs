namespace ConcertListing_Capstone.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changedatetime : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Concerto", "Data", c => c.DateTime(nullable: false, storeType: "date"));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Concerto", "Data", c => c.DateTime(nullable: false));
        }
    }
}
