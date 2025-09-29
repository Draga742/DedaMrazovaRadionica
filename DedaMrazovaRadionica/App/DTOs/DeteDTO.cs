using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DedaMrazovaRadionica.App.DTOs
{
    public class DeteDTO
    {
        public int IdDete { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; } 
        public DateTime DatumRodjenja { get; set; } 
        public string Drzava { get; set; } 
        public string Grad { get; set; } 
        public string? Ulica { get; set; } 
        public int? Broj { get; set; }
        public string? ImeOca { get; set; }
        public string? ImeMajke { get; set; }
    }
}
