using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DedaMrazovaRadionica.Entities
{
    public class Poklon
    {
        public virtual int Id_poklon { get; set; }
        public virtual required string Sifra { get; set; }
        public virtual string? Boja { get; set; }
        public virtual string? Posveta { get; set; }

        public virtual Tovar? Tovar { get; set; }
        public virtual ListaZelja? Lista_Zelja { get; set; }

        public virtual IList<Igracka> Igracke { get; set; }
        public virtual IList<TimVilenjaka> TimoviVilenjaka { get; set; }

        public Poklon()
        {
            Igracke = new List<Igracka>();
            TimoviVilenjaka = new List<TimVilenjaka>();

        }
    }
}
