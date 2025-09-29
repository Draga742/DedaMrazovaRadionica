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
    public class MagicnaVestinaMapping : ClassMap<MagicnaVestina>
    {
        public MagicnaVestinaMapping()
        {
            Table("MAGICNA_VESTINA");

            Id(x => x.Id_vestina, "ID_VESTINA").GeneratedBy.TriggerIdentity();

            Map(x => x.Naziv, "NAZIV");
            Map(x => x.Opis, "OPIS");

            HasManyToMany(x => x.DeloviRadionce)
                .Table("MAGICNE_VESTINE_DEO_RADIONICE")
                .ChildKeyColumn("DEO_RADIONICE_ID")
                .ParentKeyColumn("VESTINA_ID")
                .Cascade.All().Inverse();

            HasManyToMany(x => x.Vilenjaci)
                .Table("MAGICNE_VESTINE_VILENJAKA")
                .ChildKeyColumn("VILENJAK_ID")
                .ParentKeyColumn("VESTINA_ID")
                .Cascade.All().Inverse();
        }
    }
}
