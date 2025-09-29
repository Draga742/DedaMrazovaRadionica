using DedaMrazovaRadionica.Entities;
using DedaMrazovaRadionica.App.DTOs;

namespace DedaMrazovaRadionica.App.Extensions
{
    public static class PoklonExtensions
    {
        public static PoklonDTO ToPoklonDTO(this Poklon poklon)
        {return new PoklonDTO
            {
                IdPoklon = poklon.Id_poklon,
                Sifra = poklon.Sifra,
                Boja = poklon.Boja,
                Posveta = poklon.Posveta,
                TovarId = poklon.Tovar.Id_tovar,
                ListaZeljaId = poklon.Lista_Zelja.Id_lista
            };
        }

        public static Poklon CreateNewEntity(this PoklonDTO poklonDTO, Tovar tovar, ListaZelja lista, List<Igracka> igracke, List<TimVilenjaka> timovi)
        {
            if (poklonDTO == null) return null;

            return new Poklon
            {
                Sifra = poklonDTO.Sifra,
                Boja = poklonDTO.Boja,
                Posveta = poklonDTO.Posveta,
                Tovar = tovar,
                Lista_Zelja = lista,
                Igracke = igracke,
                TimoviVilenjaka = timovi
            };
        }
    }
}