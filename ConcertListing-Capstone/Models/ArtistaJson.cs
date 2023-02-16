using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ConcertListing_Capstone.Models
{
    public class ArtistaJson
    {
        
        public int IdArtista { get; set; }

      
        [StringLength(30)]
        public string Nome { get; set; }


        public string Foto { get; set; }

        
        public string Descrizione { get; set; }

        
        public string Genere { get; set; }

        public string Sottogenere { get; set; }

        public int IdConcerto { get; set; }
    }
}