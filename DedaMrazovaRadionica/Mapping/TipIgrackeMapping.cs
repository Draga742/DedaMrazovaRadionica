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
    public class TipIgrackeMapping : ClassMap<TipIgracke>
    {
        TipIgrackeMapping()
        {
            Table("TIP_IGRACKE");

            Id(x => x.Id_tip_igracke, "ID_TIP_IGRACKE").GeneratedBy.TriggerIdentity();

            Map(x => x.Naziv, "NAZIV");
            Map(x => x.Opis, "OPIS");

            References(x => x.Deo_Radionice).Column("DEO_RADIONICE_ID");

        }
    }
}
