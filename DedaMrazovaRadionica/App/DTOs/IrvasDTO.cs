using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DedaMrazovaRadionica.Enums;

namespace DedaMrazovaRadionica.App.DTOs
{
    public class IrvasDTO
    {
        public int IdIrvas { get; set; }
        public string JedIme { get; set; }
        public string? Nadimak { get; set; }
        public DateTime DatumRodjenja { get; set; } 
        public Pol Pol { get; set; }
        public int? TovarId { get; set; }
    }


}


