using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DedaMrazovaRadionica.App.DTOs
{
    public class TipIgrackeDTO
    {
        public int IdTipIgracke { get; set; }
        public string Naziv { get; set; } 
        public string? Opis { get; set; }

        public int? DeoRadioniceId { get; set; }
    }
}
