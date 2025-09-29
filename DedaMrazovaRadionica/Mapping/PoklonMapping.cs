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
    public class PoklonMapping : ClassMap<Poklon>
    {
        PoklonMapping() 
        {
            Table("POKLON");

            Id(x => x.Id_poklon, "ID_POKLON").GeneratedBy.TriggerIdentity();

            Map(x => x.Sifra, "SIFRA");
            Map(x => x.Boja, "BOJA");
            Map(x => x.Posveta, "POSVETA");

            References(x => x.Tovar).Column("TOVAR_ID").LazyLoad();
            References(x => x.Lista_Zelja).Column("LISTA_ZELJA_ID").LazyLoad();

            HasMany(x => x.Igracke).KeyColumn("POKLON_ID").Cascade.All().Inverse();

            HasManyToMany(x => x.TimoviVilenjaka)
                .Table("PAKOVAO_TIM")
                .ChildKeyColumn("TIM_ID")
                .ParentKeyColumn("POKLON_ID")
                .Cascade.All().Inverse();
        }
    }
}
