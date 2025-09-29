using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DedaMrazovaRadionica.Entities
{
    public class Dete
    {
        public virtual int Id_dete { get; set; }
        public virtual required string Ime { get; set; }
        public virtual required string Prezime { get; set; }
        public virtual required DateTime Datum_rodjenja { get; set; }
        public virtual required string Drzava { get; set; }
        public virtual required string Grad { get; set; }
        public virtual string? Ulica { get; set; }
        public virtual int? Broj { get; set; }
        public virtual string? Ime_oca { get; set; }
        public virtual string? Ime_majke { get; set; }

        public Dete() { }
    }
}
