using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace ConcertListing_Capstone.Models
{
    public partial class ModelDBContext : DbContext
    {
        public ModelDBContext()
            : base("name=ModelDBContext")
        {
        }

        public virtual DbSet<Artista> Artista { get; set; }
        public virtual DbSet<Concerto> Concerto { get; set; }
        public virtual DbSet<Luogo> Luogo { get; set; }
        public virtual DbSet<Ordine> Ordine { get; set; }
        public virtual DbSet<Posti> Posti { get; set; }
        public virtual DbSet<Utenti> Utenti { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Artista>()
                .HasMany(e => e.Concerto)
                .WithRequired(e => e.Artista)
                .HasForeignKey(e => e.IdArtistaBand)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Concerto>()
                .HasMany(e => e.Ordine)
                .WithRequired(e => e.Concerto)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Luogo>()
                .HasMany(e => e.Concerto)
                .WithRequired(e => e.Luogo)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Luogo>()
                .HasMany(e => e.Posti)
                .WithRequired(e => e.Luogo)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Ordine>()
                .Property(e => e.PrezzoTotale)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Posti>()
                .Property(e => e.Prezzo)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Posti>()
                .HasMany(e => e.Ordine)
                .WithRequired(e => e.Posti)
                .HasForeignKey(e => e.IdPosto)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Utenti>()
                .HasMany(e => e.Ordine)
                .WithRequired(e => e.Utenti)
                .WillCascadeOnDelete(false);
        }
    }
}
