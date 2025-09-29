using DedaMrazovaRadionica.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DedaMrazovaRadionica.Entities
{
    public class Radnik : Vilenjak
    {
        public virtual int Koordinator_flag { get; set; }
        public virtual required TipMagicneSpecijalizacije Tip_m_specijalizacije { get; set; }
        public virtual required string Duzina_obuke { get; set; }
        public virtual required int Krajnja_ocena { get; set; }

        public virtual TimVilenjaka? Tim_Vilenjaka { get; set; }
        public virtual Mentor? Mentor { get; set; }
        public virtual DeoRadionice? Deo_Radionice { get; set; }

        public virtual IList<Igracka> Igracke { get; set; }

        public Radnik()
        {
            Igracke = new List<Igracka>();
        }
    }
}
