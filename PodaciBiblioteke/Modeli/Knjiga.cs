using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace PodaciBiblioteke.Modeli
{
    public class Knjiga:Djelo
    {
        [Required]
        public string ISBN { get; set; }
        [Required]
        public string Autor{ get; set; }
        [Required]
        public string DeweyIndex { get; set; }

    }
}
