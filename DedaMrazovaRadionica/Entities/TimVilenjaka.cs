using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DedaMrazovaRadionica.Entities
{
    public class TimVilenjaka
    {
        public virtual int Id_tim { get; set; }
        public virtual required string Naziv { get; set; }
        public virtual required string Namena { get; set; }

        public virtual required Radnik Koordinator { get; set; }

        public virtual IList<Radnik> Radnici { get; set; }
        public virtual IList<Poklon> Pokloni { get; set; }
        public virtual IList<Tovar> Tovari { get; set; }

        public TimVilenjaka()
        {
            Radnici = new List<Radnik>();
            Pokloni = new List<Poklon>();
            Tovari = new List<Tovar>();
        }
    }
}
