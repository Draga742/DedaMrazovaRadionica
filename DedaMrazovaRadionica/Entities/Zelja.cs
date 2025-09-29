using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DedaMrazovaRadionica.Entities
{
    public class Zelja
    {
        public virtual int Id_zelja { get; set; }
        public virtual required int Redni_broj { get; set; }
        public virtual required string Opis { get; set; }

        public virtual required TipIgracke Tip_Igracke { get; set; }
        public virtual required ListaZelja Lista_Zelja { get; set; }

        public Zelja() { }
    }
}
