using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DedaMrazovaRadionica.Enums;

namespace DedaMrazovaRadionica.Entities
{
    public class Irvas
    {
        public virtual int Id_irvas { get; set; }
        public virtual required string Jed_ime { get; set; }
        public virtual string? Nadimak { get; set; }
        public virtual required DateTime Datum_rodjenja { get; set; }
        public virtual required Pol Pol { get; set; }
        public virtual Tovar? Tovar { get; set; }

        public virtual IList<Irvasar> Irvasari { get; set; }

        public Irvas()
        {
            Irvasari = new List<Irvasar>();
        }
    }
}
