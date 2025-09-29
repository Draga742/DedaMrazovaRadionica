using DedaMrazovaRadionica.Entities;
using DedaMrazovaRadionica.App.DTOs;
using System.Linq;
using System.Collections.Generic;

namespace DedaMrazovaRadionica.App.Extensions
{
    public static class TimVilenjakaExtensions
    {
        public static TimVilenjakaDTO ToTimVilenjakaDTO(this TimVilenjaka tim)
        {
            return new TimVilenjakaDTO
            {
                IdTim = tim.Id_tim,
                Naziv = tim.Naziv,
                Namena = tim.Namena,
                KoordinatorId = tim.Koordinator.Id_vilenjak,
                RadniciId = tim.Radnici.Select(r => r.Id_vilenjak).ToList()
            };
        }

        public static TimVilenjaka CreateNewEntity(this TimVilenjakaDTO timDTO, Radnik koordinator, List<Radnik> radnici, List<Poklon> pokloni, List<Tovar> tovari)
        {
            if (timDTO == null) return null;

            return new TimVilenjaka
            {
                Naziv = timDTO.Naziv,
                Namena = timDTO.Namena,
                Koordinator = koordinator,
                Radnici = radnici,
                Pokloni = pokloni,
                Tovari = tovari
            };
        }
    }
}
