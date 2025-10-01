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
    public interface IDeoRadioniceService
    {
        ServiceResult<IList<DeoRadioniceDTO>> GetAll();
        ServiceResult<DeoRadioniceDTO> GetById(int id);
        ServiceResult<bool> Add(string naziv, int idRadnika, int idSefa);
        ServiceResult<bool> Delete(int deoRadioniceId);
        ServiceResult<bool> UpdateSef(DeoRadioniceDTO deoRadioniceDTO, Sef sef);
        ServiceResult<bool> UpdateNaziv(DeoRadioniceDTO deoRadioniceDTO, string novinaziv);
        //treba da moze da se doda tip iz postojece liste:
        ServiceResult<bool> AddTipIgracke(DeoRadioniceDTO deoRadioniceDTO, TipIgracke tipigracke);
        //treba da moze da se izbrise tip iz liste za tu radionicu:
        ServiceResult<bool> RemoveTipIgracke(DeoRadioniceDTO deoRadioniceDTO, int idTipa);
        //trceba da moze da se doda mag. vestina iz postojece liste:
        ServiceResult<bool> AddMagicnaVestina(DeoRadioniceDTO deoRadioniceDTO, MagicnaVestina magicnaVestina);
        //treba da moze da se izbrise mag. vestina iz liste za tu radionicu:
        ServiceResult<bool> RemoveMagicnaVestina(DeoRadioniceDTO deoRadioniceDTO, int idMagicnaVestina);
        ServiceResult<bool> IsNullTipoviIgracaka(DeoRadioniceDTO deoRadioniceDTO);
        ServiceResult<bool> IsNullMagicneVestine(DeoRadioniceDTO deoRadioniceDTO);
    }
}
