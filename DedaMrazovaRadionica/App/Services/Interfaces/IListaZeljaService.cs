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
    public interface IListaZeljaService
    {
        ServiceResult<IList<ListaZeljaDTO>> GetAll();
        ServiceResult<ListaZeljaDTO> GetById(int id);
        ServiceResult<bool> Add(ListaZeljaDTO listaZeljaDTO, Pismo pismo, IList<Zelja> zelje);
        ServiceResult<bool> Delete(int listaZeljaId);

    }
}
