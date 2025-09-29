using DedaMrazovaRadionica.App.DTOs;
using DedaMrazovaRadionica.Entities;
using FluentNHibernate.Data;
using System.Linq;

namespace DedaMrazovaRadionica.App.Extensions
{
    public static class ListaZeljaExtensions
    {
        public static ListaZeljaDTO ToListaZeljaDTO(this ListaZelja listaZelja)
        {
            var dto = new ListaZeljaDTO
            {
                IdLista = listaZelja.Id_lista,
                IdPismo = listaZelja.Pismo.Id_pismo,
                Zelje = listaZelja.Zelje.Select(z => z.ToZeljaDTO()).ToList()
            };
            return dto;
        }

        public static ListaZelja CreateNewEntity(this ListaZeljaDTO dto, Pismo pismo, List<Zelja> zelje)
        {
            return new ListaZelja
            {
                Pismo = pismo,
                Zelje = zelje
            };
        }
    }
}