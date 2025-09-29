using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DedaMrazovaRadionica.App.DTOs
{
    public class PoklonDTO
    {
        public int IdPoklon { get; set; }
        public string Sifra { get; set; }
        public string? Boja { get; set; }
        public string? Posveta { get; set; }
        public int? TovarId { get; set; }
        public int? ListaZeljaId { get; set; }
    }
}
