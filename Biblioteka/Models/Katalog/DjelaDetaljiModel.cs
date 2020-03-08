using PodaciBiblioteke.Modeli;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Biblioteka.Models.Katalog
{
    public class DjelaDetaljiModel
    {
        public int Id{ get; set; }
        public string Naziv { get; set; }
        public string AutorIliReziser { get; set; }
        public string Tip { get; set; }
        public int Godina { get; set; }
        public string ISBN { get; set; }
        public string DeweyIndex { get; set; }
        public string Status { get; set; }
        public decimal Cijena { get; set; }
        public string LokacijaDjela { get; set; }
        public string UrlSlike { get; set; }
        public string ImeRezervatora { get; set; }
        public Iznajmljivanje ZadnjeIznajmljivanje { get; set; }
        public IEnumerable<HistorijaIznajmljivanja> GetHistorijaIznajmljivanja { get; set; }
        public IEnumerable<ZahtjevZaDjelo> TrenutnoZahtjeva { get; set; }



    }
    public class ZahtjevZaDjelo
    {
        public string ImeKlijenta{ get; set; }
        public string DatumZahtjeva { get; set; }

    }
}
