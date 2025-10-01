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
    public class TovarMapping : ClassMap<Tovar>
    {

        TovarMapping() 
        {
            Table("TOVAR");

            Id(x => x.Id_tovar, "ID_TOVAR").GeneratedBy.TriggerIdentity();

            Map(x => x.Grad, "GRAD");

            HasMany(x => x.Irvasi).KeyColumn("TOVAR_SIFRA").Cascade.None().Inverse();

            HasManyToMany(x => x.TimoviVilenjaka)
                .Table("TOVAR_TIM")
                .ChildKeyColumn("TIM_ID")
                .ParentKeyColumn("TOVAR_ID")
                .Cascade.None();
        }
    }
}
