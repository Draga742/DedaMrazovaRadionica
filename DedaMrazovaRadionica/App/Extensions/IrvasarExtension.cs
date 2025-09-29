using DedaMrazovaRadionica.App.DTOs;
using DedaMrazovaRadionica.Entities;
using DedaMrazovaRadionica.Enums;
using System.Linq;

namespace DedaMrazovaRadionica.App.Extensions
{
    public static class IrvasarExtensions
    {
        public static IrvasarDTO ToIrvasarDTO(this Irvasar irvasar)
        {
            return new IrvasarDTO
            {
                //vilenjak:
                IdVilenjak = irvasar.Id_vilenjak,
                JedIme = irvasar.Jed_ime,
                ZemljaPorekla = irvasar.Zemlja_porekla,
                DatumZaposlenja = irvasar.Datum_zaposlenja,
                MagicneVestineNazivi = irvasar.MagicneVestine.Select(m => m.Naziv).ToList(),

                //irvas deo:
                NazivPesme = irvasar.Naziv_pesme,
                TekstPesme = irvasar.Tekst_pesme,
                IrvasId = irvasar.Irvas.Id_irvas
            };
        }

        public static Irvasar CreateNewEntity(this IrvasarDTO dto, Irvas irvas)
        {
            return new Irvasar
            {
                Jed_ime = dto.JedIme,
                Zemlja_porekla = dto.JedIme,
                Datum_zaposlenja = dto.DatumZaposlenja,

                Naziv_pesme = dto.NazivPesme,
                Tekst_pesme = dto.TekstPesme,
                Irvas = irvas
            };
        }
    }
}

