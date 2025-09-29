using DedaMrazovaRadionica.App.DTOs;
using DedaMrazovaRadionica.Entities;
using DedaMrazovaRadionica.Enums;
using System.Linq;

namespace DedaMrazovaRadionica.App.Extensions
{
    public static class MentorExtensions
    {
        public static MentorDTO ToMentorDTO(this Mentor mentor)
        {
            return new MentorDTO
            {
                //vilenjak:
                IdVilenjak = mentor.Id_vilenjak,
                JedIme = mentor.Jed_ime,
                ZemljaPorekla = mentor.Zemlja_porekla,
                DatumZaposlenja = mentor.Datum_zaposlenja,
                MagicneVestineNazivi = mentor.MagicneVestine.Select(m => m.Naziv).ToList(),

                //mentor:
                Specijalizacija = mentor.Specijalizacija,
                NazivKursa = mentor.Naziv_kursa,
                Ocena = mentor.Ocena
            };
        }

        public static Mentor CreateNewEntity(this MentorDTO mentorDTO)
        {
            return new Mentor
            {
                Jed_ime = mentorDTO.JedIme,
                Zemlja_porekla = mentorDTO.ZemljaPorekla,
                Datum_zaposlenja = mentorDTO.DatumZaposlenja,

                Specijalizacija = mentorDTO.Specijalizacija,
                Naziv_kursa = mentorDTO.NazivKursa,
                Ocena = mentorDTO.Ocena
            };
        }
    }
}