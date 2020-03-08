using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PodaciBiblioteke.Modeli
{
    public class HistorijaIznajmljivanja
    {
        public int Id { get; set; }

        [Required]
        public Djelo Djelo { get; set; }

        [Required]
        public Kartica Kartica { get; set; }

        [Required]
        public DateTime DatumPrijave { get; set; }

        public DateTime? DatumOdjave { get; set; }
    }
}
