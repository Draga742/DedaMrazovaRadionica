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
    public class DeteMapping : ClassMap<Dete>
    {
        public DeteMapping()
        {
            Table("DETE");//mapiranje tabele

            Id(x => x.Id_dete, "ID_DETE").GeneratedBy.TriggerIdentity();//mapiranje primarnog kljuca

            Map(x => x.Ime, "IME");
            Map(x => x.Prezime, "PREZIME");
            Map(x => x.Datum_rodjenja, "DATUM_RODJENJA");
            Map(x => x.Drzava, "DRZAVA");
            Map(x => x.Grad, "GRAD");
            Map(x => x.Ulica, "ULICA");
            Map(x => x.Broj, "BROJ");
            Map(x => x.Ime_oca, "IME_OCA");
            Map(x => x.Ime_majke, "IME_MAJKE");
        }
    }
}
