using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DedaMrazovaRadionica.Entities
{
    public class Sef : Vilenjak
    {
        public virtual required DateTime Datum_postavljanja { get; set; }

        public Sef()
        {

        }
    }
}
