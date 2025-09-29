using DedaMrazovaRadionica.Entities;
using DedaMrazovaRadionica.App.DTOs;

namespace DedaMrazovaRadionica.App.Extensions
{
    public static class ZeljaExtensions
    {
        public static ZeljaDTO ToZeljaDTO(this Zelja zelja)
        {
            var dto = new ZeljaDTO
            {
                IdZelja = zelja.Id_zelja,
                RedniBroj = zelja.Redni_broj,
                Opis = zelja.Opis,
                TipIgrackeId = zelja.Tip_Igracke.Id_tip_igracke,
                ListaZeljaId = zelja.Lista_Zelja.Id_lista
            };
            return dto;
        }

        public static Zelja CreateNewEntity(this ZeljaDTO zeljaDTO, TipIgracke tip, ListaZelja lista)
        {
            return new Zelja
           { 
                Redni_broj = zeljaDTO.RedniBroj,
                Opis = zeljaDTO.Opis,
                Tip_Igracke = tip,
                Lista_Zelja = lista
           };
        }
    }
}