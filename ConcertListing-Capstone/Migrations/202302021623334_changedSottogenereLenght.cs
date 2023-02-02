namespace ConcertListing_Capstone.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changedSottogenereLenght : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Artista", "Sottogenere", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Artista", "Sottogenere", c => c.String(maxLength: 50));
        }
    }
}
