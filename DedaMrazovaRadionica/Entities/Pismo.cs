using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DedaMrazovaRadionica.Entities
{
    public class Pismo
    {
        public virtual int Id_pismo { get; set; }
        public virtual required DateTime Datum_slanja { get; set; }
        public virtual DateTime? Datum_primanja { get; set; }
        public virtual string? Tekst { get; set; }
        public virtual int? Indeks_dobrote { get; set; }

        public virtual Dete Dete { get; set; }

        public Pismo()
        {

        }
    }
}
