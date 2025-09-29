using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DedaMrazovaRadionica.App.DTOs
{
    public class IrvasarDTO : VilenjakDTO
    {
        public string? NazivPesme { get; set; } 
        public string? TekstPesme { get; set; }

        public int IrvasId { get; set; }
    }


}

