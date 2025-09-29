using DedaMrazovaRadionica.Entities;
using DedaMrazovaRadionica.App.DTOs;

namespace DedaMrazovaRadionica.App.Extensions
{
    public static class DeteExtensions
    {
        public static DeteDTO ToDeteDTO(this Dete dete)
        {
            if (dete == null) return null;

            return new DeteDTO
            {
                IdDete = dete.Id_dete,
                Ime = dete.Ime,
                Prezime = dete.Prezime,
                DatumRodjenja = dete.Datum_rodjenja,
                Drzava = dete.Drzava,
                Grad = dete.Grad,
                Ulica = dete.Ulica,
                Broj = dete.Broj,
                ImeOca = dete.Ime_oca,
                ImeMajke = dete.Ime_majke
            };
        }

        public static Dete CreateNewEntity(this DeteDTO deteDTO)
        {
            if (deteDTO == null) return null;

            return new Dete
            {
                Ime = deteDTO.Ime,
                Prezime = deteDTO.Prezime,
                Datum_rodjenja = deteDTO.DatumRodjenja,
                Drzava = deteDTO.Drzava,
                Grad = deteDTO.Grad,
                Ulica = deteDTO.Ulica,
                Broj = deteDTO.Broj,
                Ime_oca = deteDTO.ImeOca,
                Ime_majke = deteDTO.ImeMajke
            };
        }
    }
}
