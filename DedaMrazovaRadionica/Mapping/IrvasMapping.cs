using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DedaMrazovaRadionica.Entities;
using FluentNHibernate.Conventions.Helpers;
using DedaMrazovaRadionica.Enums;

namespace DedaMrazovaRadionica.Mapping
{
    public class IrvasMapping : ClassMap<Irvas>
    {
        public IrvasMapping() 
        {
            Table("IRVAS");

            Id(x => x.Jed_ime, "ID_IRVAS").GeneratedBy.TriggerIdentity();

            Map(x => x.Jed_ime, "JED_IME");
            Map(x => x.Nadimak, "NADIMAK");
            Map(x => x.Datum_rodjenja, "DATUM_RODJENJA");
            Map(x => x.Pol, "POL").CustomType<Pol>();

            References(x => x.Tovar).Column("TOVAR_SIFRA").LazyLoad();

            HasMany(x => x.Irvasari).KeyColumn("IRVAS_ID").Cascade.All().Inverse();
        }
    }
}
