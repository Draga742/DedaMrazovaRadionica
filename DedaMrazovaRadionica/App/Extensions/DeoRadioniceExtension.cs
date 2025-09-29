using DedaMrazovaRadionica.Entities;
using DedaMrazovaRadionica.App.DTOs;

namespace DedaMrazovaRadionica.App.Extensions
{
    public static class DeoRadioniceExtensions
    {
        public static DeoRadioniceDTO ToDeoRadioniceDTO(this DeoRadionice deoRadionice)
        {
            //osnovni podaci:
            var dto = new DeoRadioniceDTO
            {
                IdRadionica = deoRadionice.Id_radionica,
                Naziv = deoRadionice.Naziv,
                BrojVilenjaka = deoRadionice.Broj_vilenjaka,
                SefId = deoRadionice.Sef.Id_vilenjak
            };
            //podaci o sefu:
            dto.SefJedIme = deoRadionice.Sef.Jed_ime;
            dto.SefZemljaPorekla = deoRadionice.Sef.Zemlja_porekla;
            dto.SefDatumZaposlenja = deoRadionice.Sef.Datum_zaposlenja;
            dto.SefDatumPostavljanja = deoRadionice.Sef.Datum_postavljanja;

            dto.TipoviIgracakaNazivi = deoRadionice.TipoviIgracaka.Select(t => t.Naziv).ToList();
            dto.MagicneVestineNazivi = deoRadionice.MagicneVestine.Select(m => m.Naziv).ToList();
            dto.RadniciJedImena = deoRadionice.Radnici.Select(r => r.Jed_ime).ToList();

            return dto;
        }

        public static DeoRadionice CreateNewEntity(this DeoRadioniceDTO deoRadioniceDTO, Sef sef)
        {
            return new DeoRadionice
            {
                Naziv = deoRadioniceDTO.Naziv,
                Broj_vilenjaka = deoRadioniceDTO.BrojVilenjaka,
                //sef:
                Sef = sef
            };
        }
    }
}

