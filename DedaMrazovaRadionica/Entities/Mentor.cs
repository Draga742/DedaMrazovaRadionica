using DedaMrazovaRadionica.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DedaMrazovaRadionica.Entities
{
    public class Mentor : Vilenjak
    {
        public virtual TipMagicneSpecijalizacije? Specijalizacija { get; set; }
        public virtual Kurs? Naziv_kursa { get; set; }
        public virtual int? Ocena { get; set; }

        public virtual IList<Radnik> Radnici { get; set; }

        public Mentor()
        {
            Radnici = new List<Radnik>();
        }
    }
}
