using System;
using System.Collections.Generic;
using System.Text;

namespace PodaciBiblioteke.Modeli
{
    public class Klijent
    {
        public int Id { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Adresa { get; set; }
        public DateTime DatumRodjenja{ get; set; }
        public string BrojTelefona{ get; set; }
        public virtual Kartica Kartica { get; set; }
        public virtual PoslovnicaBiblioteke TrenutnaBiblioteka { get; set; }
        
    }
}
