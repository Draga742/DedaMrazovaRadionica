using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DedaMrazovaRadionica.App.DTOs
{
    public class ListaZeljaDTO
    {
        public int IdLista { get; set; }
        public int IdPismo { get; set; }

        public List<ZeljaDTO> Zelje { get; set; } = new();
    }
}
