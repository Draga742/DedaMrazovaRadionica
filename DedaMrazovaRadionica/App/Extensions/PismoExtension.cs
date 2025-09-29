using DedaMrazovaRadionica.Entities;
using DedaMrazovaRadionica.App.DTOs;

namespace DedaMrazovaRadionica.App.Extensions
{
    public static class PismoExtensions
    {
        public static PismoDTO ToPismoDTO(this Pismo pismo)
        {
            return new PismoDTO
            {
                IdPismo = pismo.Id_pismo,
                DatumSlanja = pismo.Datum_slanja,
                DatumPrimanja = pismo.Datum_primanja,
                Tekst = pismo.Tekst,
                IndeksDobrote = pismo.Indeks_dobrote,
                DeteId = pismo.Dete.Id_dete,

                DeteIme = pismo.Dete.Ime,
                DetePrezime = pismo.Dete.Prezime
            };
        }

        public static Pismo CreateNewEntity(this PismoDTO pismoDTO, Dete dete)
        {
            return new Pismo
            {
                Datum_slanja = pismoDTO.DatumSlanja,
                Datum_primanja = pismoDTO.DatumPrimanja,
                Tekst = pismoDTO.Tekst,
                Indeks_dobrote = pismoDTO.IndeksDobrote,
                Dete = dete
            };
        }
    }
}


