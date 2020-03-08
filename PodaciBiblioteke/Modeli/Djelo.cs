using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace PodaciBiblioteke.Modeli
{
    public abstract class Djelo
    {
        public int ID { get; set; }

        [Required]
        public string Naziv { get; set; }

        [Required]
        public int Godina{ get; set; }

        [Required]
        public Status Status { get; set; }

        [Required]
        public decimal Cijena { get; set; }
        public string UrlSlike { get; set; }
        public int BrojKopija { get; set; }
        public virtual PoslovnicaBiblioteke PoslovnicaBiblioteke { get; set; }

    }
}
