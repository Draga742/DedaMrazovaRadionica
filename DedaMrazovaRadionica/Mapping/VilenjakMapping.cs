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
    public class VilenjakMapping : ClassMap<Vilenjak>
    {
        public VilenjakMapping() 
        {
            Table("VILENJAK");

            Id(x => x.Id_vilenjak).Column("ID_VILENJAK").GeneratedBy.TriggerIdentity();

            Map(x => x.Jed_ime).Column("JED_IME");
            Map(x => x.Zemlja_porekla).Column("ZEMLJA_POREKLA");
            Map(x => x.Datum_zaposlenja).Column("DATUM_ZAPOSLENJA");

            HasManyToMany(x => x.MagicneVestine)
                .Table("MAGICNE_VESTINE_VILENJAKA")
                .ChildKeyColumn("VESTINA_ID")
                .ParentKeyColumn("VILENJAK_ID")
                .Cascade.All();
        }
    }
}
