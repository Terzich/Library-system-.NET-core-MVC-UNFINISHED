using Microsoft.EntityFrameworkCore;
using PodaciBiblioteke;
using PodaciBiblioteke.Modeli;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ServisiBiblioteke
{
    public class BibliotekaDjeloServisi : IBibliotekaDjelo
    {
        private BibliotekaContext _context;
        public BibliotekaDjeloServisi(BibliotekaContext c)
        {
            _context = c;
        }
        public void DodajNovoDjelo(Djelo djelo)
        {
            _context.Add(djelo);
            _context.SaveChanges();
        }

        public PoslovnicaBiblioteke LokacijaGdjeSeNalaziDjelo(int id)
        {
            //return _context.Djelo.FirstOrDefault(d => d.ID == id).PoslovnicaBiblioteke;
            return PreuzmiPoID(id).PoslovnicaBiblioteke;
        }

        public string PreuzmiAutoraIliRezisera(int id)
        {
            var jeLiAutor = _context.Djelo.Where(k => k.ID == id).OfType<Knjiga>().Any();

            return jeLiAutor ? _context.Knjige.FirstOrDefault(k => k.ID == id).Autor :
                    _context.Video.FirstOrDefault(v => v.ID == id).Reziser ?? "Nepoznato";
        }

        public string PreuzmiDeweyIndex(int id)
        {
            if (_context.Knjige.Any(knjiga => knjiga.ID == id))
                return _context.Knjige.FirstOrDefault(k => k.ID == id).DeweyIndex;
            else return " ";
        }

        public string PreuzmiIsbn(int id)
        {
            if (_context.Knjige.Any(k => k.ID == id))
                return _context.Knjige.FirstOrDefault(k => k.ID == id).ISBN;
            else return " ";
        }

        public string PreuzmiNaziv(int id)
        {
            return PreuzmiPoID(id).Naziv;
        }

        public Djelo PreuzmiPoID(int id)
        {
            return _context.Djelo.Include(djelo => djelo.Status).
                Include(djelo => djelo.PoslovnicaBiblioteke).FirstOrDefault(uslov => uslov.ID == id);
        }

        public IEnumerable<Djelo> PreuzmiSve()
        {
            return _context.Djelo.Include(djelo => djelo.Status).Include(djelo=>djelo.PoslovnicaBiblioteke) ;
        }

        public string PreuzmiTip(int id)
        {
            var knjiga = _context.Djelo.Where(k => k.ID == id).OfType<Knjiga>().Any();
            return knjiga ? "Ovo je knjiga" : "Ovo je video";
        }
    }
}
