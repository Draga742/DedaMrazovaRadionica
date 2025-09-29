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
    public class ZeljaMapping : ClassMap<Zelja>
    {
        public ZeljaMapping()
        {
            Table("ZELJA");

            Id(x => x.Id_zelja, "ID_ZELJA").GeneratedBy.TriggerIdentity();

            Map(x => x.Redni_broj, "REDNI_BROJ");
            Map(x => x.Opis, "OPIS");

            References(x => x.Tip_Igracke).Column("TIP_IGRACKE_ID").LazyLoad();
            References(x => x.Lista_Zelja).Column("LISTA_ID").LazyLoad();
        }
    }
}
