using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DedaMrazovaRadionica.Entities
{
    public class Irvasar : Vilenjak
    {
        public virtual string? Naziv_pesme { get; set; }
        public virtual string? Tekst_pesme { get; set; }

        public virtual Irvas? Irvas { get; set; }

        public Irvasar()
        {

        }
    }
}
