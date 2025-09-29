using DedaMrazovaRadionica.App.DTOs;
using DedaMrazovaRadionica.Entities;
using DedaMrazovaRadionica.Enums;

namespace DedaMrazovaRadionica.App.Extensions
{
    public static class MagicnaVestinaExtensions
    {
        public static MagicnaVestinaDTO ToMagicnaVestinaDTO(this MagicnaVestina magicnaVestina)
        {
            return new MagicnaVestinaDTO
            {
                IdVestina = magicnaVestina.Id_vestina,
                Naziv = magicnaVestina.Naziv,
                Opis = magicnaVestina.Opis
            };
        }

        public static MagicnaVestina CreateNewEntity(this MagicnaVestinaDTO dto)
        {
            return new MagicnaVestina
            {
                Naziv = dto.Naziv,
                Opis = dto.Opis
            };
        }
    }
}
