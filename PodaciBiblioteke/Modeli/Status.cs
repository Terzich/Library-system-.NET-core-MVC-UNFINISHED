using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace PodaciBiblioteke.Modeli
{
    public class Status
    {
        public int ID { get; set; }

        [Required]
        public string Naziv { get; set; }
        
        [Required]
        public string Opis { get; set; }

    }
}
