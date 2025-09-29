using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DedaMrazovaRadionica.Entities
{
    public class Tovar
    {
        public virtual int Id_tovar { get; set; }
        public virtual required string Sifra { get; set; }
        public virtual required string Grad { get; set; }

        public virtual IList<Irvas> Irvasi { get; set; } 
        public virtual IList<TimVilenjaka> TimoviVilenjaka { get; set; }

        public Tovar()
        {
            Irvasi = new List<Irvas>();
            TimoviVilenjaka = new List<TimVilenjaka>();
        }
    }
}
