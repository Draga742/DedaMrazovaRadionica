using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DedaMrazovaRadionica.Entities;
using FluentNHibernate.Mapping;

namespace DedaMrazovaRadionica.Mapping
{
    public class IrvasarMapping : SubclassMap<Irvasar>
    {
        public IrvasarMapping() 
        {
            Table("IRVASAR");

            KeyColumn("ID_IRVASAR");

            Map(x => x.Naziv_pesme, "NAZIV_PESME");
            Map(x => x.Tekst_pesme, "TEKST_PESME");

            References(x => x.Irvas).Column("IRVAS_ID").Cascade.None().LazyLoad();
        }
    }
}
