using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DedaMrazovaRadionica.App.DTOs
{
    public class PismoDTO
    {
        public int IdPismo { get; set; }
        public DateTime DatumSlanja { get; set; } 
        public DateTime? DatumPrimanja { get; set; }
        public string? Tekst { get; set; }
        public int? IndeksDobrote { get; set; }

        public int DeteId { get; set; }

        //dete:
        public string DeteIme { get; set; }
        public string DetePrezime { get; set; }
    }
}

