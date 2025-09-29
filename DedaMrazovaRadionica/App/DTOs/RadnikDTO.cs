using DedaMrazovaRadionica.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DedaMrazovaRadionica.App.DTOs
{
    public class RadnikDTO : VilenjakDTO
    {
        public int KoordinatorFlag { get; set; }
        public TipMagicneSpecijalizacije TipMSpecijalizacije { get; set; }//tip magicne specijalizacije
        public string DuzinaObuke { get; set; }
        public int KrajnjaOcena { get; set; }

        public int? TimId { get; set; }
        public string? JedImeMentora { get; set; }
        public int? DeoRadioniceId { get; set; }
    }
}

