using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace DedaMrazovaRadionica.App.DTOs
{
    public class TimVilenjakaDTO
    {
        public int IdTim { get; set; }
        public string Naziv { get; set; } 
        public string Namena { get; set; }
        public int KoordinatorId { get; set; } 

        public List<int> RadniciId { get; set; } = new();
    }
}

