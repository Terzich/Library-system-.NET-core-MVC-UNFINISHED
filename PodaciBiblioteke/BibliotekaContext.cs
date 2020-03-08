using Microsoft.EntityFrameworkCore;
using PodaciBiblioteke.Modeli;
using System;

namespace PodaciBiblioteke
{
    public class BibliotekaContext:DbContext
    {
        public BibliotekaContext(DbContextOptions opcije):base(opcije){}
        public DbSet<Klijent> Klijenti { get; set; }
        public DbSet<Knjiga> Knjige{ get; set; }
        public DbSet<Video> Video { get; set; }
        public DbSet<Iznajmljivanje> Iznajmljivanje { get; set; }
        public DbSet<HistorijaIznajmljivanja> HistorijaIznajmljivanja { get; set; }
        public DbSet<PoslovnicaBiblioteke> Poslovnice { get; set; }
        public DbSet<RadnoVrijemePoslovnice> RadnoVrijemePoslovnica { get; set; }
        public DbSet<Kartica> Kartice { get; set; }
        public DbSet<Status> Statusi { get; set; }
        public DbSet<Djelo> Djelo{ get; set; }
        public DbSet<ZahtjevZaIznajmljivanje> ZahtjeviZaIznajmljivanje{ get; set; }
        public DbSet<Klijent> Klijent { get; set; }


    }
}
