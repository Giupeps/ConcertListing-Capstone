namespace ConcertListing_Capstone.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class GenereChange : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Artista", "Genere", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Artista", "Genere", c => c.String(nullable: false, maxLength: 20));
        }
    }
}
