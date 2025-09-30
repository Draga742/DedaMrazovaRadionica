using DedaMrazovaRadionica.App.DTOs;
using DedaMrazovaRadionica.App.Services;
using DedaMrazovaRadionica.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DedaMrazovaRadionica.App.Services.Interfaces
{
    public interface IZeljaService
    {
        ServiceResult<IList<ZeljaDTO>> GetAll();
        ServiceResult<ZeljaDTO> GetByIdListe(int id);
        ServiceResult<bool> Add(ZeljaDTO zeljaDTO, TipIgracke tip, ListaZelja lista);
        ServiceResult<bool> Delete(int zeljaId);
    }
}