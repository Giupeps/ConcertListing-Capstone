namespace ConcertListing_Capstone.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Artista")]
    public partial class Artista
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Artista()
        {
            Concerto = new HashSet<Concerto>();
        }

        [Key]
        public int IdArtista { get; set; }

        [Required]
        [StringLength(30)]
        public string Nome { get; set; }

        [Required]
        public string Descrizione { get; set; }

        [Required]
        [StringLength(20)]
        public string Genere { get; set; }

        [StringLength(20)]
        public string Sottogenere { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Concerto> Concerto { get; set; }
    }
}
