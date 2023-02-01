namespace ConcertListing_Capstone.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Luogo")]
    public partial class Luogo
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Luogo()
        {
            Concerto = new HashSet<Concerto>();
            Posti = new HashSet<Posti>();
        }

        [Key]
        public int IdLuogo { get; set; }

        [Required]
        public string NomeStruttura { get; set; }

        [Required]
        [StringLength(20)]
        public string Città { get; set; }

        [Required]
        [StringLength(50)]
        public string Indirizzo { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Concerto> Concerto { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Posti> Posti { get; set; }
    }
}
