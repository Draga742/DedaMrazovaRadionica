using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using DedaMrazovaRadionica.Entities;
using FluentNHibernate.Conventions.Helpers;

namespace DedaMrazovaRadionica.Mapping
{
    public class ListaZeljaMapping : ClassMap<ListaZelja>
    {
        public ListaZeljaMapping()
        {
            Table("LISTA_ZELJA");

            Id(x => x.Id_lista, "ID_LISTA").GeneratedBy.TriggerIdentity();

            References(x => x.Pismo).Column("PISMO_ID").LazyLoad();

            HasMany(x => x.Zelje).KeyColumn("LISTA_ID").Cascade.All().Inverse();
        }
    }
}
