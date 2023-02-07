namespace ConcertListing_Capstone.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Posti")]
    public partial class Posti
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Posti()
        {
            Ordine = new HashSet<Ordine>();
        }

        [Key]
        public int IdPosti { get; set; }

        [Required]
        [StringLength(20)]
        public string Zona { get; set; }

        public int PostiTotali { get; set; }

        public int PostiVenduti { get; set; }

        [Column(TypeName = "money")]
        [DisplayFormat(DataFormatString = "{0:c}")]
        public decimal Prezzo { get; set; }

        public int IdLuogo { get; set; }

        public virtual Luogo Luogo { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Ordine> Ordine { get; set; }
    }
}
