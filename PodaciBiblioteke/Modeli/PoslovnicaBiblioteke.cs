using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace PodaciBiblioteke.Modeli
{
    public class PoslovnicaBiblioteke
    {
        public int ID { get; set; }
    
        [Required]
        [StringLength(30,ErrorMessage ="Duzina imena poslovnice ne moze biti veca od 30")]
        public string Naziv { get; set; }
        
        [Required]
        public string Adresa { get; set; }
        public string Telefon { get; set; }
        public string Opis { get; set; }
        public DateTime DatumOtvaranja{ get; set; }
        public virtual IEnumerable<Klijent> Klijenti { get; set; }
        public virtual IEnumerable<Djelo> Djela { get; set; }
        public string UrlSlike { get; set; }


    }
}
