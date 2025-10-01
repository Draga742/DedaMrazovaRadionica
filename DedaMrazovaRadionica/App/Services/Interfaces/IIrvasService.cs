using DedaMrazovaRadionica.App.DTOs;
using DedaMrazovaRadionica.Entities;
using DedaMrazovaRadionica.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DedaMrazovaRadionica.App.Services.Interfaces
{
    public interface IIrvasService
    {
        ServiceResult<IList<IrvasDTO>> GetAll();
        ServiceResult<bool> Add(IrvasDTO irvasDTO, Tovar tovar);

        //promena pola irvasu ako se tako oseca:
       // ServiceResult<bool> Update(IrvasDTO irvas, Pol pol);
        ServiceResult<IList<IrvasDTO>> GetByTovar(int tovarId);
        ServiceResult<IrvasDTO> GetByJedIme(string jedIme);
        ServiceResult<IrvasDTO> GetByNadimak(string jedNadimak);
    }
}

