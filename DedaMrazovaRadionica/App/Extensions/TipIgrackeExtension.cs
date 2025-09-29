using DedaMrazovaRadionica.Entities;
using DedaMrazovaRadionica.App.DTOs;

namespace DedaMrazovaRadionica.App.Extensions
{
    public static class TipIgrackeExtensions
    {
        public static TipIgrackeDTO ToTipIgrackeDTO(this TipIgracke tip)
        {
            return new TipIgrackeDTO
            {
                IdTipIgracke = tip.Id_tip_igracke,
                Naziv = tip.Naziv,
                Opis = tip.Opis,
                DeoRadioniceId = tip.Deo_Radionice.Id_radionica
            };
        }
        public static TipIgracke CreateNewEntity(this TipIgrackeDTO tipDTO, DeoRadionice radionica)
        {
            return new TipIgracke
            {
                Naziv = tipDTO.Naziv,
                Opis = tipDTO.Opis,
                Deo_Radionice = radionica
            };
        }
    }
}
