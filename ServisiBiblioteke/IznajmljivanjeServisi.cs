using Microsoft.EntityFrameworkCore;
using PodaciBiblioteke;
using PodaciBiblioteke.Modeli;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ServisiBiblioteke
{
    public class IznajmljivanjeServisi : IIznajmljivanja
    {
        private BibliotekaContext _context;
        public IznajmljivanjeServisi(BibliotekaContext c)
        {
            _context = c;
        }
        public void DodajNovoIznajmljivanje(Iznajmljivanje novo) //4
        {
            _context.Add(novo);
            _context.SaveChanges(); 
        }

        public void IznajmiDjelo(int IdDjela, int IdKartice) //5
        {
            var now = DateTime.Now;
            var djelo = _context.Djelo.Include(d=>d.Status).FirstOrDefault(d => d.ID == IdDjela);
            var kartica = _context.Kartice.Include(c=>c.Dolasci).FirstOrDefault(k => k.Id == IdKartice);
            _context.Update(djelo);
            djelo.Status = _context.Statusi.FirstOrDefault(s => s.Naziv == "Checked out");
            var iznajmljivanje = new Iznajmljivanje
            {
                Djelo = djelo,
                Kartica = kartica,
                DatumPrijave = now,
                DatumOdjave = now.AddDays(30)
            };
            _context.Add(iznajmljivanje);
            var historijaIznajmljivanja = new HistorijaIznajmljivanja
            {
                Djelo = djelo,
                Kartica = kartica,
                DatumPrijave = now,
            };
            _context.Add(historijaIznajmljivanja);
            _context.SaveChanges();
        }

        public void OznaciKaoIzgubljeno(int id)
        {
            var item = _context.Djelo.FirstOrDefault(d => d.ID == id);
            _context.Update(item);
            item.Status = _context.Statusi.FirstOrDefault(s => s.Naziv == "Lost");
            _context.SaveChanges();
        }

        public void OznaciKaoPronadjeno(int id)
        {
            var item = _context.Djelo.FirstOrDefault(d => d.ID == id);
            _context.Update(item);
            item.Status = _context.Statusi.FirstOrDefault(s => s.Naziv == "Available");
            var now = DateTime.Now;
            var iznajmljivanje = _context.Iznajmljivanje.FirstOrDefault(d => d.Djelo.ID == id);
            if (iznajmljivanje != null)
                _context.Remove(iznajmljivanje);
            var historija = _context.HistorijaIznajmljivanja.FirstOrDefault(hd => hd.Djelo.ID == id && hd.DatumOdjave == null);
            if (historija != null)
                historija.DatumOdjave = now;
            _context.SaveChanges();            
        }
        
        public DateTime PreuzmiDatumTrenutnogZahtjeva(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<HistorijaIznajmljivanja> PreuzmiHistorijuIznajmljivanja(int id) //7
        {
            return _context.HistorijaIznajmljivanja.Include(hd=>hd.Djelo).Include(hd => hd.Kartica).Where(hd=>hd.Id==id);
        }
         
        public string PreuzmiImeKorisnikaSaNajstarijimZahtjevom(int id)
        {
            return "nebitno";
        }

        public Iznajmljivanje PreuzmiPoID(int id) //2
        {
            return PreuzmiSve().FirstOrDefault(i => i.Id == id);
        }

        public IEnumerable<Iznajmljivanje> PreuzmiSve() //1
        {
            return _context.Iznajmljivanje;
        }
        public IEnumerable<ZahtjevZaIznajmljivanje>PreuzmiZahtjeveZaDjelo(int id)
        {
            return _context.ZahtjeviZaIznajmljivanje.Include(z => z.Djelo).Include(z => z.Kartica)
                .Where(z => z.Djelo.ID == id);
        }
        public Iznajmljivanje PreuzmiZadnjeIznajmljivanje(int id) //3
        {
            return _context.Iznajmljivanje.Where(d => d.Djelo.ID == id).OrderByDescending(d => d.DatumPrijave).FirstOrDefault();
        }

        public void StaviZahtjev(int IdDjela, int IdKartice)
        {
            throw new NotImplementedException();
        }

        public void VratiDjelo(int IdDjela, int IdKartice)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ZahtjevZaIznajmljivanje> PreuzmiTrenutneZahtjeve(int id)
        {
            throw new NotImplementedException();
        }
    }
}
