using DedaMrazovaRadionica.Entities;
using DedaMrazovaRadionica.App.DTOs;
using System.Linq;

namespace DedaMrazovaRadionica.App.Extensions
{
    public static class VilenjakExtensions
    {
        public static VilenjakDTO ToVilenjakDTO(this Vilenjak vilenjak)
        {
            if (vilenjak == null) return null;

            return new VilenjakDTO
            {
                IdVilenjak = vilenjak.Id_vilenjak,
                JedIme = vilenjak.Jed_ime,
                ZemljaPorekla = vilenjak.Zemlja_porekla,
                DatumZaposlenja = vilenjak.Datum_zaposlenja,
                MagicneVestineNazivi = vilenjak.MagicneVestine.Select(mv => mv.Naziv).ToList()
            };
        }

        public static Vilenjak CreateNewEntity(this VilenjakDTO vilenjakDTO, List<MagicnaVestina> vestine)
        {
            return new Vilenjak
            {
                Jed_ime = vilenjakDTO.JedIme,
                Zemlja_porekla = vilenjakDTO.ZemljaPorekla,
                Datum_zaposlenja = vilenjakDTO.DatumZaposlenja,

                MagicneVestine = vestine
            };
        }
    }
}
