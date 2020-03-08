using PodaciBiblioteke.Modeli;
using System;
using System.Collections.Generic;
using System.Text;

namespace PodaciBiblioteke
{
    public interface IIznajmljivanja
    {
        IEnumerable<Iznajmljivanje> PreuzmiSve();
        Iznajmljivanje PreuzmiPoID(int id);
        Iznajmljivanje PreuzmiZadnjeIznajmljivanje(int id);
        void DodajNovoIznajmljivanje(Iznajmljivanje novo);
        void IznajmiDjelo(int IdDjela,int IdKartice);
        void VratiDjelo(int IdDjela, int IdKartice);
        IEnumerable<HistorijaIznajmljivanja>PreuzmiHistorijuIznajmljivanja(int id);

        void StaviZahtjev(int IdDjela, int IdKartice);
        string PreuzmiImeKorisnikaSaNajstarijimZahtjevom(int id);
        DateTime PreuzmiDatumTrenutnogZahtjeva(int id);
        IEnumerable<ZahtjevZaIznajmljivanje> PreuzmiTrenutneZahtjeve(int id);

        void OznaciKaoIzgubljeno(int id);
        void OznaciKaoPronadjeno(int IdDjela);






    }
}
