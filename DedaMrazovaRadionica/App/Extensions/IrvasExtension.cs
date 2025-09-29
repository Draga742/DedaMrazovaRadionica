using DedaMrazovaRadionica.App.DTOs;
using DedaMrazovaRadionica.Entities;
using DedaMrazovaRadionica.Enums;
using System;

namespace DedaMrazovaRadionica.App.Extensions
{
    public static class IrvasExtensions
    {
        public static IrvasDTO ToIrvasDTO(this Irvas irvas)
        {
            return new IrvasDTO
            {
                IdIrvas = irvas.Id_irvas,
                JedIme = irvas.Jed_ime,
                Nadimak = irvas.Nadimak,
                DatumRodjenja = irvas.Datum_rodjenja,
                Pol = irvas.Pol,
                TovarId = irvas.Tovar.Id_tovar
            };
        }

        public static Irvas CreateNewEntity(this IrvasDTO irvasDTO, Tovar tovar)
        {
            return new Irvas
            {
                Jed_ime = irvasDTO.JedIme,
                Nadimak = irvasDTO.Nadimak,
                Datum_rodjenja = irvasDTO.DatumRodjenja,
                Pol = irvasDTO.Pol,
                Tovar = tovar
            };
        }
    }
}
