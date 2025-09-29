using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DedaMrazovaRadionica.Entities;
using FluentNHibernate.Mapping;

namespace DedaMrazovaRadionica.Mapping
{
    public class SefMapping : SubclassMap<Sef>
    {
        public SefMapping() 
        {
            Table("SEF");

            KeyColumn("ID_SEF");

            Map(x => x.Datum_postavljanja, "DATUM_POSTAVLJANJA");
        }
    }
}
