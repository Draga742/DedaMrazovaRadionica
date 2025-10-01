using DedaMrazovaRadionica.App.DTOs;
using DedaMrazovaRadionica.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DedaMrazovaRadionica.App.Services.Interfaces
{
    public interface ITovarService
    {
        //to do: servis za dodelu tima tovaru
        ServiceResult<IList<TovarDTO>> GetAll();
        ServiceResult<bool> Add(TovarDTO tovarDTO);
        ServiceResult<bool> AsignTeam(TovarDTO tovarDTO, int timId);
        ServiceResult<TovarDTO> GetBySifra(string sifra);
        ServiceResult<IList<TovarDTO>> GetByGrad(string grad);
    }
}