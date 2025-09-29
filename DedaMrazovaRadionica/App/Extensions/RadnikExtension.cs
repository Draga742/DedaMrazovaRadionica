using DedaMrazovaRadionica.App.DTOs;
using DedaMrazovaRadionica.Entities;
using DedaMrazovaRadionica.Enums;
using System.Collections.Generic;
using System.Linq;

namespace DedaMrazovaRadionica.App.Extensions
{
    public static class RadnikExtensions
    {
        public static RadnikDTO ToRadnikDTO(this Radnik radnik)
        {
            return new RadnikDTO
            {
                //vilenjak:
                IdVilenjak = radnik.Id_vilenjak,
                JedIme = radnik.Jed_ime,
                ZemljaPorekla = radnik.Zemlja_porekla,
                DatumZaposlenja = radnik.Datum_zaposlenja,
                MagicneVestineNazivi = radnik.MagicneVestine.Select(m => m.Naziv).ToList(),

                //radnik:
                KoordinatorFlag = radnik.Koordinator_flag,
                TipMSpecijalizacije = radnik.Tip_m_specijalizacije,
                DuzinaObuke = radnik.Duzina_obuke,
                KrajnjaOcena = radnik.Krajnja_ocena,
                TimId = radnik.Tim_Vilenjaka.Id_tim,
                JedImeMentora = radnik.Mentor.Jed_ime,
                DeoRadioniceId = radnik.Deo_Radionice.Id_radionica,
            };
        }

        public static Radnik CreateNewEntity(this RadnikDTO radnikDTO, TimVilenjaka tim, Mentor mentor, DeoRadionice radionica)
        {
            return new Radnik
            {
                //vilenjak:
                Jed_ime = radnikDTO.JedIme,
                Zemlja_porekla = radnikDTO.ZemljaPorekla,
                Datum_zaposlenja = radnikDTO.DatumZaposlenja,

                Koordinator_flag = radnikDTO.KoordinatorFlag,
                Tip_m_specijalizacije = radnikDTO.TipMSpecijalizacije,
                Duzina_obuke = radnikDTO.DuzinaObuke,
                Krajnja_ocena = radnikDTO.KrajnjaOcena,
                Tim_Vilenjaka = tim,
                Mentor = mentor,
                Deo_Radionice = radionica
            };
        }
    }
}
