using DedaMrazovaRadionica.App.DTOs;
using DedaMrazovaRadionica.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DedaMrazovaRadionica.App.Services.Interfaces
{
    public interface IRadnikService
    {
        //to do: filtriranje po delu radionice, mag. vestini, zaposljavanje i otposljavanje iz dela radioniice
        ServiceResult<IList<RadnikDTO>> GetAll();
        ServiceResult<RadnikDTO> GetById(int id);
        ServiceResult<bool> Add(RadnikDTO radnikDTO, TimVilenjaka tim, Mentor mentor, DeoRadionice radionica);
        ServiceResult<bool> Delete(int radnikId);
        ServiceResult<RadnikDTO> GetByJedIme(string jedIme);
        ServiceResult<IList<RadnikDTO>> GetByDeoRadionice(int deoRadioniceId);
        ServiceResult<IList<RadnikDTO>> GetByTim(int idTima);
        ServiceResult<IList<RadnikDTO>> GetBySaturatedDeoRadionice();
        ServiceResult<IList<RadnikDTO>> GetBySaturatedTim();
        //posle mozda dodam jos filtera
    }
}
