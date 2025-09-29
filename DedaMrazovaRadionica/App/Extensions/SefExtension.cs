using DedaMrazovaRadionica.Entities;
using DedaMrazovaRadionica.App.DTOs;
using System.Linq;
using System.Collections.Generic;

namespace DedaMrazovaRadionica.App.Extensions
{
    public static class SefExtensions
    {
        public static SefDTO ToSefDTO(this Sef sef)
        {
            return new SefDTO
            {
                //vilenjak:
                IdVilenjak = sef.Id_vilenjak,
                JedIme = sef.Jed_ime,
                ZemljaPorekla = sef.Zemlja_porekla,
                DatumZaposlenja = sef.Datum_zaposlenja,
                MagicneVestineNazivi = sef.MagicneVestine.Select(m => m.Naziv).ToList(),

                // specificno za sef:
                DatumPostavljanja = sef.Datum_postavljanja
            };
        }

        public static Sef CreateNewEntity(this SefDTO sefDTO)
        {
            return new Sef
            {
                // vilenjak
                Jed_ime = sefDTO.JedIme,
                Zemlja_porekla = sefDTO.ZemljaPorekla,
                Datum_zaposlenja = sefDTO.DatumZaposlenja,

                // sef
                Datum_postavljanja = sefDTO.DatumPostavljanja
            };
        }
    }
}
