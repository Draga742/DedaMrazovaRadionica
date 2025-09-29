using DedaMrazovaRadionica.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DedaMrazovaRadionica.App.DTOs
{
    public class MentorDTO : VilenjakDTO
    {
        public TipMagicneSpecijalizacije? Specijalizacija { get; set; }
        public Kurs? NazivKursa { get; set; }
        public int? Ocena { get; set; }
    }
}
