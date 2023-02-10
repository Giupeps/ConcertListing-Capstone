namespace ConcertListing_Capstone.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Ordine")]
    public partial class Ordine
    {
        [Key]
        public int IdOrdine { get; set; }

        public int Quantità { get; set; }

        [Column(TypeName = "money")]
        public decimal PrezzoTotale { get; set; }

        public int IdUtente { get; set; }

        public int IdConcerto { get; set; }

        public int IdPosto { get; set; }

        public virtual Concerto Concerto { get; set; }

        public virtual Posti Posti { get; set; }

        public virtual Utenti Utenti { get; set; }

        public static List<Ordine> ListaCarrello = new List<Ordine>();
    }
}
