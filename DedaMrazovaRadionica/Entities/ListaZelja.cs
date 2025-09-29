using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DedaMrazovaRadionica.Entities
{
    public class ListaZelja
    {
        public virtual int Id_lista { get; set; }
        public virtual required Pismo Pismo { get; set; }

        public virtual IList<Zelja> Zelje { get; set; }
        public ListaZelja() 
        {
            Zelje = new List<Zelja>();
        }
    }
}
