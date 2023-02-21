using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ConcertListing_Capstone.Models
{
    public class ConcertiJson
    {
     
        public int IdConcerto { get; set; }

        [Column(TypeName = "date")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public string Data { get; set; }

       
        public string ImmagineCopertina { get; set; }

        public int Durata { get; set; }


        public int IdArtistaBand { get; set; }


        
        public int IdLuogo { get; set; }

        public string NomeStruttura { get; set; }

        
        [StringLength(20)]
        public string Città { get; set; }

        
        [StringLength(50)]
        public string Indirizzo { get; set; }
        public int IdArtista { get; set; }

       
        [StringLength(30)]
        public string Nome { get; set; }


        public string Foto { get; set; }

        public string Descrizione { get; set; }

        public string Genere { get; set; }

        public string Sottogenere { get; set; }
    }
}