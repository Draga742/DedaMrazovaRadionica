using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DedaMrazovaRadionica.Entities
{
    public class Igracka
    {
        public virtual int Id_igracka { get; set; }
        public virtual string? Opis { get; set; }

        public virtual TipIgracke? Tip_Igracke { get; set; }
        public virtual Zelja? Zelja { get; set; }
        public virtual Poklon? Poklon { get; set; }

        public virtual IList<Radnik> Radnici { get; set; }

        public Igracka()
        {
            Radnici = new List<Radnik>();
        }
    }
}
