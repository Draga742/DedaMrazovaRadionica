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
    public class RadnikMapping : SubclassMap<Radnik> 
    {
        public RadnikMapping() 
        {
            Table("RADNIK");

            KeyColumn("ID_RADNIK");

            Map(x => x.Jed_ime, "JED_IME");
            Map(x => x.Koordinator_flag, "KOORDINATOR_FLAG");
            Map(x => x.Tip_m_specijalizacije, "TIP_M_SPECIJALIZACIJE");
            Map(x => x.Duzina_obuke, "DUZINA_OBUKE");
            Map(x => x.Krajnja_ocena, "KRAJNJA_OCENA");

            References(x => x.Tim_Vilenjaka).Column("TIM_ID").Cascade.None().LazyLoad();
            References(x => x.Deo_Radionice).Column("DEO_RADIONICE_ID").Cascade.None().LazyLoad();
            References(x => x.Mentor).Column("MENTOR_ID").Cascade.None().LazyLoad();

            HasManyToMany(x => x.Igracke)
                .Table("PRAVIO_RADNIK")
                .ChildKeyColumn("IGRACKA_ID")
                .ParentKeyColumn("RADNIK_ID")
                .Cascade.All();
        }
    }
}
