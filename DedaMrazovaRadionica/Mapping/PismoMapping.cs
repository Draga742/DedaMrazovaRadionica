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
    public class PismoMapping : ClassMap<Pismo>
    {
        public PismoMapping() 
        {
            Table("PISMO");

            Id(x => x.Id_pismo, "ID_PISMO").GeneratedBy.TriggerIdentity();

            Map(x => x.Datum_slanja, "DATUM_SLANJA");
            Map(x => x.Datum_primanja, "DATUM_PRIMANJA");
            Map(x => x.Tekst, "TEKST");
            Map(x => x.Indeks_dobrote, "INDEKS_DOBROTE");

            References(x => x.Dete).Column("DETE_ID").LazyLoad();
        }
    }
}
