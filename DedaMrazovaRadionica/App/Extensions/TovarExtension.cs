using DedaMrazovaRadionica.Entities;
using DedaMrazovaRadionica.App.DTOs;
using System.Linq;
using System.Collections.Generic;

namespace DedaMrazovaRadionica.App.Extensions
{
    public static class TovarExtensions
    {
        public static TovarDTO ToTovarDTO(this Tovar tovar)
        {
            return new TovarDTO
            {
                IdTovar = tovar.Id_tovar,
                Sifra = tovar.Sifra,
                Grad = tovar.Grad
            };
        }

        public static Tovar CreateNewEntity(this TovarDTO tovarDTO)
        {return new Tovar
            {
                Sifra = tovarDTO.Sifra,
                Grad = tovarDTO.Grad,
                //Irvasi = irvasi,     
                //TimoviVilenjaka = timovi
            };
        }
    }
}
