using DedaMrazovaRadionica.Entities;
using DedaMrazovaRadionica.App.DTOs;

namespace DedaMrazovaRadionica.App.Extensions
{
    public static class IgrackaExtensions
    {
        public static IgrackaDTO ToIgrackaDTO(this Igracka igracka)
        {
            var dto = new IgrackaDTO
            {
                IdIgracka = igracka.Id_igracka,
                Opis = igracka.Opis,
                TipIgrackeId = igracka.Tip_Igracke.Id_tip_igracke,
                IdZelje = igracka.Zelja.Id_zelja,
                SifraPoklona = igracka.Poklon.Sifra
            };
            return dto;
        }

        public static Igracka CreateNewEntity(this IgrackaDTO igrackaDTO, TipIgracke tip, Zelja zelja, Poklon poklon)
        {
            return new Igracka
            {
                Opis = igrackaDTO.Opis,
                Tip_Igracke = tip,
                Zelja = zelja,
                Poklon = poklon
            };
        }
    }
}

