using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace PodaciBiblioteke.Modeli
{
    public class RadnoVrijemePoslovnice
    {
        public int Id { get; set; }
        public PoslovnicaBiblioteke Poslovnica { get; set; }
        
        [Range(0,6)]
        public int DanUSedmici { get; set; }

        [Range(0,23)]
        public int VrijemeOtvaranja { get; set; }

        [Range(0, 23)]
        public int VrijemeZatvaranja { get; set; }

    }
}
