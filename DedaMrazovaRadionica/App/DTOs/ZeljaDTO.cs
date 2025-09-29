using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DedaMrazovaRadionica.App.DTOs
{
    public class ZeljaDTO
    {
        public int IdZelja { get; set; }
        public int RedniBroj { get; set; } 
        public string Opis { get; set; } 

        public int TipIgrackeId { get; set; } 
        public int ListaZeljaId { get; set; }
    }
}
