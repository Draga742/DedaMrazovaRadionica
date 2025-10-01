using DedaMrazovaRadionica.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DedaMrazovaRadionica.App.DTOs;

namespace DedaMrazovaRadionica.App.Services.Interfaces
{
    public interface IIrvasarService
    {
        ServiceResult<IList<IrvasarDTO>> GetAll();
        ServiceResult<IrvasarDTO> GetById(int id);
        ServiceResult<bool> Add(IrvasarDTO irvasarDTO, Irvas irvas);
        ServiceResult<bool> Delete(int irvasarId);
        ServiceResult<IList<IrvasarDTO>> GetByIrvas(int irvasId);
    }
}
