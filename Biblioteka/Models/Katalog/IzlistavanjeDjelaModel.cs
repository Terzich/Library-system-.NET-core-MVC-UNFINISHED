using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Biblioteka.Models.Katalog
{
    public class IzlistavanjeDjelaModel
    {
        public int Id { get; set; }
        public string UrlSlike { get; set; }
        public string Naziv{ get; set; }
        public string AutorIliReziser { get; set; }
        public string Tip { get; set; }
        public string DeweyIndex { get; set; }
        public string BrojKopija { get; set; }

    }
}
