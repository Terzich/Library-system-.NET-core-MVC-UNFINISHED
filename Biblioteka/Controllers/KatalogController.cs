using Biblioteka.Models.Katalog;
using Microsoft.AspNetCore.Mvc;
using PodaciBiblioteke;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Biblioteka.Controllers
{
    public class KatalogController:Controller
    {
        private IBibliotekaDjelo _djela;
        public KatalogController(IBibliotekaDjelo djela)
        {
            _djela = djela;
        }
        public IActionResult Index()
        {
            var djela = _djela.PreuzmiSve();
            var izlistanaDjela = djela.Select(rez => new IzlistavanjeDjelaModel
            {
                Id = rez.ID,
                UrlSlike = rez.UrlSlike,
                AutorIliReziser = _djela.PreuzmiAutoraIliRezisera(rez.ID),
                DeweyIndex = _djela.PreuzmiDeweyIndex(rez.ID),
                Naziv = rez.Naziv,
                Tip = _djela.PreuzmiTip(rez.ID)
            });
            var model = new DjelaModel()
            {
                Djela = izlistanaDjela
            };
            ViewData["djela"] = model;
            return View();

        }
        public IActionResult Detalji(int id)
        {
            var djelo = _djela.PreuzmiPoID(id);
            var model = new DjelaDetaljiModel
            {
                Id = id,
                Naziv = djelo.Naziv,
                Godina = djelo.Godina,
                Cijena = djelo.Cijena,
                Status = djelo.Status.Naziv,
                UrlSlike = djelo.UrlSlike,
                AutorIliReziser = _djela.PreuzmiAutoraIliRezisera(id),
                LokacijaDjela = _djela.LokacijaGdjeSeNalaziDjelo(id).Naziv,
                DeweyIndex=_djela.PreuzmiDeweyIndex(id),
                ISBN=_djela.PreuzmiIsbn(id)
            };

            return View(model);
        }

    }
}
