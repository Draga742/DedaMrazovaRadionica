using DedaMrazovaRadionica.Entities;
using DedaMrazovaRadionica.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DedaMrazovaRadionica.App.DTOs
{
    public class DeoRadioniceDTO
    {
        public int IdRadionica { get; set; }
        public string Naziv { get; set; }
        public int? BrojVilenjaka { get; set; }
        public int? SefId { get; set; }//ovo je zapravo id vilenjaka

        //podaci o sefu:
        public string SefJedIme { get; set; }
        public string SefZemljaPorekla { get; set; }
        public DateTime SefDatumZaposlenja { get; set; }
        public DateTime SefDatumPostavljanja { get; set; }

        //lista tipova igracaka koje deo radionice pravi:
        public List<string> TipoviIgracakaNazivi { get; set; } = new();
        //lista magicnih vestina radionice:
        public List<MagicneVestine> MagicneVestineNazivi { get; set; } = new();
        //lista jedinstvenih imena radnika koji rade u tom delu radionice:
        public List<string> RadniciJedImena { get; set; } = new();
    }
}


