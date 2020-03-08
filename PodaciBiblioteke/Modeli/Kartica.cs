using System;
using System.Collections.Generic;
using System.Text;

namespace PodaciBiblioteke.Modeli
{
    public class Kartica
    {
        public int Id { get; set; }
        public decimal Naknade{ get; set; }
        public DateTime DatumKreiranja{ get; set; }
        public virtual IEnumerable<Iznajmljivanje> Dolasci { get; set; }
    }
}
