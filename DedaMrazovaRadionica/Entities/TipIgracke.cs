using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DedaMrazovaRadionica.Entities
{
    public class TipIgracke
    {
        public virtual int Id_tip_igracke { get; set; }
        public virtual required string Naziv { get; set; }
        public virtual string? Opis { get; set; }

        public virtual DeoRadionice? Deo_Radionice { get; set; } 

        public TipIgracke() { } 
    }
}
