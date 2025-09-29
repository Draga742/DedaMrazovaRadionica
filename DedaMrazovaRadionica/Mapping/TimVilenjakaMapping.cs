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
    public class TimVilenjakaMapping : ClassMap<TimVilenjaka>
    {
        TimVilenjakaMapping() 
        {
            Table("TIM_VILENJAKA");

            Id(x => x.Id_tim, "ID_TIM").GeneratedBy.TriggerIdentity();

            Map(x => x.Naziv, "NAZIV");
            Map(x => x.Namena, "NAMENA");

            References(x => x.Koordinator).Column("KOORDINATOR_ID").LazyLoad();

            HasMany(x => x.Radnici).KeyColumn("TIM_ID").Cascade.All().Inverse();

            HasManyToMany(x => x.Pokloni)
                .Table("PAKOVAO_TIM")
                .ChildKeyColumn("POKLON_ID")
                .ParentKeyColumn("TIM_ID")
                .Cascade.All();

            HasManyToMany(x => x.Tovari)
                .Table("TOVAR_TIM")
                .ChildKeyColumn("TOVAR_ID")
                .ParentKeyColumn("TIM_ID")
                .Cascade.All().Inverse();
        }
    }
}
