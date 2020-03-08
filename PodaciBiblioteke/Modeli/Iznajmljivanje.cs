using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PodaciBiblioteke.Modeli
{
    public class Iznajmljivanje
    {
        public int Id { get; set; }

        [Required]
        public Djelo Djelo { get; set; }
        public Kartica Kartica { get; set; }
        public DateTime DatumPrijave { get; set; }
        public DateTime DatumOdjave { get; set; }

    }
}
