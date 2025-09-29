using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DedaMrazovaRadionica.Entities
{
    public class Vilenjak
    {
        public virtual int Id_vilenjak { get; set; }
        public virtual required string Jed_ime { get; set; }
        public virtual required string Zemlja_porekla { get; set; }
        public virtual required DateTime Datum_zaposlenja { get; set; }

        public virtual IList<MagicnaVestina> MagicneVestine { get; set; }

        public Vilenjak()
        {
            MagicneVestine = new List<MagicnaVestina>();
        }
    }
}
