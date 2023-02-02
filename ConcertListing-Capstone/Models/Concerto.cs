namespace ConcertListing_Capstone.Models
{
    using Microsoft.SqlServer.Server;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Concerto")]
    public partial class Concerto
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Concerto()
        {
            Ordine = new HashSet<Ordine>();
        }

        [Key]
        public int IdConcerto { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yy}")]
        public DateTime Data { get; set; }

        [Required]
        public string ImmagineCopertina { get; set; }

        public int Durata { get; set; }

        public int IdLuogo { get; set; }

        public int IdArtistaBand { get; set; }

        public virtual Artista Artista { get; set; }

        public virtual Luogo Luogo { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Ordine> Ordine { get; set; }
    }
}
