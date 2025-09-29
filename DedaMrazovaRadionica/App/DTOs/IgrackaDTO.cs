using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DedaMrazovaRadionica.App.DTOs
{
    public class IgrackaDTO
    {
        public int IdIgracka { get; set; }
        public string? Opis { get; set; }

        public int? TipIgrackeId { get; set; }//id tipa igracke
        public int? IdZelje { get; set; }//cija je zelja
        public string? SifraPoklona { get; set; }//sifra kom poklonu pripada 
    }
}

