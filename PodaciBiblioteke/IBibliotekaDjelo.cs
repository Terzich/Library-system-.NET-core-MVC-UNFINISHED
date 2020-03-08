using PodaciBiblioteke.Modeli;
using System;
using System.Collections.Generic;
using System.Text;

namespace PodaciBiblioteke
{
    public interface IBibliotekaDjelo
    {
        IEnumerable<Djelo> PreuzmiSve();
        Djelo PreuzmiPoID(int id);
        void DodajNovoDjelo(Djelo djelo);
        string PreuzmiAutoraIliRezisera(int id);
        string PreuzmiDeweyIndex(int id);
        string PreuzmiTip(int id);
        string PreuzmiNaziv(int id);
        string PreuzmiIsbn(int id);
        PoslovnicaBiblioteke LokacijaGdjeSeNalaziDjelo(int id);
    }
}
