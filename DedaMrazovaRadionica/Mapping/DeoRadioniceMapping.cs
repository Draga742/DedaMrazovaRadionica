using DedaMrazovaRadionica.Entities;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DedaMrazovaRadionica.Mapping
{
    public class DeoRadioniceMapping : ClassMap<DeoRadionice>
    {
        public DeoRadioniceMapping()
        {
            Table("DEO_RADIONICE");

            Id(x => x.Id_radionica, "ID_RADIONICA").GeneratedBy.TriggerIdentity();

            Map(x => x.Naziv, "NAZIV");
            Map(x => x.Broj_vilenjaka, "BROJ_VILENJAKA");

            References(x => x.Sef).Column("SEF_ID").Cascade.DeleteOrphan().LazyLoad();

            HasMany(x => x.TipoviIgracaka).KeyColumn("DEO_RADIONICE_ID").Cascade.None().Inverse();
            HasMany(x => x.Radnici).KeyColumn("DEO_RADIONICE_ID").Cascade.None().Inverse();

            HasManyToMany(x => x.MagicneVestine)
                 .Table("MAGICNE_VESTINE_DEO_RADIONICE")
                 .ChildKeyColumn("VESTINA_ID")
                 .ParentKeyColumn("DEO_RADIONICE_ID")
                 .Cascade.None();
        }
    }
}
