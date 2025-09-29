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
    public class IgrackaMapping : ClassMap<Igracka>
    {
        public IgrackaMapping() 
        {
            Table("IGRACKA");

            Id(x => x.Id_igracka, "ID_IGRACKA").GeneratedBy.TriggerIdentity();

            Map(x => x.Opis, "OPIS");

            References(x => x.Tip_Igracke).Column("TIP_IGRACKE_ID").LazyLoad();
            References(x => x.Zelja).Column("ZELJA_ID").LazyLoad();
            References(x => x.Poklon).Column("POKLON_ID").LazyLoad();

            HasManyToMany(x => x.Radnici)
                .Table("PRAVIO_RADNIK")
                .ChildKeyColumn("RADNIK_ID")
                .ParentKeyColumn("IGRACKA_ID")
                .Cascade.All().Inverse();
        }
    }
}
