using System;
using System.Collections.Generic;
using System.Text;

namespace PodaciBiblioteke.Modeli
{
    public class ZahtjevZaIznajmljivanje
    {
        public int Id { get; set; }
        public virtual Djelo Djelo { get; set; }
        public virtual Kartica Kartica { get; set; }
        public DateTime DatumPodnosenjaZahtjeva { get; set; }
    }
}
