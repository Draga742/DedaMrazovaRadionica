using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DedaMrazovaRadionica.Entities
{
    public class DeoRadionice
    {
        public virtual int Id_radionica { get; set; }
        public virtual required string Naziv { get; set; }
        public virtual int? Broj_vilenjaka { get; set; } = 0;

        public virtual Sef? Sef { get; set; }

        public virtual IList<TipIgracke> TipoviIgracaka { get; set; }
        public virtual IList<MagicnaVestina> MagicneVestine { get; set; } 
        public virtual IList<Radnik> Radnici { get; set; }
        public DeoRadionice() 
        {
            TipoviIgracaka = new List<TipIgracke>();
            MagicneVestine = new List<MagicnaVestina>();
            Radnici = new List<Radnik>();
        }
    }
}
