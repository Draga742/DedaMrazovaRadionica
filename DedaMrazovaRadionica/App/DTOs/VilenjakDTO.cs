using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DedaMrazovaRadionica.Enums;

namespace DedaMrazovaRadionica.App.DTOs
{
    public class VilenjakDTO
    {
        public int IdVilenjak { get; set; }
        public string JedIme { get; set; }
        public string ZemljaPorekla { get; set; } 
        public DateTime DatumZaposlenja { get; set; }

        // imena magicnih vestina koje poseduje
        public List<MagicneVestine> MagicneVestineNazivi { get; set; } = new();

    }
}
