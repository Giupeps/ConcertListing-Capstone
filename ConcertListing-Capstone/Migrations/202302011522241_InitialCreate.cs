namespace ConcertListing_Capstone.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Artista",
                c => new
                    {
                        IdArtista = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 30),
                        Descrizione = c.String(nullable: false),
                        Genere = c.String(nullable: false, maxLength: 20),
                        Sottogenere = c.String(maxLength: 20),
                    })
                .PrimaryKey(t => t.IdArtista);
            
            CreateTable(
                "dbo.Concerto",
                c => new
                    {
                        IdConcerto = c.Int(nullable: false, identity: true),
                        Data = c.DateTime(nullable: false),
                        ImmagineCopertina = c.String(nullable: false),
                        Durata = c.Int(nullable: false),
                        IdLuogo = c.Int(nullable: false),
                        IdArtistaBand = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdConcerto)
                .ForeignKey("dbo.Luogo", t => t.IdLuogo)
                .ForeignKey("dbo.Artista", t => t.IdArtistaBand)
                .Index(t => t.IdLuogo)
                .Index(t => t.IdArtistaBand);
            
            CreateTable(
                "dbo.Luogo",
                c => new
                    {
                        IdLuogo = c.Int(nullable: false, identity: true),
                        NomeStruttura = c.String(nullable: false),
                        Città = c.String(nullable: false, maxLength: 20),
                        Indirizzo = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.IdLuogo);
            
            CreateTable(
                "dbo.Posti",
                c => new
                    {
                        IdPosti = c.Int(nullable: false, identity: true),
                        Zona = c.String(nullable: false, maxLength: 20),
                        PostiTotali = c.Int(nullable: false),
                        PostiVenduti = c.Int(nullable: false),
                        Prezzo = c.Decimal(nullable: false, storeType: "money"),
                        IdLuogo = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdPosti)
                .ForeignKey("dbo.Luogo", t => t.IdLuogo)
                .Index(t => t.IdLuogo);
            
            CreateTable(
                "dbo.Ordine",
                c => new
                    {
                        IdOrdine = c.Int(nullable: false, identity: true),
                        Quantità = c.Int(nullable: false),
                        PrezzoTotale = c.Decimal(nullable: false, storeType: "money"),
                        IdUtente = c.Int(nullable: false),
                        IdConcerto = c.Int(nullable: false),
                        IdPosto = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdOrdine)
                .ForeignKey("dbo.Utenti", t => t.IdUtente)
                .ForeignKey("dbo.Posti", t => t.IdPosto)
                .ForeignKey("dbo.Concerto", t => t.IdConcerto)
                .Index(t => t.IdUtente)
                .Index(t => t.IdConcerto)
                .Index(t => t.IdPosto);
            
            CreateTable(
                "dbo.Utenti",
                c => new
                    {
                        IdUtente = c.Int(nullable: false, identity: true),
                        Username = c.String(nullable: false, maxLength: 50),
                        Password = c.String(nullable: false),
                        Nome = c.String(nullable: false, maxLength: 50),
                        Cognome = c.String(nullable: false, maxLength: 50),
                        Ruolo = c.String(nullable: false, maxLength: 50),
                        Email = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.IdUtente);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Concerto", "IdArtistaBand", "dbo.Artista");
            DropForeignKey("dbo.Ordine", "IdConcerto", "dbo.Concerto");
            DropForeignKey("dbo.Posti", "IdLuogo", "dbo.Luogo");
            DropForeignKey("dbo.Ordine", "IdPosto", "dbo.Posti");
            DropForeignKey("dbo.Ordine", "IdUtente", "dbo.Utenti");
            DropForeignKey("dbo.Concerto", "IdLuogo", "dbo.Luogo");
            DropIndex("dbo.Ordine", new[] { "IdPosto" });
            DropIndex("dbo.Ordine", new[] { "IdConcerto" });
            DropIndex("dbo.Ordine", new[] { "IdUtente" });
            DropIndex("dbo.Posti", new[] { "IdLuogo" });
            DropIndex("dbo.Concerto", new[] { "IdArtistaBand" });
            DropIndex("dbo.Concerto", new[] { "IdLuogo" });
            DropTable("dbo.Utenti");
            DropTable("dbo.Ordine");
            DropTable("dbo.Posti");
            DropTable("dbo.Luogo");
            DropTable("dbo.Concerto");
            DropTable("dbo.Artista");
        }
    }
}
