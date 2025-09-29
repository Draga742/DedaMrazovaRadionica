using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DedaMrazovaRadionica.Enums;

namespace DedaMrazovaRadionica.Entities
{
    public class MagicnaVestina
    {
        public virtual int Id_vestina { get; set; }
        public virtual required MagicneVestine Naziv { get; set; }
        public virtual string? Opis { get; set; }

        public virtual IList<DeoRadionice> DeloviRadionce { get; set; }
        public virtual IList<Vilenjak> Vilenjaci { get; set; }

        public MagicnaVestina() 
        {
            DeloviRadionce = new List<DeoRadionice>();
            Vilenjaci = new List<Vilenjak>();
        }
    }
}
