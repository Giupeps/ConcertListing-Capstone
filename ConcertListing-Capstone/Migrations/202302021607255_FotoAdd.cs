namespace ConcertListing_Capstone.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FotoAdd : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Artista", "Foto", c => c.String());
            AlterColumn("dbo.Artista", "Sottogenere", c => c.String(maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Artista", "Sottogenere", c => c.String(maxLength: 20));
            DropColumn("dbo.Artista", "Foto");
        }
    }
}
