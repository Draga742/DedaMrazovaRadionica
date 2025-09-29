using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DedaMrazovaRadionica.Entities;
using FluentNHibernate.Mapping;

namespace DedaMrazovaRadionica.Mapping
{
    public class MentorMapping : SubclassMap<Mentor>
    {
        public MentorMapping() 
        {
            Table("MENTOR");

            KeyColumn("ID_MENTOR");

            Map(x => x.Specijalizacija, "SPECIJALIZACIJA");
            Map(x => x.Naziv_kursa, "NAZIV_KURSA");
            Map(x => x.Ocena, "OCENA");

            HasMany(x => x.Radnici).KeyColumn("MENTOR_ID").Cascade.All().Inverse();
        }
    }
}
