using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DedaMrazovaRadionica.Enums;

namespace DedaMrazovaRadionica.App.DTOs
{
    public class MagicnaVestinaDTO
    {
        public int IdVestina { get; set; }
        public MagicneVestine Naziv { get; set; } 
        public string? Opis { get; set; }
    }
}

